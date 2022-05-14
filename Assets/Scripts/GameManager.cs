using System;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameManager Instance { get; private set; }
    
    //Audio stuff...

    private void Awake()
    {
        if (Instance == null) Instance = this;
        else Destroy(this);
            
        DontDestroyOnLoad(this);
    }

    private void Update()
    {
        var mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        // Shoot ray from mousePosition with zero vector direction
        var raycastHit2D = Physics2D.Raycast(new Vector2(mousePosition.x, mousePosition.y), 
            Vector2.zero);
        
        // If right mouse button is down
        // and ray hit clickable object
        if (raycastHit2D && 
            Input.GetMouseButtonDown(0) && 
            raycastHit2D.collider.TryGetComponent<IClickable>(out var clickable))
        {
            clickable.Click();
        }
        
        // If mouse hovered over hoverable object
        if (raycastHit2D && 
            raycastHit2D.collider.TryGetComponent<IHoverable>(out var hoverable) && 
            Vector3.Distance(mousePosition, hoverable.GetPosition()) < Math.E)
        {
            hoverable.Hover();
        }
    }
}
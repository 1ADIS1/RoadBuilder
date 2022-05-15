using UnityEngine;

// Pattern used: Singleton
public class GameManager : MonoBehaviour
{
    // private IHoverable hoveredObject;
    // private IClickable clickedObject;
    
    public static GameManager Instance { get; private set; }
    
    //Audio stuff...

    private void Awake()
    {
        if (Instance == null) Instance = this;
        else Destroy(this);

        DontDestroyOnLoad(this);
    }

    public Vector3 GetMousePositionInWorld(float zComponent)
    {
        if (Camera.main == null) return Vector3.zero;
        var mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePosition.z = zComponent;

        return mousePosition;
    }

    // private void Update()
    // {
    //
    //     // Shoot ray from mousePosition with zero vector direction
    //     // var raycastHit2D = Physics2D.Raycast(new Vector2(mousePosition.x, mousePosition.y), 
    //     //     Vector2.zero);
    //
    //     // // If mouse hovered over hoverable object or clicked clickable object
    //     // if (raycastHit2D && 
    //     //     raycastHit2D.collider.TryGetComponent<IHoverable>(out var hoverable))
    //     // {
    //     //     hoveredObject = hoverable;
    //     //     hoveredObject.Hover();
    //     //     
    //     //     if (Input.GetMouseButtonDown(0) && 
    //     //         raycastHit2D.collider.TryGetComponent<IClickable>(out var clickable))
    //     //     {
    //     //         clickedObject = clickable;
    //     //         clickedObject.Click();
    //     //     }
    //     // }
    //     // // If nothing was hovered nor clicked
    //     // else
    //     // {
    //     //     hoveredObject = null;
    //     //
    //     //     if (Input.GetMouseButtonDown(0))
    //     //     {
    //     //         clickedObject = null;
    //     //     }
    //     // }
    // }
}
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
    
    
}
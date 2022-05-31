using UnityEngine;

public class Brick : MonoBehaviour
{
    public Sprite sprite;
    
    [SerializeField] private LayerMask slotLayerMask;
    
    public void OnMouseDrag()
    {
        Debug.Log("Oh no! I am being dragged...");

        transform.position = GameManager.Instance.GetMousePositionInWorld(transform.position.z);
    }

    private void OnMouseUp()
    {
        Debug.Log("Drag stop");
        
        // Cast raycast from this brick position in Slot layer mask
        var raycastHit2D = Physics2D.Raycast(
            transform.position, Vector2.zero, float.MinValue, slotLayerMask
            );
        
        // If it hit the Slot, then change it's content
        if (raycastHit2D && raycastHit2D.collider.TryGetComponent(out Slot slot)) 
            slot.ChangeContent(this);

        
        // var mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        //
        // // Shoot ray from mousePosition with zero vector direction
        // var raycastHit2D = Physics2D.Raycast(mousePosition, Vector2.zero);
        //
        // // If right mouse button is down
        // // and ray hit clickable object
        // if (raycastHit2D && raycastHit2D.collider.TryGetComponent<IPlaceable>(out var placeable))
        // {
        //     placeable.ChangeContent(this);
        // }
    }
}

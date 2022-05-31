using UnityEngine;

public class Brick : MonoBehaviour
{
    public Sprite sprite;
    public Vector2 gridPosition;

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
        {
            slot.Place(this);
            Debug.Log(gridPosition);    
            BricksSack.instance.RemoveBrick(gridPosition);
        }
    }
}

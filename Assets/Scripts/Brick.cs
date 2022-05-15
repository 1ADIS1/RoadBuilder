using UnityEngine;

public class Brick : MonoBehaviour
{
    private void OnMouseDrag()
    {
        Debug.Log("Oh no! I am being dragged...");

        var myTransform = transform;
        
        // When brick is dragged, it is removed from sack
        myTransform.parent = null;
        transform.position = GameManager.Instance.GetMousePositionInWorld(myTransform.position.z);
    }
}

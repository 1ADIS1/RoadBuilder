using UnityEngine;

public class Slot : MonoBehaviour, IPlaceable
{
    [SerializeField] private SpriteRenderer _spriteRenderer;
    
    public Brick currentBrick;

    public void ClearSlot()
    {
        currentBrick = null;
    }

    public bool IsEmpty()
    {
        return !currentBrick;
    }

    public void ChangeContent(Brick brick)
    {
        currentBrick = brick;
        Debug.Log("My content was changed");
    }
}

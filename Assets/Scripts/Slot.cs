using UnityEngine;

public class Slot : MonoBehaviour, IPlaceable
{
    [SerializeField] private SpriteRenderer _spriteRenderer;

    public void Place(Brick brick)
    {
        _spriteRenderer.sprite = brick.sprite;
        var currentRoad = GameManager.Instance.currentRoad;
        currentRoad[GameManager.Instance.currentRoadSize++] = transform.localPosition;
        GameManager.Instance.CheckWinRoad();
        // Debug.Log("Position of the bought slot: " + transform.localPosition);
        // Debug.Log("My content was changed");
    }
}

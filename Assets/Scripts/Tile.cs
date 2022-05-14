using UnityEngine;

public class Tile : MonoBehaviour, IClickable, IHoverable
{
    [SerializeField] private SpriteRenderer spriteRenderer;

    /// <param name="alpha"> takes the value from 0 to 1 </param>
    public void SetTransparency(float alpha)
    {
        var transparentColor = spriteRenderer.color;
        transparentColor.a = alpha;
        
        spriteRenderer.color = transparentColor;
    }

    public void Click()
    {
        SetTransparency(0.5f);
        Debug.Log("Senpai clicked me ^_^");
    }

    public void Hover()
    {
        var currentColor = spriteRenderer.color;
        
        SetTransparency(0.85f);

        spriteRenderer.color = currentColor;
    }

    public Vector3 GetPosition()
    {
        return transform.position;
    }
}
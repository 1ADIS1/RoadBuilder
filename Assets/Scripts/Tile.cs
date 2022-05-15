using UnityEngine;

public class Tile : MonoBehaviour
{
    [SerializeField] private SpriteRenderer spriteRenderer;

    private Color _defaultColor;

    public void InitializeTile(float alpha)
    {
        SetTransparency(alpha);
        _defaultColor = spriteRenderer.color;
    }

    /// <param name="alpha"> takes the value from 0 to 1 </param>
    private void SetTransparency(float alpha)
    {
        var transparentColor = spriteRenderer.color;
        transparentColor.a = alpha;
        
        spriteRenderer.color = transparentColor;
    }
    
    private void MultiplyTransparency(float multiplier)
    {
        var transparentColor = spriteRenderer.color;
        transparentColor.a *= multiplier;
        
        spriteRenderer.color = transparentColor;
    }

    private void ResetTransparency()
    {
        spriteRenderer.color = _defaultColor;
    }

    private void OnMouseDown()
    {
        Debug.Log("Senpai clicked me (^_^) ");
        MultiplyTransparency(0.5f);
    }

    private void OnMouseUp()
    {
        Debug.Log("Senpai released the mouse button from me (~_~;) ");
        ResetTransparency();
    }

    private void OnMouseEnter()
    {
        Debug.Log("Senpai hovered me (^_^) ");
        SetTransparency(0.85f);
    }
    
    private void OnMouseExit()
    {
        Debug.Log("Senpai no more hovering me (~_~;) ");
        ResetTransparency();
    }
}
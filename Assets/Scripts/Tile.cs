using UnityEngine;

public class Tile : MonoBehaviour
{
    [SerializeField] private SpriteRenderer spriteRenderer;

    /// <param name="alpha"> takes the value from 0 to 1 </param>
    public void SetTransparency(float alpha)
    {
        var transparentColor = spriteRenderer.color;
        transparentColor.a = alpha;
        
        spriteRenderer.color = transparentColor;
    }
}
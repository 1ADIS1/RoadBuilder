using System.Collections.Generic;
using UnityEngine;

//TODO: get rid of monobehaviour and introduce Singleton gameManager who will create grid
public class GridManager : MonoBehaviour
{
    // By default, tiles will be spawned with this value
    private const float DefaultTransparency = 1.0f;
    
    [SerializeField] private int rows;
    [SerializeField] private int columns;
    [SerializeField] private GameObject tileToInstantiate;
    
    [SerializeField] private Transform myCamera;
    [SerializeField] private Vector2 offset;

    // Key - position in the world space
    // Value - tile in this coordinates
    private Dictionary<Vector2, Tile> grid;

    private void Start()
    {
        MakeGrid();
        CenterCamera();
    }

    private void MakeGrid()
    {
        grid = new Dictionary<Vector2, Tile>();
        
        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < columns; j++)
            {
                // Fill the grid
                var cellPos = new Vector2(i, j);
                var instantiatedTile = Instantiate(tileToInstantiate, cellPos, Quaternion.identity).GetComponent<Tile>();
                instantiatedTile.InitializeTile(DefaultTransparency);
                instantiatedTile.transform.SetParent(transform);
                
                grid.Add(cellPos, instantiatedTile);
                
                // Make a chessboard color scheme
                if ((i + j) % 2 == 1) instantiatedTile.InitializeTile(0.75f);

                Debug.Log("Tile row: " + i + " Tile column: " + j);
            }
        }
    }

    // TODO: move to camera handler
    private void CenterCamera()
    {
        // If first tile and last tile exist, then center the camera
        
        grid.TryGetValue(new Vector2(0, 0), out var tileFirst);
        grid.TryGetValue(new Vector2(rows - 1, columns - 1), out var tileLast);

        if (!tileFirst || !tileLast) return;
        myCamera.position = new Vector3(
            (tileFirst.transform.position.x + tileLast.transform.position.x) / 2 + offset.x, 
            (tileFirst.transform.position.x + tileLast.transform.position.x) / 2 + offset.y, 
            myCamera.position.z);

    }

    public Tile GetTile(int row, int column)
    {
        return grid.TryGetValue(new Vector2(row, column), out var tile) ? tile : null;
    }
}
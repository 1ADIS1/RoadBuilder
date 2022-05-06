using System.Collections.Generic;
using UnityEngine;

//TODO: get rid of monobehaviour and introduce Singleton gameManager who will create grid
public class GridManager : MonoBehaviour
{
    [SerializeField] private int rows;
    [SerializeField] private int columns;
    [SerializeField] private GameObject tileToInstantiate;

    // Key - position in the world space
    // Value - tile in this coordinates
    private Dictionary<Vector2, Tile> grid;

    private void Start()
    {
        MakeGrid();
    }

    private void MakeGrid()
    {
        grid = new Dictionary<Vector2, Tile>();
        
        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < columns; j++)
            {
                var cellPos = new Vector2(i, j);
                var instantiatedTile = Instantiate(tileToInstantiate, cellPos, Quaternion.identity).GetComponent<Tile>();
                
                grid.Add(cellPos, instantiatedTile);
                
                Debug.Log("Tile row: " + i + " Tile column: " + j);
            }
        }
    }

    public Tile GetTile(int row, int column)
    {
        return grid.TryGetValue(new Vector2(row, column), out var tile) ? tile : null;
    }
}
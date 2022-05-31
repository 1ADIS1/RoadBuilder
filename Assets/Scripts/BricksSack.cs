using System;
using System.Collections.Generic;
using UnityEngine;

public class BricksSack : MonoBehaviour
{
    [SerializeField] private Brick brick;
    [SerializeField] private int bricksNumber;
    
    [SerializeField] private int rows;
    [SerializeField] private int columns;

    public Dictionary<Vector2, Brick> currentBricks;

    public Action<Brick> OnBrickCreation;
    
    private static BricksSack Instance { get; set; }

    private void Awake()
    {
        if (Instance == null) Instance = this;
        else Destroy(this);
        
        DontDestroyOnLoad(this);

        if (rows > columns) MakeHorizontalGrid();
        else MakeVerticalGrid();
    }

    private void MakeVerticalGrid()
    {
        var sackSize = currentBricks.Count;
        
        for (int m = 0; m < rows; m++)
        {
            for (int n = 0; n < columns; n++)
            {
                if (sackSize >= bricksNumber || sackSize >= rows * columns) return;

                CreateBrick();
                // PositionBrick(sackSize - 1, m, n);
            }
        }
    }

    private void MakeHorizontalGrid()
    {
        for (int n = 0; n < columns; n++)
        {
            for (int m = 0; m < rows; m++)
            {
                if (currentBricks.Count >= bricksNumber || currentBricks.Count >= rows * columns) return;
                CreateBrick();
                // PositionBrick(currentBricks.Count - 1, m, n);
            }
        }
    }

    public void CreateBrick()
    {
        var spawnedBrick = Instantiate(brick, transform.position, Quaternion.identity);
        spawnedBrick.transform.SetParent(transform, true);

        OnBrickCreation?.Invoke(spawnedBrick);
    }

    private void AddBrickToSack(Brick newBrick)
    {
        currentBricks.Add(new Vector2(), newBrick);
    }

    private void PositionBrick(int row, int column)
    {
        Vector2 brickPosition = new Vector2(row, column);
        currentBricks[brickPosition].gameObject.transform.localPosition = brickPosition;
        // currentBricks[brickPosition] = brickToPosition;
    }
}

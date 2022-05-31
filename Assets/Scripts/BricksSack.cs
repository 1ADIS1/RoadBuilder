using System;
using System.Collections.Generic;
using UnityEngine;

public class BricksSack : MonoBehaviour
{
    public Dictionary<Vector2, Brick> brickSack;
    public Action<Brick> OnBrickCreation;

    [SerializeField] private int maxColumns;
    private int _row;
    private int _column;
    
    public static BricksSack instance = null;

    private void Awake()
    {
        if (instance == null) instance = this;
        else Destroy(this);
        
        DontDestroyOnLoad(this);
        brickSack = new Dictionary<Vector2, Brick>();
    }

    public void CreateBrick(Brick brick)
    {
        var spawnedBrick = Instantiate(brick, transform.position, Quaternion.identity).GetComponent<Brick>();
        spawnedBrick.transform.SetParent(transform, true);

        var gridPosition = _column <= maxColumns ? 
            new Vector2(_column++, _row) : 
            new Vector2(_column, _row++);

        spawnedBrick.transform.localPosition = Vector3.one;
        spawnedBrick.gridPosition = gridPosition;
        brickSack.Add(gridPosition, spawnedBrick);

        OnBrickCreation?.Invoke(spawnedBrick);
    }

    public void RemoveBrick(Vector2 localPosition)
    {
        Debug.Log(localPosition);
        foreach (var t in brickSack)
        {
            Debug.Log(t);
        }
        
        if (brickSack.ContainsKey(localPosition))
        {
            Debug.Log("Destroying..");

            Brick brick = brickSack[localPosition];
            brickSack.Remove(localPosition);
            Destroy(brick.gameObject);
            Debug.Log($"The tile {localPosition} was destroyed");
        }
    }
}
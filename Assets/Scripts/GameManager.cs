using System;
using TMPro;
using UnityEngine;

// Pattern used: Singleton
public class GameManager : MonoBehaviour
{
    public int currentMoney;
    [SerializeField] private TextMeshProUGUI _tmPro;

    [SerializeField] private RoadCollection _roadCollection;

    public Vector2[] winRoad;
    public Vector2[] currentRoad;
    public int currentRoadSize;

    public Action OnBrickBought;
    
    public static GameManager Instance { get; private set; }

    //Audio stuff...

    private void Awake()
    {
        if (Instance == null) Instance = this;
        else Destroy(this);

        DontDestroyOnLoad(this);

        ChangeMoneyDisplay();
        OnBrickBought += ChangeMoneyDisplay;
    }

    public Vector3 GetMousePositionInWorld(float zComponent)
    {
        if (Camera.main == null) return Vector3.zero;
        var mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePosition.z = zComponent;

        return mousePosition;
    }
    
    public bool CanSpendMoney(int amount)
    {
        return (Instance.currentMoney - amount) >= 0;
    }

    public void ChangeMoneyDisplay()
    {
        _tmPro.text = $"Money: {Instance.currentMoney}$";
    }

    public void BuyRoad(int money)
    {
        if (!CanSpendMoney(money)) return; 
        
        BricksSack.instance.CreateBrick(_roadCollection.GetRoadEntry(money).brick);
        Instance.currentMoney -= money;
        
        OnBrickBought?.Invoke();
    }

    public void CheckWinRoad()
    {
        currentRoad = Vector2Sort(currentRoad);
        
        for (int i = 1; i < currentRoad.Length; i++)
        {
            if (currentRoad[i - 1].x == currentRoad[i].x)
            {
                if (currentRoad[i - 1].y - 1 == currentRoad[i].y ||
                    currentRoad[i - 1].y + 1 == currentRoad[i].y)
                {
                    if (currentRoad[0] == winRoad[0] && currentRoad[currentRoad.Length] == winRoad[winRoad.Length])
                    {
                        Debug.Log("You've won!");
                        return;
                    }
                }
            }

            if (currentRoad[i - 1].y == currentRoad[i].y)
            {
                if (currentRoad[i - 1].x - 1 == currentRoad[i].x ||
                    currentRoad[i - 1].x + 1 == currentRoad[i].x)
                {
                    if (currentRoad[0] == winRoad[0] && currentRoad[currentRoad.Length] == winRoad[winRoad.Length])
                    {
                        Debug.Log("You've won!");
                        return;
                    }
                }
            }
        }
    }

    private Vector2[] Vector2Sort(Vector2[] myArray)
    {
        Vector2 somethingHigh = Vector2.one*1000000;
        Vector2[] answerArray = new Vector2[myArray.Length];
        
        for(int i = 0; i < myArray.Length; i++)
        {
            for(int j = i; j < myArray.Length; j++)
            {
                if(myArray[i].x < somethingHigh.x && myArray[i].y < somethingHigh.y)
                    somethingHigh = myArray[i];
            }

            answerArray[i] = somethingHigh;
        }

        return answerArray;
    }
}
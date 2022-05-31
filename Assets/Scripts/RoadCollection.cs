using System;
using System.Linq;
using UnityEngine;

// All type of roads will be contained here
[Serializable]
class RoadCollection
{
    [SerializeField] private RoadEntry[] roadCollection; 
    
    public RoadEntry GetRoadEntry(int cost)
    {
        return roadCollection.First(entry => entry.money == cost);
    }
}
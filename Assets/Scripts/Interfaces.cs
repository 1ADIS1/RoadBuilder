using UnityEngine;

// S.O.L.I.D principle : interface segregation

interface IPlaceable
{
    void ChangeContent(Brick brick);
}
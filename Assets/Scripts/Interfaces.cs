using UnityEngine;

// S.O.L.I.D principle : interface segregation

internal interface IActionReset
{
    void Reset();
}

internal interface IClickable : IActionReset
{
    // void Click();
}

internal interface IHoverable : IActionReset
{
    // void Hover();
    Vector3 GetPosition();
}
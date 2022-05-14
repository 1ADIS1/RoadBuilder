using UnityEngine;

internal interface IClickable
{
    void Click();
}

internal interface IHoverable
{
    void Hover();
    Vector3 GetPosition();
}
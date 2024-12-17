using System;
using UnityEngine;

/// <summary>
/// Interface for possible view in our "game".
/// </summary>
public interface IView
{
    event Action<Vector2> OnClickScreen;
}

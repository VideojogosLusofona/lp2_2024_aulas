using UnityEngine;

/// <summary>
/// Interface for classes that control how game objects are created.
/// </summary>
public interface IGameObjectFactory
{
    /// <summary>
    /// Create a new game object.
    /// </summary>
    /// <returns>A new game object.</returns>
    public GameObject Create();
}

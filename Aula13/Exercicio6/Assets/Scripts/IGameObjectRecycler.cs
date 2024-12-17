using UnityEngine;

/// <summary>
/// Interface for classes that control how game objects are destroyed.
/// </summary>
public interface IGameObjectRecycler
{
    /// <summary>
    /// Remove a game object.
    /// </summary>
    /// <param name="gameObject">Game object to remove.</param>
    public void Remove(GameObject gameObject);
}

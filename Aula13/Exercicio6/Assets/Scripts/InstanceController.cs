using UnityEngine;
using UnityEngine.Pool;

/// <summary>
/// Controls how a game object is created and removed. In particular, it
/// leverages the Unity-provided object pool class for this purpose.
/// </summary>
/// <remarks>
/// Since this class performs two functions, one might say that it breaks the
/// Single Responsibility Principle. However, given the two functions (creation
/// and destruction of game objects) are tightly related, and that they're so
/// simple, we end up promoting the KISS principle by keeping them together in
/// one class.
/// Note that this design also promotes the interface segregation principle,
/// since the creation and destruction behaviour is defined in different
/// interfaces.
/// </remarks>
public class InstanceController : MonoBehaviour, IGameObjectFactory, IGameObjectRecycler
{
    [SerializeField] private int initPoolSize;
    [SerializeField] private GameObject prefab;

    private IObjectPool<GameObject> pool;

    private void Awake()
    {
        // Unity's object pool is generic and configured through delegates
        pool = new ObjectPool<GameObject>(
            () => Instantiate(prefab, transform), // How to create new objects
            obj => obj.SetActive(true),  // What to do when getting one from the pool
            obj => obj.SetActive(false), // What to do when returning one to the pool
            Destroy, // What to do to objects when pool is over its max size
            defaultCapacity: initPoolSize);
    }

    /// <summary>
    /// Creates a new game object from the configured prefab. We make it
    /// virtual so that possible derived classes can customize this behaviour.
    /// </summary>
    /// <returns>A new game object.</returns>
    public virtual GameObject Create() => pool.Get();

    /// <summary>
    /// Removes a game object from the scene by sending it to an object pool
    /// The method is virtualso that possible derived classes can customize this
    /// behaviour.
    /// </summary>
    /// <param name="obj">Game object to remove.</param>
    public virtual void Remove(GameObject obj) => pool.Release(obj);
}

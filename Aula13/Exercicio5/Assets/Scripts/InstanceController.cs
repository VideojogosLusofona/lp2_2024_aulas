using UnityEngine;

/// <summary>
/// Controls how a game object is created and removed. In particular, it uses
/// a prefab for object creation and leverages an object tool for object
/// removal.
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
    [SerializeField] private GameObject prefab;

    private ObjectPool pool;

    private void Awake()
    {
        pool = GetComponent<ObjectPool>();
    }

    /// <summary>
    /// Creates a new game object from the configured prefab. We make it
    /// virtual so that possible derived classes can customize this behaviour.
    /// </summary>
    /// <returns>A new game object.</returns>
    public virtual GameObject Create()
    {
        return Instantiate(prefab, transform);
    }

    /// <summary>
    /// Removes a game object from the scene by sending it to an object pool
    /// The method is virtualso that possible derived classes can customize this
    /// behaviour.
    /// </summary>
    /// <param name="gameObject">Game object to remove.</param>
    public virtual void Remove(GameObject gameObject)
    {
        pool.ReturnToPool(gameObject);
    }
}

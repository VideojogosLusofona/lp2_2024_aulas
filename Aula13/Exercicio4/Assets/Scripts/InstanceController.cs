using UnityEngine;

/// <summary>
/// Controls how a game object is created and removed. In particular, it uses
/// a prefab for object creation and destroys the object when it's no longer
/// necessary.
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

    /// <summary>
    /// Creates a new game object from the configured prefab. We make it
    /// virtual so that possible derived classes can customize this behaviour.
    /// </summary>
    /// <returns>A new game object.</returns>
    public virtual GameObject Create()
    {
        GameObject newObject = Instantiate(prefab, transform);

        // Is the CircleModel script instance the same as in the original prefab?
        bool sameScript =
            prefab.GetComponent<CircleModel>()
            ==
            newObject.GetComponent<CircleModel>();

        Debug.Log($"Same script instance? {sameScript}");

        // Is the sprite object the same as in the original prefab?
        bool sameSprite =
            prefab.GetComponent<SpriteRenderer>().sprite
            ==
            newObject.GetComponent<SpriteRenderer>().sprite;

        Debug.Log($"Same sprite instance? {sameSprite}");

        return newObject;
    }

    /// <summary>
    /// Removes a game object from the scene by sending it to an object pool
    /// The method is virtualso that possible derived classes can customize this
    /// behaviour.
    /// </summary>
    /// <param name="gameObject">Game object to remove.</param>
    public virtual void Remove(GameObject gameObject)
    {
        Destroy(gameObject);
    }
}

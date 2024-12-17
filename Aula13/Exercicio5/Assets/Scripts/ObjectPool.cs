using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// A general object pool for Unity game objects.
/// </summary>
public class ObjectPool : MonoBehaviour
{
    // Initial number of objects in the pool
    [SerializeField] private uint initPoolSize;

    // A stack is the simplest collection we can use for an object pool
    private Stack<GameObject> pool;

    // The game object factory creates new game objects when necessary
    private IGameObjectFactory factory;

    private void Awake()
    {
        // Find a game object factory
        factory = GetComponent<IGameObjectFactory>();
    }

    private void Start()
    {
        // Initialize the stack, which will be our actual pool
        pool = new Stack<GameObject>();

        // Add the initial number of objects to the pool
        for (int i = 0; i < initPoolSize; i++)
        {
            // Create a new game object (that's the responsibility of the game
            // object factory)
            GameObject newGameObject = factory.Create();

            // Deactivate the game object and keep it in the pool, ready to be
            // used when necessary
            newGameObject.SetActive(false);
            pool.Push(newGameObject);
        }
    }

    /// <summary>
    /// Get an object from the pool.
    /// </summary>
    /// <returns>A ready-to-use game object.</returns>
    public GameObject GetFromPool()
    {
        GameObject gameObject;

        if (pool.Count == 0)
        {
            // If there are no objects left in the pool, create a new one
            gameObject = factory.Create();
        }
        else
        {
            // Otherwise just get an object from the pool and activate it
            gameObject = pool.Pop();
            gameObject.SetActive(true);
        }
        return gameObject;
    }

    /// <summary>
    /// Return a game object to the pool.
    /// </summary>
    /// <param name="gameObject">Game object to return to the pool.</param>
    public void ReturnToPool(GameObject gameObject)
    {
        // Deactivate it and return it to the pool
        gameObject.SetActive(false);
        pool.Push(gameObject);
    }
}

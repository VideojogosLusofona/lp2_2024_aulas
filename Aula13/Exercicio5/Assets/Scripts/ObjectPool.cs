using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// A general object pool for Unity game objects.
/// </summary>
public class ObjectPool : MonoBehaviour, IGameObjectFactory, IGameObjectRecycler
{
    // The prefab from which new game objects will be created
    [SerializeField] private GameObject prefab;

    // Initial number of objects in the pool
    [SerializeField] private uint initPoolSize;

    // A stack is the simplest collection we can use for an object pool
    private Stack<GameObject> pool;

    private void Start()
    {
        // Initialize the stack, which will be our actual pool
        pool = new Stack<GameObject>();

        // Add the initial number of objects to the pool
        for (int i = 0; i < initPoolSize; i++)
        {
            // Create a new game object (that's the responsibility of the game
            // object factory)
            GameObject newGameObject = ActualCreate();

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
    public GameObject Create()
    {
        GameObject gameObject;

        if (pool.Count == 0)
        {
            // If there are no objects left in the pool, create a new one
            gameObject = ActualCreate();
        }
        else
        {
            // Otherwise just get an object from the pool and activate it
            gameObject = pool.Pop();
            gameObject.SetActive(true);
        }
        return gameObject;
    }

    // This method will actually create game objects when necessary
    private GameObject ActualCreate()
    {
        return Instantiate(prefab, transform);
    }

    /// <summary>
    /// Return a game object to the pool.
    /// </summary>
    /// <param name="gameObject">Game object to return to the pool.</param>
    public void Remove(GameObject gameObject)
    {
        // Deactivate it and return it to the pool
        gameObject.SetActive(false);
        pool.Push(gameObject);
    }
}

using UnityEngine;

/// <summary>
/// Master controller for our "game". The pupper master. Pulls the strings.
/// </summary>
public class MasterController : MonoBehaviour
{
    private IView view;

    private IGameObjectFactory factory;

    private void Awake()
    {
        view = GetComponentInChildren<IView>();
        factory = GetComponent<IGameObjectFactory>();
    }

    private void OnEnable()
    {
        view.OnClickScreen += Paint;
    }

    private void OnDisable()
    {
        view.OnClickScreen -= Paint;
    }

    // Action to take when the view notifies us that the user clicked somewhere
    // on the screen
    private void Paint(Vector2 pos)
    {
        // Place a circle where the user clicked
        GameObject circle = factory.Create();
        circle.transform.position = pos;
    }
}

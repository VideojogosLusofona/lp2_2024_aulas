using UnityEngine;

/// <summary>
/// Master controller for our "game". The pupper master. Pulls the strings.
/// </summary>
public class MasterController : MonoBehaviour
{
    [SerializeField] GameObject prefab;

    private IView view;

    private void Awake()
    {
        view = GetComponentInChildren<IView>();
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
        GameObject circle = Instantiate(prefab, transform);
        circle.transform.position = pos;
    }
}

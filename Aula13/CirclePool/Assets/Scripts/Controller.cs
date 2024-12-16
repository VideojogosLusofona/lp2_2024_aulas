using UnityEngine;

public class Controller : MonoBehaviour
{
    private CirclePool circlePool;
    private View view;

    private void Awake()
    {
        view = GetComponentInChildren<View>();
        circlePool = GetComponent<CirclePool>();
    }

    private void OnEnable()
    {
        view.Clicked += Paint;
    }

    private void OnDisable()
    {
        view.Clicked -= Paint;
    }

    private void Paint(Vector2 pos)
    {
        GameObject circle = circlePool.GetCircle();
        circle.transform.position = pos;
    }
}

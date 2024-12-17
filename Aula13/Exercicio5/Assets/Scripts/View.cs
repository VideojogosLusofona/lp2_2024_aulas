using System;
using UnityEngine;

/// <summary>
/// The main view for our "game".
/// </summary>
public class View : MonoBehaviour, IView
{
    public event Action<Vector2> OnClickScreen;

    private void Start()
    {
        Camera.main.backgroundColor = Color.black;
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            // If the user clicked on the screen, determine that position in
            // world coordinates and notify listeners so they may take some
            // action
            Vector2 pos = Input.mousePosition;
            pos = Camera.main.ScreenToWorldPoint(pos);
            OnClickScreen?.Invoke(pos);
        }
    }
}

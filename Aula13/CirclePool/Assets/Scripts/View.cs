using System;
using UnityEngine;

public class View : MonoBehaviour
{
    public event Action<Vector2> Clicked;

    // Update is called once per frame
    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector2 pos = Input.mousePosition;
            Debug.Log(pos);
            pos = Camera.main.ScreenToWorldPoint(pos);
            Clicked?.Invoke(pos);
        }
    }
}

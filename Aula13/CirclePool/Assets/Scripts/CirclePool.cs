using System.Collections.Generic;
using UnityEngine;

public class CirclePool : MonoBehaviour
{
    [SerializeField] private GameObject circlePrefab;
    [SerializeField] private uint initPoolSize;

    private Stack<GameObject> circles;

    private void Start()
    {
        circles = new Stack<GameObject>();
        for (int i = 0; i < initPoolSize; i++)
        {
            GameObject newCircle = CreateCircle();
            newCircle.SetActive(false);
            circles.Push(newCircle);
        }
    }

    public GameObject GetCircle()
    {
        GameObject circle;
        if (circles.Count == 0)
        {
            circle = CreateCircle();
            return circle;
        }
        circle = circles.Pop();
        circle.SetActive(true);
        return circle;
    }

    private GameObject CreateCircle()
    {
        GameObject circle = Instantiate(circlePrefab);
        circle.GetComponent<CircleController>().SetPool(this);
        return circle;
    }

    public void ReturnToPool(GameObject circle)
    {
        circle.SetActive(false);
        circles.Push(circle);
    }
}

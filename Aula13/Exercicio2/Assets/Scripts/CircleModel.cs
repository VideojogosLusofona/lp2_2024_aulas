using System.Collections;
using UnityEngine;

/// <summary>
/// Defines the behaviour of a circle.
/// </summary>
public class CircleModel : MonoBehaviour
{
    [SerializeField] private float minTime = 1f;
    [SerializeField] private float maxTime = 10f;

    private void Start()
    {
        StartCoroutine(SetDeadline());
    }

    private IEnumerator SetDeadline()
    {
        float timeToLive = Random.Range(minTime, maxTime);
        yield return new WaitForSeconds(timeToLive);
        Destroy(gameObject);
    }
}

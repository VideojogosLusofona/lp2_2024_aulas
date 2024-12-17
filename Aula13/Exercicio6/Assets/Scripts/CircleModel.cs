using System.Collections;
using UnityEngine;

/// <summary>
/// Defines the behaviour of a circle.
/// </summary>
public class CircleModel : MonoBehaviour
{
    [SerializeField] private float minTime = 1f;
    [SerializeField] private float maxTime = 10f;

    private IGameObjectRecycler recycler;
    private IEnumerator deadline;

    private void Awake()
    {
        recycler = GetComponentInParent<IGameObjectRecycler>();
    }

    private void OnEnable()
    {
        deadline = SetDeadline();
        StartCoroutine(deadline);
    }

    private void OnDisable()
    {
        StopCoroutine(deadline);
    }

    private IEnumerator SetDeadline()
    {
        float timeToLive = Random.Range(minTime, maxTime);
        yield return new WaitForSeconds(timeToLive);
        recycler.Remove(gameObject);
    }
}

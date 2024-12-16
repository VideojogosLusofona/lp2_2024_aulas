using System.Collections;
using UnityEngine;

public class CircleController : MonoBehaviour
{
    [SerializeField] private float minTime = 1f;
    [SerializeField] private float maxTime = 20f;

    private CirclePool circlePool;

    private void Start()
    {
        StartCoroutine(Die());
    }

    public void SetPool(CirclePool pool) => circlePool = pool;

    // Update is called once per frame
    private IEnumerator Die()
    {
        float timeToLive = Random.Range(minTime, maxTime);
        yield return new WaitForSeconds(timeToLive);
        circlePool.ReturnToPool(gameObject);
    }
}

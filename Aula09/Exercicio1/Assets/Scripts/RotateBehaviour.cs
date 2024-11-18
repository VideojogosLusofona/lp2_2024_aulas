using UnityEngine;

public class RotateBehaviour : MonoBehaviour, IAnimateBehaviour
{
    [SerializeField]
    private float rotateSpeed = 20f;

    // Update is called once per frame
    public void Animate()
    {
        Vector3 rotator = rotateSpeed * Time.deltaTime * Vector3.one;
        transform.Rotate(rotator);
    }
}

using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    private Vector3 offset = new Vector3(0f, 0f, -10f);
    private float smoothTime = 0.25f;
    private Vector3 velocity = Vector3.zero;
    private static bool tracking = true;

    public Transform target;

    // Update is called once per frame
    void Update()
    {
        if (tracking)
        {
            Vector3 targetPosition = target.position + offset;
            transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref velocity, smoothTime);
        } else
        {
            transform.position = transform.position;
        }
    }
}

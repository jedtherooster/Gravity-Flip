using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    private Vector3 offset = new Vector3(0f, 0f, -10f);
    private float smoothTime = 0.25f;
    private Vector3 velocity = Vector3.zero;

    public static bool tracking = true;
    public static Vector3 stopAtPosition;
    public static bool shouldStopAtTarget = false;


    public Transform target;

    public static CameraFollow instance;

    void Awake()
    {
        instance = this;
    }

    public void SetTarget(Transform newTarget)
    {
        target = newTarget;
    }


    // Update is called once per frame
    void Update()
    {
        if (tracking && target != null)
        {
            Vector3 targetPosition = target.position + offset;
            transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref velocity, smoothTime);

            // Check if we're supposed to stop at a specific position
            if (shouldStopAtTarget)
            {
                float distance = Vector2.Distance(new Vector2(transform.position.x, transform.position.y), new Vector2(stopAtPosition.x, stopAtPosition.y));
                if (distance < 0.1f) 
                {
                    tracking = false;
                    shouldStopAtTarget = false;
                }
            }
        }
    }
}

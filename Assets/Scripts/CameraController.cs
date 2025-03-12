using UnityEngine;

public class CameraController : MonoBehaviour
{
    Transform target;
    Vector3 velocity = Vector3.zero;

    [Range(0, 1)]
    public float smoothTime;

    public Vector3 positionOffset;

    private bool isCameraLocked = false;  
    private Vector3 lockedPosition;       

    private void Awake()
    {
        target = GameObject.FindGameObjectWithTag("Player").transform;
    }

    private void LateUpdate()
    {
        if (isCameraLocked)
        {
            transform.position = lockedPosition;  
        }
        else
        {
            Vector3 targetPosition = target.position + positionOffset;
            transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref velocity, smoothTime);
        }
    }

    public void LockCamera(Vector3 newPosition)
    {
        isCameraLocked = true;
        lockedPosition = newPosition;  
    }

 

   
}
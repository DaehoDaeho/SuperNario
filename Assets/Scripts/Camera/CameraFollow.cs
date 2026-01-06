using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;

    public Vector3 offset = new Vector3(0.0f, 0.0f, -10.0f);

    void LateUpdate()
    {
        if(target == null)
        {
            return;
        }

        Vector3 targetPosition = target.position + offset;

        transform.position = targetPosition;
    }
}

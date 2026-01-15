using UnityEngine;

public class CameraDeadZoneFollow : MonoBehaviour
{
    [SerializeField]
    private Transform target;

    [SerializeField]
    private float deadzoneHalfWidth = 2.0f; // 좌우로 허용되는 범위.

    [SerializeField]
    private float deadzoneHalfHeight = 1.0f;

    [SerializeField]
    private float followSpeed = 6.0f;

    [SerializeField]
    private float cameraZ = -10.0f;

    void LateUpdate()
    {
        if(target == null)
        {
            return;
        }

        float diffX = target.position.x - transform.position.x;
        float diffY = target.position.y - transform.position.y;

        float targetCamX = transform.position.x;
        float targetCamY = transform.position.y;

        if(diffX > deadzoneHalfWidth)
        {
            targetCamX = target.position.x - deadzoneHalfWidth;
        }
        else if(diffX < -deadzoneHalfWidth)
        {
            targetCamX = target.position.x + deadzoneHalfWidth;
        }

        if(diffY > deadzoneHalfHeight)
        {
            targetCamY = target.position.y - deadzoneHalfHeight;
        }
        else if(diffY < -deadzoneHalfHeight)
        {
            targetCamY = target.position.y + deadzoneHalfHeight;
        }

        float lerpT = followSpeed * Time.deltaTime;

        float newX = Mathf.Lerp(transform.position.x, targetCamX, lerpT);
        float newY = Mathf.Lerp(transform.position.y, targetCamY, lerpT);

        transform.position = new Vector3(newX, newY, cameraZ);
    }
}

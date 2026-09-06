using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;
    public float smoothSpeed = 5f;

    void LateUpdate()
    {
        if (target == null)
            return;

        Vector3 targetPosition = new Vector3(
            target.position.x,
            transform.position.y,
            transform.position.z
        );

        transform.position = Vector3.Lerp(
            transform.position,
            targetPosition,
            smoothSpeed * Time.deltaTime
        );
    }
}
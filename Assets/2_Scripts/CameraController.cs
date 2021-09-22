using UnityEngine;

public class CameraController : MonoBehaviour
{
    Vector3 initialPos;

    public Transform target;

    private Vector3 offset;

    private void Start()
    {
        initialPos = transform.position;

        offset = initialPos - target.position;
    }

    private void LateUpdate()
    {
        transform.position = new Vector3(transform.position.x, initialPos.y, target.position.z + offset.z);
    }
}
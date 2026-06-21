using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform target;              // the ball
    public float followDistance = 5f;    // how far behind
    public float height = 2f;            // camera height above the ball
    public float smoothing = 10f;         // higher = snappier

    private Rigidbody rigid;
    void Start()
    {
        rigid = target.GetComponent<Rigidbody>();
    }
    void LateUpdate()
    {
        if (rigid == null) return;

        Vector3 v = rigid.linearVelocity;

        Vector3 backDir;
        if (v.sqrMagnitude > 0.01f)
            backDir = -v.normalized;   // behind where it’s moving
        else
            backDir = -target.forward; // fallback

        Vector3 desiredPos = target.position + backDir * followDistance + Vector3.up * height;

        transform.position = Vector3.Lerp(transform.position, desiredPos, smoothing * Time.deltaTime);
        transform.LookAt(target.position);
    }
}

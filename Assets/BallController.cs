using UnityEngine;
using System.Collections;

public class BallController : MonoBehaviour
{
    public float speed;
    public float turnSpeed =180f;
    private Rigidbody rigid;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rigid = gameObject.GetComponent<Rigidbody>();
        rigid.freezeRotation = true; 
    }

    // Update is called once per frame
    void FixedUpdate()
    {
         
        float w = Input.GetAxisRaw("Vertical");   // W=+1, S=-1
        float turn = Input.GetAxisRaw("Horizontal"); // A=-1, D=+1

        // turn left orright
        if (Mathf.Abs(turn) > 0.01f)
        {
            float yaw = turn * turnSpeed * Time.fixedDeltaTime;
            rigid.MoveRotation(rigid.rotation * Quaternion.Euler(0f, yaw, 0f));
        }

        // move forward and back in the facing direction
        Vector3 forward = transform.forward;
        Vector3 force = forward * (w * speed - rigid.linearVelocity.magnitude * 0f);

        rigid.AddForce(force, ForceMode.Acceleration);
    }
}

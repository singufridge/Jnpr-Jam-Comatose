using UnityEngine;
using System.Collections;

public class BallController : MonoBehaviour
{
    public float speed;
    public float topSpeed = 350f;
    public float turnSpeed =180f;
    public float accelerationSpeed;
    public float newSpeed;

    //points
    public float points;
    public float totalPoints;
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

        // move forward 
        Vector3 forward = transform.forward;
        float targetSpeed = w * topSpeed; // topSpeed is max in either direction
        float currentSpeed = Vector3.Dot(rigid.linearVelocity, forward); // speed along facing direction

        // Accelerate
        float accel = (Mathf.Abs(w) > 0.01f) ? accelerationSpeed : 0f;

        newSpeed = Mathf.MoveTowards(currentSpeed, targetSpeed, accel * Time.fixedDeltaTime);

        // Apply force to reach the newSpeed going forward
        Vector3 velChange = forward * (newSpeed - currentSpeed);
        rigid.AddForce(velChange, ForceMode.VelocityChange);
    }

    /*public void PointsCalc()
    {
        points = points + newSpeed;
        Debug.Log(points);
    }*/
}

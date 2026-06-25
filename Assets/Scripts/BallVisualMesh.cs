using UnityEngine;
using System.Collections;

public class BallVisualMesh : MonoBehaviour
{
    [SerializeField] private Rigidbody playerObject; //to grab the velocity from the Player ball
    [SerializeField] private float ballRadius = 0.5f;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (playerObject == null) return;

        Vector3 velocity = playerObject.linearVelocity; //the velocity from the Player ball!

        float speed = velocity.magnitude; //movement speed

        if (speed > 0.01f) //rotates ball only. pointing up emoji. if player is moving
        {
            float angle = (speed * Time.deltaTime / ballRadius) * Mathf.Rad2Deg; //Mathf.Rad2Deg converts math value into usable degrees

            Vector3 rotationAxis = Vector3.Cross(Vector3.up, velocity).normalized; //rotation axis

            transform.Rotate(rotationAxis, angle, Space.World); //rotates mesh
        }
    }
}

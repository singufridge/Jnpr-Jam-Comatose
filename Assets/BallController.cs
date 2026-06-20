using UnityEngine;

public class BallController : MonoBehaviour
{
    public float speed;
    private Rigidbody rigid;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rigid = gameObject.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetAxis("Horizontal")> 0)
        {
            rigid.AddForce(Vector3.right * speed);
        }
        else if (Input.GetAxis("Horizontal")<0)
        {
            rigid.AddForce(-Vector3.right * speed);
        }
        if (Input.GetAxis("Vertical") > 0)
        {
            rigid.AddForce(Vector3.forward * speed);
        }
        else if (Input.GetAxis("Vertical") <0)
        {
            rigid.AddForce(-Vector3.forward *speed);
        }
    }
}

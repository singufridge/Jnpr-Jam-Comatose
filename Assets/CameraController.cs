using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform target;//player
    private Vector3 offSet;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        offSet = transform.position - target.position;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(target.position.x + offSet.x, target.position.y + offSet.y, target.position.z + offSet.z );
    }
}

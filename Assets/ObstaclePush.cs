using UnityEngine;

public class ObstaclePush : MonoBehaviour
{
    [SerializeField]
    private float forceMagnetude;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        Rigidbody rigid = hit.collider.attachedRigidbody;

        if(rigid !=null)
        {
            Vector3 forceDirection = hit.gameObject.transform.position = transform.position;
            forceDirection.y = 0;
            forceDirection.Normalize();

            rigid.AddForceAtPosition(forceDirection * forceMagnetude, transform.position, ForceMode.Impulse);
        }
    }
}

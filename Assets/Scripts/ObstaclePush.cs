using UnityEngine;

public class ObstaclePush : MonoBehaviour
{
    [SerializeField]
    private float forceMagnetude;
    public float pointsPerImpulse = 0.1f;
    public float points =0f;
    public int interactableLayer;
    public BallController ballController;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter(Collision hit)
    {
        if (hit.gameObject.layer != interactableLayer)
        return;
        Rigidbody rigid = hit.collider.attachedRigidbody;
        //ballController.PointsCalc();
        // impulse is how hard the collision is
        //magnetude is a part of impulse and mesures how big the push was
        //if a hit is stronger then hit.impulse gets larger
        float impulse = hit.impulse.magnitude;
        

        if(rigid !=null)
        {
            Vector3 forceDirection = hit.gameObject.transform.position = transform.position;
            forceDirection.y = 0;
            forceDirection.Normalize();
            //points = points +(hit.impulse * pointsPerImpulse)
            rigid.AddForceAtPosition(forceDirection * forceMagnetude, transform.position, ForceMode.Impulse);
            float gained = impulse * pointsPerImpulse;
            points += gained * 100;//multiply to change decimal position

            Debug.Log($"Impulse: {impulse}, +Points: {gained}, Total: {points}");
            
        }
    }
}

using UnityEngine;

public class ObjectHealth : MonoBehaviour
{
    public enum ObjectType
    {
        Solid,
        Squishy,
        Brittle
    }

    [SerializeField] private ObjectType objectType;

    GameManager gameManager;
    BallController playerPhysics;

    private int maxHP;
    private int currentHP;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        //assign refrences
        gameManager = FindFirstObjectByType<GameManager>();
        playerPhysics = GameObject.FindWithTag("Player").GetComponent<BallController>();

        //change max HP depending on object type, take values from the game manager
        if (objectType == ObjectType.Solid)
        {
            maxHP = gameManager.SolidHP;
        }
        else if (objectType == ObjectType.Squishy)
        {
            maxHP = gameManager.SquishyHP;
        }
        else if (objectType == ObjectType.Brittle)
        {
            maxHP = gameManager.BrittleHP;
        }

        //set HP to max by default
        currentHP = maxHP;
    }

    // Update is called once per frame
    void Update()
    {
        //on object death
        if (currentHP <= 0)
        {
            gameManager.objectsBrokenScore += 1;
            Destroy(this.gameObject);
        }
    }
    private void OnCollisionEnter(Collision hit)
    {
        //if obj hit by player, calculate dmg from velocity
        if (hit.gameObject.name == "Player")
        {
            int damage = Mathf.RoundToInt(playerPhysics.currentSpeed);

            if (damage > 0) { currentHP -= damage; }

            Debug.Log($"Hit for: {damage}");
            Debug.Log($"HP Now: {currentHP}");
        }
    }
}

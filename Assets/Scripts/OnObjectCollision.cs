using UnityEngine;

public class OnObjectCollision : MonoBehaviour
{
    GameManager gameManager;
    BallController playerPhysics;

    [SerializeField] private GameManager.ObjectType objectType;

    private int maxHP;
    private int currentHP;

    [SerializeField] private AudioClip onPlayerHitSFX; //sound when player hits
    [SerializeField] private AudioClip collisionSFX; //sound on any collision

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        //assign refrences
        gameManager = FindFirstObjectByType<GameManager>();
        playerPhysics = GameObject.FindWithTag("Player").GetComponent<BallController>();

        //change max HP depending on object type, take values from the game manager
        switch (objectType)
        {
            case GameManager.ObjectType.Solid:
                maxHP = gameManager.SolidHP;
                onPlayerHitSFX = gameManager.onPlayerHitSolidSFX;
                collisionSFX = gameManager.collisionSolidSFX;
                break;

            case GameManager.ObjectType.Squishy:
                maxHP = gameManager.SquishyHP;
                onPlayerHitSFX = gameManager.onPlayerHitBrittleSFX;
                collisionSFX = gameManager.collisionBrittleSFX;
                break;

            case GameManager.ObjectType.Brittle:
                maxHP = gameManager.BrittleHP;
                onPlayerHitSFX = gameManager.onPlayerHitSquishySFX;
                collisionSFX = gameManager.collisionSquishySFX;
                break;
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
            //calculate dmg
            int damage = Mathf.RoundToInt(playerPhysics.currentSpeed);
            if (damage > 0) { currentHP -= damage; }

            //play sound effect
            if (damage > 4 && onPlayerHitSFX != null)
            {
                SoundFXManager.instance.PlaySFXClip(onPlayerHitSFX, transform, 0.2f);
            }

            Debug.Log($"{damage} damage, HP now {currentHP}");
        }
        else if (collisionSFX != null)
        {
            SoundFXManager.instance.PlaySFXClip(collisionSFX, transform, 0.5f);
        }
    }
}

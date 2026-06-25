using UnityEngine;

public class OnObjectCollision : MonoBehaviour
{
    GameManager gameManager;
    UIManager uiManager;
    BallController playerPhysics;

    [Space(10)]
    [Header("Object Type")]
    [SerializeField] private GameManager.ObjectType objectType;

    private int maxHP;
    private int currentHP;

    [Space(10)]
    [SerializeField] private AudioClip onPlayerHitSFX; //sound when player hits
    [SerializeField] private AudioClip collisionSFX; //sound on any collision

    [Space(10)]
    [Header("Destroy Effect Material")]
    private Renderer rend;
    [SerializeField] private Material particleMat;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        //assign refrences
        gameManager = FindFirstObjectByType<GameManager>();
        uiManager = FindFirstObjectByType<UIManager>();
        playerPhysics = GameObject.FindWithTag("Player").GetComponent<BallController>();

        rend = GetComponent<Renderer>();
        if (particleMat == null) { particleMat = rend.material; } //if no material added in inpector, automatically set to object mat

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
                onPlayerHitSFX = gameManager.onPlayerHitSquishySFX;
                collisionSFX = gameManager.collisionSquishySFX;
                break;

            case GameManager.ObjectType.Brittle:
                maxHP = gameManager.BrittleHP;
                onPlayerHitSFX = gameManager.onPlayerHitBrittleSFX;
                collisionSFX = gameManager.collisionBrittleSFX;
                break;
        }

        //set HP to max by default
        currentHP = maxHP;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision hit)
    {
        //if obj hit by player, calculate dmg from velocity
        if (hit.gameObject.name == "Player")
        {
            //calculate dmg
            int damage = Mathf.RoundToInt(playerPhysics.currentSpeed);
            if (damage < 0) { damage *= -1; } //convert neg to pos

            currentHP -= damage;

            //play sound effect
            if (damage > 4 && onPlayerHitSFX != null)
            {
                SoundFXManager.instance.PlaySFXClip(onPlayerHitSFX, transform, 0.2f);
            }

            //update player score
            uiManager.UpdateScore(damage);

            //on object death
            if (currentHP <= 0)
            {
                gameManager.DestroyEffect(particleMat);
                Destroy(gameObject);
            }
        }
        else if (collisionSFX != null)
        {
            SoundFXManager.instance.PlaySFXClip(collisionSFX, transform, 0.5f);
        }
    }
}

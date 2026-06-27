using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnObjectCollision : MonoBehaviour
{
    GameManager gameManager;
    UIManager uiManager;
    BallController playerPhysics;

    private int maxHP;
    private int currentHP;

    private AudioClip playerSFX; //sound when player hits
    private List<AudioClip> collSFX = new List<AudioClip>(); //sound on any collision

    private ParticleSystem onomatPlayer; //onomatopoeia on player hit
    private ParticleSystem onomatColl; //onomat on any collision

    [Space(10)]
    [Header("Object Type")]
    [SerializeField] private GameManager.ObjectType objectType;

    [Space(10)]
    [Header("Destroy Effect Material")]
    private Renderer rend;
    [SerializeField] private Material particleMat;

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
                //hp
                maxHP = gameManager.SolidHP;

                //sfx
                playerSFX = gameManager.playerSolidSFX;
                collSFX.Add(gameManager.collSolidSFX1);
                collSFX.Add(gameManager.collSolidSFX2);

                //onomat effect
                onomatPlayer = gameManager.onomatBam;
                break;

            case GameManager.ObjectType.Squishy:
                //hp
                maxHP = gameManager.SquishyHP;

                //sfx
                playerSFX = gameManager.playerSquishySFX;
                collSFX.Add(gameManager.collSquishySFX1);
                collSFX.Add(gameManager.collSquishySFX2);

                //onomat
                onomatPlayer = gameManager.onomatSquish;
                break;

            case GameManager.ObjectType.Brittle:
                //hp
                maxHP = gameManager.BrittleHP;

                //sfx
                playerSFX = gameManager.playerBrittleSFX;
                collSFX.Add(gameManager.collBrittleSFX1);
                collSFX.Add(gameManager.collBrittleSFX2);

                //onomat
                onomatPlayer = gameManager.onomatCrash;
                break;
        }

        onomatColl = gameManager.onomatThud;

        //set HP to max by default
        currentHP = maxHP;
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

            //IF IMPACT IS HARD ENOUGH
            if (damage > 6)
            {
                //play player sfx
                if (playerSFX != null) { SoundFXManager.instance.PlaySFXClip(playerSFX, transform, 0.2f); }

                //player vfx
                gameManager.OnomatEffect(onomatPlayer);
            }
            else
            {
                //random SFX
                SoundFXManager.instance.PlayRandomSFXClip(collSFX, transform, 1f);
            }

            //update player score
            uiManager.UpdateScore(damage);

            //on object death
            if (currentHP <= 0)
            {
                gameManager.objectList.Remove(gameObject);
                gameManager.DestroyEffect(particleMat);
                Destroy(gameObject);
            }
        }
        else
        {
            //random SFX
            SoundFXManager.instance.PlayRandomSFXClip(collSFX, transform, 1f);

            //onomat thump effect
            ParticleSystem newOnomat = Instantiate(onomatColl, transform);
            newOnomat.Play();
        }
    }
}

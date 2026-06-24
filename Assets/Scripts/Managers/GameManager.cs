using NUnit.Framework;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject player;

    [Header("Object Types Max HP")]
    public int SolidHP = 1;
    public int SquishyHP = 1;
    public int BrittleHP = 1;

    [Header("Object Types Sounds")]
    public AudioClip onPlayerHitSolidSFX;
    public AudioClip collisionSolidSFX;
    public AudioClip onPlayerHitBrittleSFX;
    public AudioClip collisionBrittleSFX;
    public AudioClip onPlayerHitSquishySFX;
    public AudioClip collisionSquishySFX;

    [Header("Destry Object Effect")]
    public ParticleSystem destroyEffect;

    //Object types
    public enum ObjectType
    {
        Solid,
        Squishy,
        Brittle
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //particle effect generator
    public void DestroyEffect(Material mat)
    {
        ParticleSystem newParticles = Instantiate(destroyEffect, player.transform);
        ParticleSystemRenderer effectRend = newParticles.GetComponent<ParticleSystemRenderer>();

        effectRend.material = mat;
        newParticles.Play();

        Debug.Log(player.transform.position);
    }
}

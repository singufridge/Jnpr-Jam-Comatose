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
    [Header("Solid")]
    public AudioClip playerSolidSFX;
    public AudioClip collSolidSFX;
    [Header("Squishy")]
    public AudioClip playerSquishySFX;
    public AudioClip collSquishySFX;
    [Header("Brittle")]
    public AudioClip playerBrittleSFX;
    public AudioClip collBrittleSFX;

    [Header("Particle Effects")]
    public ParticleSystem destroyEffect;
    [Space(5)]
    public ParticleSystem onomatCrash;
    public ParticleSystem onomatThud;
    public ParticleSystem onomatSquish;
    public ParticleSystem onomatBam;

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
    }

    public void OnomatEffect(ParticleSystem onomatSys)
    {
        ParticleSystem newParticles = Instantiate(onomatSys, player.transform);
        newParticles.Play();
    }
}

using NUnit.Framework;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [Header("Player Score")]
    public int objectsDamageScore;

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
}

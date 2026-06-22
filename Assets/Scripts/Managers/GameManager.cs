using NUnit.Framework;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [Header("Player Score")]
    public int objectsBrokenScore;

    [Header("Object Types Max HP")]
    public int SolidHP = 1;
    public int SquishyHP = 1;
    public int BrittleHP = 1;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

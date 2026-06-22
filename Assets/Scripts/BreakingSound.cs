using System.Globalization;
using UnityEngine;

public class BreakingSound : MonoBehaviour
{
    [SerializeField] private AudioClip onBreakSFX;

    //public int isObjBroken = 0;

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
        SoundFXManager.instance.PlaySFXClip(onBreakSFX, transform, 0.5f);
    }
}

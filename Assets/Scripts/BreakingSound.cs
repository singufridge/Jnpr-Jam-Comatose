using UnityEngine;

public class BreakingSound : MonoBehaviour
{
    public AudioSource audioSource;
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
        BreakSound();
    }

    public void BreakSound()
    {
        audioSource.Play();
    }
}

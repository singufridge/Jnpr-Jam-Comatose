using NUnit.Framework;
using System.Globalization;
using UnityEngine;

public class OBSOLETEObjectBreakSFX : MonoBehaviour
{
    [SerializeField] private AudioClip onPlayerHitSFX;
    [SerializeField] private AudioClip collisionSFX;

    BallController playerPhysics;

    void Awake()
    {
        playerPhysics = GameObject.FindWithTag("Player").GetComponent<BallController>();
    }

    private void OnCollisionEnter(Collision hit)
    {
        if (hit.gameObject.name == "Player" && playerPhysics.currentSpeed > 4f)
        {
            SoundFXManager.instance.PlaySFXClip(onPlayerHitSFX, transform, 0.2f);
        }
        else if (collisionSFX != null)
        {
            SoundFXManager.instance.PlaySFXClip(collisionSFX, transform, 0.5f);
        }
    }
}

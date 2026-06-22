using System.Globalization;
using UnityEngine;

public class ObjectBreakSFX : MonoBehaviour
{
    [SerializeField] private AudioClip onBreakSFX;

    [SerializeField] GameManager gameManager;

    private bool playerHasHit = false; //check if player has hit once

    private void OnCollisionEnter(Collision hit)
    {
        SoundFXManager.instance.PlaySFXClip(onBreakSFX, transform, 0.2f);

        //if (hit.gameObject.name == "Player")
        //{
        //    if (!playerHasHit)
        //    {
        //        gameManager.objectsBroken += 3;
        //        Debug.Log(gameManager.objectsBroken);
        //    }
        //}
    }
}

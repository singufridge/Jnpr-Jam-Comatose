using System.Globalization;
using UnityEngine;

public class ObjectBreakSFX : MonoBehaviour
{
    [SerializeField] private AudioClip onBreakSFX;

    private void OnCollisionEnter(Collision hit)
    {
        SoundFXManager.instance.PlaySFXClip(onBreakSFX, transform, 0.2f);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class SoundFXManager : MonoBehaviour
{
    //make object singleton
    public static SoundFXManager instance;

    [SerializeField] private AudioSource soundFXObject;

    //set mixer groups
    public AudioMixerGroup soundFXGroup;
    public AudioMixerGroup musicGroup;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    //use to play a specified sound effect
    public void PlaySFXClip(AudioClip audioClip, Transform spawnTransform, float volume)
    {
        //spawn in gameObject and save instance as audioSource
        AudioSource audioSource = Instantiate(soundFXObject, spawnTransform.position, Quaternion.identity);

        audioSource.clip = audioClip;
        audioSource.volume = volume;
        audioSource.outputAudioMixerGroup = soundFXGroup;

        audioSource.Play();

        float clipLength = audioSource.clip.length;
        Destroy(audioSource.gameObject, clipLength);
    }

    //use to play a random sound effect from an array
    public void PlayRandomSFXClip(List<AudioClip> audioClip, Transform spawnTransform, float volume)
    {
        //assign a random index
        int rand = Random.Range(0, audioClip.Count);
        
        AudioSource audioSource = Instantiate(soundFXObject, spawnTransform.position, Quaternion.identity);

        //assign audioClip @ random int index
        audioSource.clip = audioClip[rand];
        audioSource.volume = volume;

        audioSource.Play();

        float clipLength = audioSource.clip.length;
        Destroy(audioSource.gameObject, clipLength);
    }
}

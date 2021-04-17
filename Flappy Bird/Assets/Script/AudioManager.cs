using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public AudioClip[] clips;
    AudioSource SumberAudio;
    public static AudioManager singleton;

    private void Awake()
    {
        singleton = this;
        SumberAudio = GetComponent<AudioSource>();
    }
    
    public void PlaySound(int clipIndex)
    {
        SumberAudio.PlayOneShot(clips[clipIndex]);
    }
}

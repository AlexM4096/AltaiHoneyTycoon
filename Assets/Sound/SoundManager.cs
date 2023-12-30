using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public AudioClip musicClip;
    private AudioSource musicSource;

    void Awake()
    {
        musicSource = GetComponent<AudioSource>();
        musicSource.clip = musicClip;
        musicSource.Play();

        musicSource.volume = 0.5f;
    }
}

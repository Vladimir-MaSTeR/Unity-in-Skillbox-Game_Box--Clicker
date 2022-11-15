using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundsMenuLevel : MonoBehaviour
{
    [Header("Audio soutces")]
    [SerializeField] private AudioSource _fonAudioSource;

    [Header("Clips")]
    [SerializeField] private AudioClip _fonClips;

    private void Start()
    {
        _fonAudioSource.clip = _fonClips;
        _fonAudioSource.loop = _fonClips;
        _fonAudioSource.Play();
        ;
    }   

}


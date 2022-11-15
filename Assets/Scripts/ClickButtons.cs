using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickButtons : MonoBehaviour
{

    [SerializeField] AudioSource _clickButtonsAudioSource;
    [SerializeField] AudioClip _clip;

    public void Click()
    {
        _clickButtonsAudioSource.PlayOneShot(_clip);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundsInMeargeGameController : MonoBehaviour
{
    [Header("Audio soutces")]
    [SerializeField] private AudioSource _fonAudioSource;
    [SerializeField] private AudioSource _environmentAudioSource;

    [Header("Clips")]
    [SerializeField] private AudioClip[] _fonClips;

    [SerializeField] private AudioClip _scoreClip;
    [SerializeField] private AudioClip _endRoundClip;
    [SerializeField] private AudioClip _noMeargClip;
    [SerializeField] private AudioClip _positivMeargClip;
    [SerializeField] private AudioClip _endDragClip;


    private int _currentIndexFonClip;
    private float _currentSecondClip;

    private void Start()
    {
        _currentSecondClip = 0;

        PlayFonMusic();
    }

    private void Update()
    {
        if (_currentSecondClip <= 0)
        {
            PlayFonMusic();
        } else
        {
            _currentSecondClip -= Time.deltaTime;
        }
    }

    private void OnEnable()
    {
        EventsForMearge.onUpdateScoreTextPlaySound += ScorePlaySound;
        EventsForMearge.onEndRoundTime += EndRoundPlaySound;
        EventsForMearge.onNoMeargeSound += NoMearge;
        EventsForMearge.onPositiveMeargeSound += PositiveMearge;
        EventsForMearge.onEndDragSound += EndDrag;
    }

    private void OnDisable()
    {
        EventsForMearge.onUpdateScoreTextPlaySound -= ScorePlaySound;
        EventsForMearge.onEndRoundTime -= EndRoundPlaySound;
        EventsForMearge.onNoMeargeSound -= NoMearge;
        EventsForMearge.onPositiveMeargeSound -= PositiveMearge;
        EventsForMearge.onEndDragSound -= EndDrag;
    }


    private void PlayFonMusic()
    {
        if (_fonClips.Length > 0)
        {
            _currentIndexFonClip = Random.Range(0, _fonClips.Length);
            _fonAudioSource.clip = _fonClips[_currentIndexFonClip];
            _fonAudioSource.Play();

            _currentSecondClip = _fonAudioSource.clip.length;
            Debug.Log($"Время клипа = {_currentSecondClip}");

        } 
    }

    private void ScorePlaySound()
    {
        _environmentAudioSource.PlayOneShot(_scoreClip);
    }

    private void EndRoundPlaySound()
    {
        _fonAudioSource.Stop();
        _environmentAudioSource.PlayOneShot(_endRoundClip);
    }

    private void NoMearge()
    {
        _environmentAudioSource.PlayOneShot(_noMeargClip);
    }

    private void PositiveMearge()
    {
        _environmentAudioSource.PlayOneShot(_positivMeargClip);
    }

    private void EndDrag()
    {
        _environmentAudioSource.PlayOneShot(_endDragClip);
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundsClickerLevelController : MonoBehaviour
{
    [Header("Audio soutces")]
    [SerializeField] private AudioSource _fonAudioSource;
    [SerializeField] private AudioSource _environmentAudioSource;

    [Header("Clips")]
    [SerializeField] private AudioClip[] _fonClips;

    [SerializeField] private AudioClip _damageClip;
    [SerializeField] private AudioClip _positiveProfitClip;
    [SerializeField] private AudioClip _negativeProfitClip;

    [SerializeField] private AudioClip _pasiveProfit;


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
        }
        else
        {
            _currentSecondClip -= Time.deltaTime;
        }
    }

    private void OnEnable()
    {
        EventClickerController.onDamageClick += Damage;
        EventClickerController.onPositiveUpgrade += PositiveUpgrade;
        EventClickerController.onNegativeUpgrade += NegativeUpgrade;
        EventClickerController.onPasiveProfit += Pasive;

    }

    private void OnDisable()
    {
        EventClickerController.onDamageClick -= Damage;
        EventClickerController.onPositiveUpgrade -= PositiveUpgrade;
        EventClickerController.onNegativeUpgrade -= NegativeUpgrade;
        EventClickerController.onPasiveProfit -= Pasive;

    }


    private void PlayFonMusic()
    {
        if (_fonClips.Length > 0)
        {
            _currentIndexFonClip = Random.Range(0, _fonClips.Length);
            _fonAudioSource.clip = _fonClips[_currentIndexFonClip];
            _fonAudioSource.Play();

            _currentSecondClip = _fonAudioSource.clip.length;
        }
    }

    private void Damage() {
        _environmentAudioSource.PlayOneShot(_damageClip);
    }

    private void PositiveUpgrade()
    {
        _environmentAudioSource.PlayOneShot(_positiveProfitClip);
    }

    private void NegativeUpgrade()
    {
        _environmentAudioSource.PlayOneShot(_negativeProfitClip);
    }

    private void Pasive()
    {
        _environmentAudioSource.PlayOneShot(_pasiveProfit);
    }


}

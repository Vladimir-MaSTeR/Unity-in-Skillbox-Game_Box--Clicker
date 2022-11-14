
using UnityEngine;
using UnityEngine.UI;

public class TimeRoundController : MonoBehaviour
{
    [Header("Text time round")]
    [SerializeField] private Text _timeText;

    [Header("Round time")]
    [SerializeField] private float _timeRound = 180f;


    private float _currentTimeRound;

    private void Start()
    {
        _currentTimeRound = _timeRound;
        _timeText.text = _currentTimeRound.ToString();
    }


    void Update()
    {
        if (_currentTimeRound > 0)
        {
            _currentTimeRound -= Time.deltaTime;
            UpdateTimerText(_currentTimeRound);
        
        } else
        {
            EventsForMearge.onEndRoundTime?.Invoke();
        }
       
       
    }

    private void UpdateTimerText(float time)
    {
        if (time < 0)
        {
            time = 0;
        }

        var minutes = Mathf.FloorToInt(time / 60);
        var seconds = Mathf.FloorToInt(time % 60);
        _timeText.text = string.Format("{0:00} : {1:00}", minutes, seconds);

    }



}

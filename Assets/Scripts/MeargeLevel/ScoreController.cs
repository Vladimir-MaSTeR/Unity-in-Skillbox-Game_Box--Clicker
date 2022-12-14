using UnityEngine;
using UnityEngine.UI;

public class ScoreController : MonoBehaviour
{
    [SerializeField] private Text _scoreText;
    [SerializeField] private float _jobTime = 1;

    private int _currentScore;
    private float _currentJobTime;

    private void Start()
    {
        _currentScore = 0;
        _scoreText.text = _currentScore.ToString();

        _currentJobTime = _jobTime;
    }

    private void Update()
    {
        JobTimer();
    }

    private void OnEnable()
    {
        EventsForMearge.onActivBank += UpdateScoreText;
    }

    private void OnDisable()
    {
        EventsForMearge.onActivBank -= UpdateScoreText;
    }

    private void JobTimer()
    {
        if (_currentJobTime < 0)
        {
            _currentJobTime = _jobTime;
        } else
        {
            _currentJobTime -= Time.deltaTime;
        }
    }

    private void UpdateScoreText(int amount)
    {
        if (_currentJobTime <= 0)
        {
            _currentScore += amount;

            _scoreText.text = _currentScore.ToString();
            EventsForMearge.onUpdateScoreTextPlaySound?.Invoke();
        }
    }

    public int GetScore()
    {
        return _currentScore;
    }
}

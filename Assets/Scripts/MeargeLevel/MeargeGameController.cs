using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.UI;

public class MeargeGameController : MonoBehaviour
{
    [SerializeField] private GameObject _winerPanel;
    [SerializeField] private Text _scoreTextInwinerPanel;


    private void Start()
    {
        _winerPanel.SetActive(false);
    }

    private void OnEnable()
    {
        EventsForMearge.onEndRoundTime += EndRound;
    }

    private void OnDisable()
    {
        EventsForMearge.onEndRoundTime -= EndRound;
    }

    private void EndRound()
    {
        Time.timeScale = 0;
        _winerPanel.SetActive(true);

        var finaleScore = gameObject.GetComponent<ScoreController>().GetScore();
        _scoreTextInwinerPanel.text = finaleScore.ToString();
    }

}

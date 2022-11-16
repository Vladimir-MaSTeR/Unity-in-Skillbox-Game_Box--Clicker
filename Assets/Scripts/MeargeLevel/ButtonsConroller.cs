using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ButtonsConroller : MonoBehaviour
{
    [Header("Panels")]
    [SerializeField] private GameObject _rulsPanel;
    [SerializeField] private GameObject _pausePanel;

    private void Start()
    {
        Time.timeScale = 1;

        _rulsPanel.SetActive(true);
        _pausePanel.SetActive(false);
    }

    public void ClickRulsButton()
    {
        Time.timeScale = 0;
        _rulsPanel.SetActive(true);
    }

    public void ClickBackInGameButtonRulsPanel()
    {
        Time.timeScale = 1;
        _rulsPanel.SetActive(false);
    }

    public void ClickPausedButton()
    {
        Time.timeScale = 0;
        _pausePanel.SetActive(true);
    }

    public void ClickBackInPausePanelButton()
    {
        Time.timeScale = 1;
        _pausePanel.SetActive(false);
    }


    public void ClickExitSceneInPausePanelButton()
    {

    }

    public void ClickRepeadRoundInWinerPanelbutton()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void ClickBackClickerScene()
    {
        EventsForMearge.onBackClickerScene?.Invoke();
    }

}

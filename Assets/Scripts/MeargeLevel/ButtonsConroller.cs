using UnityEngine;
using UnityEngine.UI;

public class ButtonsConroller : MonoBehaviour
{
    [Header("Panels")]
    [SerializeField] private GameObject _rulsPanel;
    [SerializeField] private GameObject _pausePanel;
    [SerializeField] private GameObject _winerPanel;

    [Header("Text")]
    [SerializeField] private Text adada;


    private void Start()
    {
        Time.timeScale = 1;

        _rulsPanel.SetActive(false);
        _pausePanel.SetActive(false);
        _winerPanel.SetActive(false);
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
}

using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonsControllerMenuLevel : MonoBehaviour
{
    [SerializeField] private GameObject _uiPanel;
    [SerializeField] private GameObject _rulsPanel;
    [SerializeField] private GameObject _settingsPanel;

    private void Start()
    {
        _uiPanel.SetActive(true);
        _rulsPanel.SetActive(false);
        _settingsPanel.SetActive(false);
    }


    public void ClickRulsButton()
    {
        _uiPanel.SetActive(false);
        _rulsPanel.SetActive(true);
    }

    public void ClickBackRulsButton()
    {
        _rulsPanel.SetActive(false);
        _uiPanel.SetActive(true);
    }

    public void ClickSettingsButton()
    {
        _uiPanel.SetActive(false);
        _settingsPanel.SetActive(true);
    }

    public void ClickBackSettingsButton()
    {
        _settingsPanel.SetActive(false);
        _uiPanel.SetActive(true);
    }

    public void ClickStartGame()
    {
        SceneManager.LoadScene(1);
    }

    public void ClicExitGame()
    {
        Application.Quit();
    }
}

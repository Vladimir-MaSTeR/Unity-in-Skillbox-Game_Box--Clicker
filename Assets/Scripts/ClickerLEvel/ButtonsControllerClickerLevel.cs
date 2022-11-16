using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonsControllerClickerLevel : MonoBehaviour
{
    
    [SerializeField] private GameObject _rulsPanel;
    [SerializeField] private GameObject _settingsPanel;
    [SerializeField] private GameObject _magPanel;


    private void Start()
    {
        _rulsPanel.SetActive(false);
        _settingsPanel.SetActive(false);
        _magPanel.SetActive(false);
    }

    public void ClickRulsButton()
    {
        Time.timeScale = 0;
        _rulsPanel.SetActive(true);
    }

    public void ClickBackRulsButton()
    {
        Time.timeScale = 1;
        _rulsPanel.SetActive(false);
    }

    public void ClickSettingsButton()
    {
        Time.timeScale = 0;
        _settingsPanel.SetActive(true);
    }

    public void ClickUiMenuButton()
    {

        // сохраняем и отправляем в ui сцену
        Debug.Log("Нажата кнопка возврата в UI сцену");
    }

    public void ClickBackSettingsButton()
    {
        Time.timeScale = 1;
        _settingsPanel.SetActive(false);
    }

    public void ClickMagButton()
    {
        Time.timeScale = 0;
        _magPanel.SetActive(true);
    }

    public void ClickBackMagButton()
    {
        Time.timeScale = 1;
        _magPanel.SetActive(false);
    }

    public void ClickHomeUpgradeButton()
    {
        EventClickerController.onUpgradeHome?.Invoke();
    }

    public void ClickDamageUpgradeButton()
    {
        // Отправить Эвент
        Debug.Log("Нажата кнопка в магазине, увеличения урона");
        EventClickerController.onUpgradeDamage?.Invoke();

    }

    public void ClicStartMeardgRound()
    {
        EventClickerController.onSlickMeargeScene?.Invoke();

    }

    public void ClickDamage()
    {
        EventClickerController.onDamageClick?.Invoke();
    }


}

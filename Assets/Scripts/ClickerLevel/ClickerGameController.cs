using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System;


public class ClickerGameController : MonoBehaviour
{
    [Header("Coin Score")]
    [SerializeField] private Text _coinText;
    [SerializeField] private int _startCoin = 0;

    [Header("Damage")]
    [SerializeField] private Text _damageText;
    [SerializeField] private int _startDamage = 1;

    [Header("Monsters")]
    [SerializeField] private Image _plantForMonsters;
    [SerializeField] private Sprite[] _monstersSprite;
    [SerializeField] private Text _monstersHealtText;
    [SerializeField] private int _startHealtMonster = 1000;


    [Header("Pasive coin profit and timer")]
    [SerializeField] private Text _pasiveProfitText;
    [SerializeField] private int _startPasiveProfit = 10;

    [SerializeField] private Text _timerPasiveProfitText; 
    [SerializeField] private float _timePasiveProfit = 180;

    [Header("Home")]
    [SerializeField] private Text _homeLevelText;
    [SerializeField] private int _startHomeLevel = 1;


    private int _currentCoin;
    private int _currendDamage;
    private int _currendHealtMonster;
    private int _currendIndexRespawnMonster;

    private float _currentTimerPasiveProfit;
    private int _currentPasiveProfit;

    private int _score;

    private int _currentHomeLevel;


    private const int PRICE_UPGRADE_HOME = 20000;
    private const int PLUS_PASSIVE_HOME = 100;
    private const int PRICE_UPGRADE_DAMAGE = 1000;
    private const int PLUS_DAMAGE = 10;


    private void Start()
    {
        // _currentCoin = _startCoin;
        LoadCoin();
        UpdateText(_coinText, _currentCoin);

        LoadScore();
        UpdateText(_coinText, (_currentCoin + _score));

        //_currendDamage = _startDamage;
        LoadDamage();
        UpdateText(_damageText, _currendDamage);

        //_currendIndexRespawnMonster = 0;
        LoadIndexRespawnMonster();

        //_currendHealtMonster = _startHealtMonster;
        LoadHealtMonster();
        UpdateText(_monstersHealtText, _currendHealtMonster);

        //_currentTimerPasiveProfit = _timePasiveProfit;
        LoadTimerPasiveProfit();
        _timerPasiveProfitText.text = _currentTimerPasiveProfit.ToString();
        //_currentPasiveProfit = _startPasiveProfit;
        LoadPasiveProfit();
        UpdateText(_pasiveProfitText, _currentPasiveProfit);

        //_currentHomeLevel = _startHomeLevel;
        LoadHomeLevel();
        UpdateText(_homeLevelText, _currentHomeLevel);
    }

    private void Update()
    {
        if (_currentTimerPasiveProfit > 0)
        {
            _currentTimerPasiveProfit -= Time.deltaTime;
            UpdateTimerText(_currentTimerPasiveProfit);

        }
        else
        {
            _currentTimerPasiveProfit = _timePasiveProfit;
            PasiveProfit();
        }

        if (_score > 0)
        {
            UpdateText(_coinText, (_currentCoin + _score));
            PlayerPrefs.DeleteAll();

        }
    }


    private void OnEnable()
    {
        EventClickerController.onDamageClick += TakeDamage;
        EventClickerController.onUpgradeHome += UpgradeHome;
        EventClickerController.onUpgradeDamage += UpgradeDamage;
        EventClickerController.onSlickMeargeScene += StartMeargeScene;
    }

    private void OnDisable()
    {
        EventClickerController.onDamageClick -= TakeDamage;
        EventClickerController.onUpgradeHome -= UpgradeHome;
        EventClickerController.onUpgradeDamage -= UpgradeDamage;
        EventClickerController.onSlickMeargeScene -= StartMeargeScene;
    }

    private void TakeDamage()
    {
        if (_currendHealtMonster > 0)
        {
            _currendHealtMonster -= _currendDamage;
            UpdateText(_monstersHealtText, _currendHealtMonster);

            if (_currendHealtMonster <= 0)
            {
                ChangeimageMonsters();
            }
           
        } 
        
    }

    private void ChangeimageMonsters()
    {
        _plantForMonsters.sprite = _monstersSprite[_currendIndexRespawnMonster];
        _currendHealtMonster = _startHealtMonster;
        UpdateText(_monstersHealtText, _currendHealtMonster);

        _currendIndexRespawnMonster++;

        if (_currendIndexRespawnMonster >=  _monstersSprite.Length)
        {
            _currendIndexRespawnMonster = 0;            
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
        _timerPasiveProfitText.text = string.Format("{0:00} : {1:00}", minutes, seconds);

    }

    private void PasiveProfit()
    {
        _currentCoin += _currentPasiveProfit;
        UpdateText(_coinText, _currentCoin);

        EventClickerController.onPasiveProfit?.Invoke();
    }

    private void UpgradeHome()
    {
        if (_currentCoin < PRICE_UPGRADE_HOME)
        {
            EventClickerController.onNegativeUpgrade?.Invoke();
        } else
        {
            _currentCoin -= PRICE_UPGRADE_HOME;
            UpdateText(_coinText, _currentCoin);

            _currentHomeLevel++;
            UpdateText(_homeLevelText, _currentHomeLevel);

            _currentPasiveProfit += PLUS_PASSIVE_HOME;
            UpdateText(_pasiveProfitText, _currentPasiveProfit);

            EventClickerController.onPositiveUpgrade?.Invoke();

        }
    }

    private void UpgradeDamage()
    {
        if (_currentCoin < PRICE_UPGRADE_DAMAGE)
        {
            EventClickerController.onNegativeUpgrade?.Invoke();

        }
        else
        {
            _currentCoin -= PRICE_UPGRADE_DAMAGE;
            UpdateText(_coinText, _currentCoin);

            _currendDamage += PLUS_DAMAGE;
            UpdateText(_damageText, _currendDamage);

            EventClickerController.onPositiveUpgrade?.Invoke();
        }
    }

    private void UpdateText(Text currentText, int currentValue)
    {
        currentText.text = currentValue.ToString();
    }

    private void StartMeargeScene()
    {
        SaveGame();
        SceneManager.LoadScene(2);
    }

    private void SaveGame()
    {
    PlayerPrefs.SetInt("currentCoin", _currentCoin);
    PlayerPrefs.SetInt("currendDamage", _currendDamage);
    PlayerPrefs.SetInt("currendHealtMonster", _currendHealtMonster);
    PlayerPrefs.SetInt("currendIndexRespawnMonster", _currendIndexRespawnMonster);
    PlayerPrefs.SetFloat("currentTimerPasiveProfit", _currentTimerPasiveProfit);
    PlayerPrefs.SetFloat("currentPasiveProfit", _currentPasiveProfit);
    PlayerPrefs.SetFloat("currentHomeLevel", _currentHomeLevel);

    PlayerPrefs.Save();
    }

    private void LoadHomeLevel()
    {
        if (PlayerPrefs.HasKey("currentHomeLevel"))
        {
            _currentHomeLevel = PlayerPrefs.GetInt("currentHomeLevel");

        }
        else
        {
            _currentHomeLevel = _startHomeLevel;
        }
    }

    private void LoadPasiveProfit()
    {
        if (PlayerPrefs.HasKey("currentPasiveProfit"))
        {
            _currentPasiveProfit = PlayerPrefs.GetInt("currentPasiveProfit");

        }
        else
        {
            _currentPasiveProfit = _startPasiveProfit;
        }
    }

    private void LoadTimerPasiveProfit()
    {
        if (PlayerPrefs.HasKey("currentTimerPasiveProfit"))
        {
            _currentTimerPasiveProfit = PlayerPrefs.GetInt("currentTimerPasiveProfit");

        }
        else
        {
            _currentTimerPasiveProfit = _timePasiveProfit;
        }
    }

    private void LoadCoin()
    {
        if (PlayerPrefs.HasKey("currentCoin"))
        {
            _currentCoin = PlayerPrefs.GetInt("currentCoin");

        }
        else
        {
            _currentCoin = _startCoin;
        }
    }

    private void LoadIndexRespawnMonster()
    {
        if (PlayerPrefs.HasKey("currendIndexRespawnMonster"))
        {
            _currendIndexRespawnMonster = PlayerPrefs.GetInt("currendIndexRespawnMonster");

        } else
        {
            _currendIndexRespawnMonster = 0;
        }      
    }

    private void LoadDamage()
    {
        if (PlayerPrefs.HasKey("currendDamage"))
        {
            _currendDamage = PlayerPrefs.GetInt("currendDamage");
        }
        else
        {
            _currendDamage = _startDamage;
        }
    }

    private void LoadHealtMonster()
    {
        if (PlayerPrefs.HasKey("currendHealtMonster"))
        {
            _currendHealtMonster = PlayerPrefs.GetInt("currendHealtMonster");

        }
        else
        {
            _currendHealtMonster = _startHealtMonster;
        }
    }

    private void LoadScore()
    {
        if (PlayerPrefs.HasKey("score"))
        {
            
            _score = PlayerPrefs.GetInt("score");
            Debug.Log($"score = {_score}");

        }
        else
        {
            _score = 0;
        }
    }
}

using UnityEngine;
using UnityEngine.UI;

public class Spawner : MonoBehaviour
{
    [Header("Timers")]
    [SerializeField] private float _timeRespavnItem = 2f;
    [SerializeField] private float _timeMovingYellow = 15f;

    [Header("Slots")]
    [SerializeField] private Image[] _slots;

    [Header("Items")]
    [SerializeField] private GameObject[] _items;
    

    private int _currentSlotIndex;
    private int _indexJobSlot;

    private int _currentItemIndex;
    private float _currentMovingYellowTime;

    private float _currentTimeRessItem;

    private void Start()
    {
        _currentSlotIndex = Random.Range(0, _slots.Length);
        _currentItemIndex = Random.Range(0, _items.Length);
        _currentTimeRessItem = _timeRespavnItem;

        _indexJobSlot = Random.Range(0, _slots.Length);
        _currentMovingYellowTime = _timeMovingYellow;

        _slots[_indexJobSlot].color = Color.yellow;
    }


    private void Update()
    {
        SpavnInZeroPoint();
        ChangeJobInSlot();

        JobBank();
    }

    private void SpavnInZeroPoint()
    {
        if (_currentTimeRessItem <= 0)
        {
            if (_slots[_currentSlotIndex].GetComponentInChildren<CanvasGroup>() != null)
            {
                _currentSlotIndex = Random.Range(0, _slots.Length);
                _currentItemIndex = Random.Range(0, _items.Length);
            }
            else
            {
                Instantiate(_items[_currentItemIndex], _slots[_currentSlotIndex].rectTransform);

                _currentTimeRessItem = _timeRespavnItem;
                _currentSlotIndex = Random.Range(0, _slots.Length);
                _currentItemIndex = Random.Range(0, _items.Length);
            }

        } else
        {
            _currentTimeRessItem -= Time.deltaTime;
        }
    }

    private void JobBank()
    {
        if (_slots[_indexJobSlot].GetComponentInChildren<CanvasGroup>() != null)
        {
            var amount = _slots[_indexJobSlot].GetComponentInChildren<Item>().GetCurrentAmountForText();
            EventsForMearge.onActivBank?.Invoke(amount);
        }
    }
   

    private void ChangeJobInSlot()
    {
        if (_currentMovingYellowTime < 0)
        {

            _slots[_indexJobSlot].color = Color.white;

            _indexJobSlot = Random.Range(0, _slots.Length);
            _slots[_indexJobSlot].color = Color.yellow;

            _currentMovingYellowTime = _timeMovingYellow;
        } else
        {
            _currentMovingYellowTime -= Time.deltaTime;
        }
    }
}
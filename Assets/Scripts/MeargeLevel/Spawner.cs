using UnityEngine;
using UnityEngine.UI;

public class Spawner : MonoBehaviour
{
    [Header("Timers")]
    [SerializeField] private float _timeRespavnItem = 2f;
    [SerializeField] private float _jobTime = 10f;

    [Header("Slots")]
    [SerializeField] private Image[] _slots;

    [Header("Items")]
    [SerializeField] private GameObject[] _items;
    

    private int _currentSlotIndex;
    private int _indexJobSlot;

    private int _currentItemIndex;
    private float _currentJobTime;

    private float _currentTimeRessItem;

    private void Start()
    {
        _currentSlotIndex = Random.Range(0, _slots.Length);
        _currentItemIndex = Random.Range(0, _items.Length);
        _currentTimeRessItem = _timeRespavnItem;

        _indexJobSlot = Random.Range(0, _slots.Length);
        _currentJobTime = _jobTime;

        _slots[_indexJobSlot].color = Color.yellow;
    }


    private void Update()
    {
        SpavnInZeroPoint();
        ChangeJobInSlot();
    }

    private void SpavnInZeroPoint()
    {
        if (_currentTimeRessItem <= 0)
        {
            if (_slots[_currentSlotIndex].GetComponentInChildren<CanvasGroup>() != null)
            {
                _currentSlotIndex = Random.Range(0, _slots.Length);
                _currentItemIndex = _currentItemIndex = Random.Range(0, _items.Length);
            }
            else
            {
                Instantiate(_items[_currentItemIndex], _slots[_currentSlotIndex].rectTransform);

                _currentTimeRessItem = _timeRespavnItem;
                _currentSlotIndex = Random.Range(0, _slots.Length);
                _currentItemIndex = _currentItemIndex = Random.Range(0, _items.Length);
            }

        } else
        {
            _currentTimeRessItem -= Time.deltaTime;
        }
    }

    private void ChangeJobInSlot()
    {
        if (_currentJobTime < 0)
        {

            _slots[_indexJobSlot].color = Color.white;

            _indexJobSlot = Random.Range(0, _slots.Length);
            _slots[_indexJobSlot].color = Color.yellow;

            _currentJobTime = _jobTime;
        } else
        {
            _currentJobTime -= Time.deltaTime;
        }
    }
}
using UnityEngine;
using UnityEngine.UI;

public class Spawner : MonoBehaviour
{

    [SerializeField] private float _timeRespavnItem = 3f;

    [SerializeField] private Image[] _slots;
    [SerializeField] private GameObject[] _items;
    

    private int _currentSlotIndex;
    private int _currentItemIndex;

    private float _currentTimeRessItem;

    private void Start()
    {
        _currentSlotIndex = _currentSlotIndex = Random.Range(0, _slots.Length);
        _currentItemIndex = _currentItemIndex = Random.Range(0, _items.Length);
        _currentTimeRessItem = _timeRespavnItem;
    }


    private void Update()
    {
        _currentTimeRessItem -= Time.deltaTime;
        SpavnInZeroPoint();
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

        }
    }
}
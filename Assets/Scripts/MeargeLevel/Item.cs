using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Item : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{

    [SerializeField] private Text _text;
    [SerializeField] private int _startAmountText = 1;

    private int _id;
    private int _currentAmountForText;

    private Canvas _mainCanvas;
    private CanvasGroup _canvasGroup;

    private RectTransform _rectTransform;

    private void Start()
    {
        _id = GetInstanceID();

        _rectTransform = GetComponent<RectTransform>();
        _mainCanvas = GetComponentInParent<Canvas>();
        _canvasGroup = GetComponent<CanvasGroup>();

        _currentAmountForText = _startAmountText;
        _text.text = _currentAmountForText.ToString();
    }

    private void Update()
    {
       // _text.
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        var slotTransform = _rectTransform.parent;
        slotTransform.SetAsLastSibling();

        _canvasGroup.blocksRaycasts = false;
    }

    public void OnDrag(PointerEventData eventData)
    {
        _rectTransform.anchoredPosition += eventData.delta / _mainCanvas.scaleFactor;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        transform.localPosition = Vector3.zero;

        _canvasGroup.blocksRaycasts = true;
    }

    public int GetCurrentAmountForText()
    {
        return _currentAmountForText;
    }

    public void SetCurrentAmountForText(int currentAmount)
    {
        _currentAmountForText = currentAmount;
    }

    public int GetItemId()
    {
        return _id;
    }


    private void OnEnable()
    {
        EventsForMearge.onSameTag += UpdateText;
    }

    private void OnDisable()
    {
        EventsForMearge.onSameTag -= UpdateText;
    }


    private void UpdateText(int amount)
    {
        _currentAmountForText += amount;
        _text.text = _currentAmountForText.ToString();
    }
}

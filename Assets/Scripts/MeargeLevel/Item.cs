using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Item : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    [Header("Amount Text")]
    [SerializeField] private Text _text;

    [Header("Start amount count")]
    [SerializeField] private int _minAmountText = 1;
    [SerializeField] private int _maxAmountText = 10;

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

        _currentAmountForText = Random.Range(_minAmountText, _maxAmountText);
        _text.text = _currentAmountForText.ToString();
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

}

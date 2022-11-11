using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Slot : MonoBehaviour, IDropHandler
{
    public void OnDrop(PointerEventData eventData)
    {
        
        if (gameObject.GetComponentInChildren<CanvasGroup>() == null)
        {
            var otherItemTransform = eventData.pointerDrag.transform;
            otherItemTransform.SetParent(transform);                    // ������ � ������� ���� �������� ��������
            otherItemTransform.localPosition = Vector3.zero;            // � �������� ��� �������
        } else
        {

            var parentTag = gameObject.GetComponentInChildren<CanvasGroup>().tag;
            var childrenTag = eventData.pointerDrag.tag;

            Debug.Log($"������������ ��� = {parentTag}");
            Debug.Log($"��� �������� = {childrenTag}");

            if (gameObject.GetComponentInChildren<CanvasGroup>().CompareTag("Square") == eventData.pointerDrag.CompareTag("Square")
                && gameObject.GetComponentInChildren<Item>().GetItemId() !=  eventData.pointerDrag.GetComponentInChildren<Item>().GetItemId())
            {
                var childAmount = eventData.pointerDrag.GetComponentInChildren<Item>().GetCurrentAmountForText();
                Debug.Log($"������� ����������� = {childAmount}");

                var parentAmount = gameObject.GetComponentInChildren<Item>().GetCurrentAmountForText();
                Debug.Log($"������������ ����������� = {parentAmount}");

                var currentAmount = childAmount + parentAmount;
                Debug.Log($"����� ����������� = {currentAmount}");


                gameObject.GetComponentInChildren<Text>().text = currentAmount.ToString();
                gameObject.GetComponentInChildren<Item>().SetCurrentAmountForText(currentAmount);

                Destroy(eventData.pointerDrag);

                //  _text.text = childAmountText.ToString();

                //  EventsForMearge.onSameTag?.Invoke(3);

                Debug.Log("���������� �������� �������");
            }
        }

        
    }
}

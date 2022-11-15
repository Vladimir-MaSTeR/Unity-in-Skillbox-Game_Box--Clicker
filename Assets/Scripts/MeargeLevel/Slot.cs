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

            var parentId = gameObject.GetComponentInChildren<Item>().GetItemId();
            var childrenId = eventData.pointerDrag.GetComponentInChildren<Item>().GetItemId();


            if ( parentTag == childrenTag && parentId != childrenId)
            {
                var childAmount = eventData.pointerDrag.GetComponentInChildren<Item>().GetCurrentAmountForText();
                var parentAmount = gameObject.GetComponentInChildren<Item>().GetCurrentAmountForText();
                var currentAmount = childAmount + parentAmount;

                gameObject.GetComponentInChildren<Text>().text = currentAmount.ToString();
                gameObject.GetComponentInChildren<Item>().SetCurrentAmountForText(currentAmount);

                EventsForMearge.onPositiveMeargeSound?.Invoke();

                Destroy(eventData.pointerDrag);
            } else
            {
                EventsForMearge.onNoMeargeSound?.Invoke();
            }
        }

        
    }
}

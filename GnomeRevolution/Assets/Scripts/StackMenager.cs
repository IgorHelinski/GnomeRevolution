using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class StackMenager : MonoBehaviour, IDropHandler
{
    public List<GameObject> slots;
    public List<RectTransform> avaliableSlots;

    public void OnDrop(PointerEventData eventData)
    {
        Debug.Log("OnDrop");

        if (eventData.pointerDrag != null)
        {
            //eventData.pointerDrag.GetComponent<RectTransform>().anchoredPosition = GetComponent<RectTransform>().anchoredPosition;
            slots.Add(eventData.pointerDrag);
            eventData.pointerDrag.GetComponent<RectTransform>().anchoredPosition = avaliableSlots[slots.Count - 1].anchoredPosition;
        }
    }
}

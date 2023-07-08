using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class GarbageCan : MonoBehaviour, IDropHandler, IPointerEnterHandler, IPointerExitHandler
{
    public Image sprite;

    public Sprite normalBin;
    public Sprite openBin;

    public void OnDrop(PointerEventData eventData)
    {
        if (eventData.pointerDrag != null && eventData.pointerDrag.TryGetComponent<DragDrop>(out DragDrop dragDrop))
        {
            Destroy(dragDrop.currentEmpty);
            Destroy(eventData.pointerDrag);
        }
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        sprite.sprite = openBin;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        sprite.sprite = normalBin;
    }
}

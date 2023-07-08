using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine.UIElements;
using TMPro;
using UnityEngine.InputSystem;

public class DragDrop : MonoBehaviour, IPointerDownHandler, IBeginDragHandler, IEndDragHandler, IDragHandler, IPointerUpHandler, IDropHandler
{
    public GameObject emptyPrefab;

    [HideInInspector] public Transform parentAfterDrag;
    [HideInInspector] public GameObject currentEmpty;

    [SerializeField] private Canvas canvas;

    private RectTransform rectTransform;
    private CanvasGroup canvasGroup;

    private void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
        canvasGroup = GetComponent<CanvasGroup>();
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        //Debug.Log("OnBeginDrag");

        canvasGroup.blocksRaycasts = false;
        parentAfterDrag = transform.parent;

        int index = transform.GetSiblingIndex();
        GameObject emptyElement = Instantiate(emptyPrefab, transform.parent);
        emptyElement.transform.SetSiblingIndex(index);
        currentEmpty = emptyElement;

        transform.SetParent(canvas.transform);
        transform.SetAsLastSibling();
    }

    public void OnDrag(PointerEventData eventData)
    {
        rectTransform.anchoredPosition += eventData.delta / canvas.scaleFactor;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        if(currentEmpty != null)
        {
            Destroy(currentEmpty);
        }

        canvasGroup.blocksRaycasts = true;
        transform.SetParent(parentAfterDrag);
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        transform.localScale = new Vector3(1.2f, 1.2f, 1.2f);
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        transform.localScale = Vector3.one;
    }

    public void OnDrop(PointerEventData eventData)
    {
        if (eventData.pointerDrag != null && transform.parent.GetComponent<StackTag>().currentStackType != StackTag.StackType._gnomeInput)
        {
            DragDrop item = eventData.pointerDrag.GetComponent<DragDrop>();
            item.parentAfterDrag = transform.parent;
        }
    }
}

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
    public Transform parentAfterDrag;
    public GameObject emptyPrefab;

    private GameObject currentEmpty;

    public Vector3 pos;
    public int index;

    [SerializeField] private Canvas canvas;
    //[SerializeField] private float smoothingFactor = 0.1f;

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
        pos = transform.position;

        

        index = transform.GetSiblingIndex();
        GameObject emptyElement = Instantiate(emptyPrefab, transform.parent);
        emptyElement.transform.SetSiblingIndex(index);
        currentEmpty = emptyElement;

        transform.SetParent(canvas.transform);
        transform.SetAsLastSibling();



    }

    public void OnDrag(PointerEventData eventData)
    {
        rectTransform.anchoredPosition += eventData.delta / canvas.scaleFactor;

        //List<RaycastResult> raycastResults = new List<RaycastResult>();
        //EventSystem.current.RaycastAll(eventData, raycastResults);
        //if(raycastResults.Count > 0)
        //{
        //    foreach(var result in raycastResults)
        //    {
        //        Debug.Log(result.gameObject.name);
        //    }
        //}
        //else
        //{
        //    transform.SetParent(canvas.transform);
        //    transform.SetAsLastSibling();
        //}
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        //Debug.Log("OnEndDrag");

        //List<RaycastResult> raycastResults = new List<RaycastResult>();
        //EventSystem.current.RaycastAll(eventData, raycastResults);
        //if (raycastResults.Count > 0)
        //{
        //    foreach (var result in raycastResults)
        //    {
        //        Debug.Log(result.gameObject.name);
        //    }

        //    transform.position = pos;
        //}
        //else
        //{
        //    transform.SetParent(canvas.transform);
        //    transform.SetAsLastSibling();
        //}

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
        if (eventData.pointerDrag != null)
        {
            DragDrop item = eventData.pointerDrag.GetComponent<DragDrop>();
            item.parentAfterDrag = transform.parent;
        }
    }
}

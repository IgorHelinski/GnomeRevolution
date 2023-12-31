using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class GnomeInput : MonoBehaviour, IDropHandler
{
    public GameObject slotsGameObject;
    public List<DragDrop> elements = new List<DragDrop>();

    public int maxSize;
    public GameEvent OnGameOver;

    private void Start()
    {
        //CheckElements();
    }

    public void OnDrop(PointerEventData eventData)
    {
        Debug.Log("OnDrop");

        if (eventData.pointerDrag != null)
        {
            //DragDrop item = eventData.pointerDrag.GetComponent<DragDrop>();
            //item.parentAfterDrag = slotsGameObject.transform;
            //Invoke("CheckElements", 0.1f);
        }
    }

    private void Update()
    {
        CheckElements();

        if (elements.Count >= maxSize)
        {
            OnGameOver.Raise(this, this);
        }
    }

    private void CheckElements()
    {
        elements.Clear();

        foreach(Transform child in slotsGameObject.transform)
        {
            elements.Add(child.GetComponent<DragDrop>());
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputHandler : MonoBehaviour
{

    [SerializeField] private InputAction mouseClick;
    [SerializeField] private float mouseDragSpeed = .1f;

    // other
    private Camera _mainCamera;
    private WaitForFixedUpdate waitForFixedUpdate = new WaitForFixedUpdate();
    Vector3 velocity = Vector2.zero;

    private void Awake()
    {
        _mainCamera = Camera.main;
    }

    private void OnEnable()
    {
        mouseClick.Enable();
        mouseClick.performed += OnClick;
    }

    private void OnDisable()
    {
        mouseClick.performed -= OnClick;
        mouseClick.Disable();
    }

    public void OnClick(InputAction.CallbackContext context)
    {
        //if (!context.started) return;

        //RaycastHit2D hit = Physics2D.GetRayIntersection(_mainCamera.ScreenPointToRay(Mouse.current.position.ReadValue()));

        Ray ray = _mainCamera.ScreenPointToRay(Mouse.current.position.ReadValue());
        RaycastHit hit;

        if(Physics.Raycast(ray, out hit))
        {

        }

        //if (!hit.collider) return;

        StartCoroutine(DragUpdate(hit.collider.gameObject));

        Debug.Log(hit.collider.gameObject.name);
    }

    private IEnumerator DragUpdate(GameObject dragObject)
    {
        float initialDistance = Vector3.Distance(dragObject.transform.position, _mainCamera.transform.position);
        while(mouseClick.ReadValue<float>() != 0)
        {
            Ray ray = _mainCamera.ScreenPointToRay(Mouse.current.position.ReadValue());
            dragObject.transform.position = Vector3.SmoothDamp(dragObject.transform.position, ray.GetPoint(initialDistance), ref velocity, mouseDragSpeed);
            yield return null;
        }
    }

}

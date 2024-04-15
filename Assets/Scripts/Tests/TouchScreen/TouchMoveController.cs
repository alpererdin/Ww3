using System;
using Signals;
using UnityEngine;
using UnityEngine.EventSystems;

public class TouchMoveController : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    public float sensitivity = 5f;
    public Camera _main;
    public float minZ = -20f;
    public float maxZ = 50f;

    private bool isPressed = false;

    private void OnEnable()
    {
        GameSignals.Instance.CameraMaxZAmount += setMaxZ;
    }

    private void setMaxZ(int arg0)
    {
        maxZ = arg0;
    }
    private void OnDisable()
    {
        GameSignals.Instance.CameraMaxZAmount -= setMaxZ;
    }

    private void Update()
    {
        if (isPressed)
        {
            Vector2 touchDeltaPosition = Input.GetTouch(0).deltaPosition;
            float deltaZ = touchDeltaPosition.x * -sensitivity * Time.deltaTime;
            MoveZ(deltaZ);
        }
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        isPressed = true;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        isPressed = false;
    }

    private void MoveZ(float deltaZ)
    {
        float currentZ = _main.transform.position.z + deltaZ;
        currentZ = Mathf.Clamp(currentZ, minZ, maxZ);
        _main.transform.position = new Vector3(_main.transform.position.x, _main.transform.position.y, currentZ);
    }
}
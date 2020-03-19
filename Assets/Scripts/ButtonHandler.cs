using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ButtonHandler : MonoBehaviour,IPointerDownHandler,IPointerUpHandler
{
    public bool isDown;
    public bool isUp;

    public void OnPointerDown(PointerEventData eventData)
    {
        isDown = true;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        isUp = true;
    }

    private void LateUpdate()
    {
        isDown = false;
        isUp = false;
    }

    private void OnDisable()
    {
        isDown = false;
        isUp = false;
    }
}

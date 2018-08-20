using UnityEngine;
using UnityEngine.EventSystems;

public class FixedButton : MonoBehaviour, IPointerUpHandler, IPointerDownHandler
{
    [HideInInspector] public bool Pressed;
    [HideInInspector] public bool Clicked;

    public void OnPointerDown(PointerEventData eventData)
    {
        Pressed = true;

        if (Clicked)
        {
            Clicked = false;
        }
        else
        {
            Clicked = true;
        }
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        Pressed = false;
    }
}

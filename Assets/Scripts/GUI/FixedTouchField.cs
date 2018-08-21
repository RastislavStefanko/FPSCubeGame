using UnityEngine;
using UnityEngine.EventSystems;
using System.Collections;

public class FixedTouchField : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    [HideInInspector] public Vector2 TouchDist;
    [HideInInspector] public Vector2 PointerOld;
    [HideInInspector] public bool Pressed;
    [HideInInspector] public bool DoubleClick;

    [HideInInspector] protected int PointerId;

    [SerializeField] private float doubleClickRange = 0.5f;

    private int counter;

    void Update()
    {
        if (Pressed)
        {
            if (PointerId >= 0 && PointerId < Input.touches.Length)
            {
                TouchDist = Input.touches[PointerId].position - PointerOld;
                PointerOld = Input.touches[PointerId].position;
            }
            else
            {
                TouchDist = new Vector2(Input.mousePosition.x, Input.mousePosition.y) - PointerOld;
                PointerOld = Input.mousePosition;
            }
        }
        else
        {
            TouchDist = new Vector2();
        }
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        Pressed = true;
        PointerId = eventData.pointerId;
        PointerOld = eventData.position;

        counter++;
        if (counter == 1)
        {
            StartCoroutine("DoubleClickCoroutine");
        }
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        Pressed = false;
    }

    IEnumerator DoubleClickCoroutine()
    {
        yield return new WaitForSeconds(doubleClickRange);

        if(counter > 1)
        {
            if (DoubleClick)
            {
                DoubleClick = false;
            }
            else
            {
                DoubleClick = true;
            }
        }

        yield return new WaitForSeconds(0.05f);
        counter = 0;

    }
    
}
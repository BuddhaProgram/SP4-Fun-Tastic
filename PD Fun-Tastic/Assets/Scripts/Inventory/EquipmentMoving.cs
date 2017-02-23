using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.EventSystems;

public class EquipmentMoving : MonoBehaviour, IPointerDownHandler, IPointerUpHandler, IPointerClickHandler
{

    public Transform target;
    public Transform itemIcon;
    private bool isMouseDown = false;
    private Vector3 startMousePosition;
    private Vector3 startPosition;
    public bool shouldReturn;

    // Use this for initialization
    void Start()
    {

    }

    public void OnPointerClick(PointerEventData dt)
    {
        target.SetSiblingIndex(-1);
        itemIcon.SetSiblingIndex(-2);
    }

    public void OnPointerDown(PointerEventData dt)
    {
        isMouseDown = true;

        startPosition = target.position;
        startMousePosition = Input.mousePosition;
    }

    public void OnPointerUp(PointerEventData dt)
    {
        isMouseDown = false;

        if (shouldReturn)
        {
            target.position = startPosition;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (isMouseDown)
        {
            Vector3 currentPosition = Input.mousePosition;

            Vector3 diff = currentPosition - startMousePosition;

            Vector3 pos = startPosition + diff;

            target.position = pos;
        }
    }

}

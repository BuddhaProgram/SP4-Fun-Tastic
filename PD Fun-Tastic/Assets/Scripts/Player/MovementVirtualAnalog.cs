using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class MovementVirtualAnalog : MonoBehaviour,IDragHandler,IBeginDragHandler,IEndDragHandler {

    public Image movementAnalogBG;
    public Image movementAnalog;
    public float maxRange = 2f;

    private Vector2 anchorPos;
    private Vector2 analogPos;

    private bool analogActive;

    public PlayerController player;


	// Use this for initialization
	void Start () {
        analogActive = false;

        maxRange = movementAnalogBG.rectTransform.rect.width/2f;

        movementAnalogBG.gameObject.SetActive(false);
	}
	
	// Update is called once per frame
	void Update () {

        if (analogActive == true)
        {

            Vector2 dir = analogPos - anchorPos;

            if (dir.magnitude > maxRange)
            {
                dir.Normalize();
                dir *= maxRange;
            }

            movementAnalog.transform.localPosition = dir;

            float moveSpeedRatio = dir.magnitude / maxRange;


            player.velocity.Set(player.f_moveSpeed *  Time.deltaTime * dir.x / maxRange, 0, player.f_moveSpeed * Time.deltaTime * dir.y/maxRange);
        }
	
	}

    public void OnBeginDrag(PointerEventData data)
    {
        anchorPos = data.position;

        //Debug.Log("Data " + data.position.x);

        Vector2 pos = data.position;

        pos.x /= Screen.width;
        pos.y /= Screen.height;

        pos.x *= 1920;
        pos.y *= 1080;

        pos.x -= 1920 / 2f;
        pos.y -= 1080 / 2f;

        //Debug.Log("pos " + pos.x);

        Debug.Log("Width " + Screen.width);
        movementAnalogBG.transform.localPosition = pos;
        analogPos = data.position;
        analogActive = true;
        movementAnalogBG.gameObject.SetActive(true);

        //player.gameObject.GetComponent<Health>().ReceiveDamage(1);
    }

    public void OnDrag(PointerEventData data)
    {
        analogPos = data.position;
    }

    public void OnEndDrag(PointerEventData data)
    {
        analogActive = false;
        movementAnalogBG.gameObject.SetActive(false);
    }
}

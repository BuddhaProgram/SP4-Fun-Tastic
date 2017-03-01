using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ShootingVirtualAnalog : MonoBehaviour,IDragHandler,IBeginDragHandler,IEndDragHandler {


    public Image shootingAnalog;
    public float maxRange = 2f;

    private Vector2 anchorPos;
    private Vector2 analogPos;

    private bool analogActive;

    public AbilityControl basicAbility;
    public PlayerController player;

	// Use this for initialization
	void Start () {
        maxRange = gameObject.GetComponent<Image>().rectTransform.rect.width / 2f;
	}
	
	// Update is called once per frame
	void Update () {

        if (analogActive == true)
        {
            Debug.Log("Analog active");

            basicAbility.released = true;

            Vector2 dir = analogPos - anchorPos;

            if (dir.magnitude > maxRange)
            {
                dir.Normalize();
                dir *= maxRange;
            }

            shootingAnalog.transform.localPosition = dir;

            Vector3 playerPos = player.transform.localPosition;

            Vector3 mousePos = new Vector3(dir.x * 3 + playerPos.x, 0f, dir.y * 3 + playerPos.z);
          
            player.gameObject.transform.LookAt(new Vector3(mousePos.x, 0f, mousePos.z), new Vector3(0, 1, 0));
            

        }
        else
        {
            Debug.Log("Analog inactive");

        }

	}

    public void OnBeginDrag(PointerEventData data)
    {
        anchorPos = data.position;

        Vector2 pos = data.position;

        pos.x /= Screen.width;
        pos.y /= Screen.height;

        pos.x *= 1920;
        pos.y *= 1080;

        pos.x -= 1920 / 2f;
        pos.y -= 1080 / 2f;

       
        analogPos = data.position;
        analogActive = true;

    }

    public void OnDrag(PointerEventData data)
    {
        analogPos = data.position;
    }

    public void OnEndDrag(PointerEventData data)
    {
        analogActive = false;
        shootingAnalog.transform.localPosition.Set(0, 0, 0);
    }
}

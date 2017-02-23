using UnityEngine;
using System.Collections;

public class AbilitiesController : MonoBehaviour {

    //public AbilityControl[] abilities;

    public Camera cam;

	void Start () {
	
	}
	
	void Update () {
        Vector2 mousePos = Input.mousePosition;
        mousePos.x -= Screen.width / 2;
        mousePos.y -= Screen.height / 2;
        float angle = Mathf.Atan2(mousePos.y, mousePos.x) * Mathf.Rad2Deg;
        gameObject.transform.LookAt(new Vector3(mousePos.x, 0, mousePos.y), new Vector3(0, 1, 0));
        //gameObject.transform.rotation = Quaternion.AngleAxis(-angle , new Vector3(0,1,0));

        //Vector3 mousePos = Input.mousePosition;
        //mousePos.z = cam.GetComponent<camFollowPlayer>().cameraHeight;
        //Vector3 lookPos = Camera.main.ScreenToWorldPoint(mousePos);
        //lookPos = lookPos - transform.position;
        //float angle

        
        //gameObject.transform.Rotate(0, angle, 0);
        //gameObject.transform.rotation = Quaternion.LookRotation(new Vector3(mousePos.x, 0, mousePos.y), new Vector3(0, 1, 0));
        
        //gameObject.transform.RotateAround(transform.position, new Vector3(0,1,0), Mathf.Atan2(mousePos.y, mousePos.x));

	}
}

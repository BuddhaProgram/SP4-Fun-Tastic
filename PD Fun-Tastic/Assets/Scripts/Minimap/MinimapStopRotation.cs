using UnityEngine;
using System.Collections;

public class MinimapStopRotation : MonoBehaviour {

    public Transform player = null;
    public float cameraHeight = 3.0f;
    private Camera cam = null;
    public float camAngle = 60f;
    public Plane ground;
    public GameObject MinimapMask;
    public GameObject MinimapBorder;
    public GameObject MinimapBig;

    public void Start()
    {
        cam = gameObject.GetComponent<Camera>();
        cam.transform.Rotate(90 - camAngle, 0, 0, Space.World);
        //cam = transform;
    }
    public void Update()
    {
        Vector3 pos = new Vector3(player.position.x, player.position.y, player.position.z);
        pos.y = player.position.y + cameraHeight;
        //pos.z -= (Mathf.Atan(camAngle) * cameraHeight);
        cam.orthographicSize = cameraHeight;
        cam.transform.localPosition = pos;

        if (Input.GetButton("Open Minimap"))
        {
            //cameraHeight = 40.0f;
            MinimapMask.SetActive(false);
            MinimapBorder.SetActive(false);
            MinimapBig.SetActive(true);
            cameraHeight = 40.0f;
            
        }
        else
        {
            MinimapMask.SetActive(true);
            MinimapBorder.SetActive(true);
            MinimapBig.SetActive(false);
            cameraHeight = 20.0f;
        }
    }

}

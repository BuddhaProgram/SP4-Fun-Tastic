using UnityEngine;
using System.Collections;

public class camFollowPlayer : MonoBehaviour {
    public Transform player = null;
    public float cameraHeight = 3.0f;
    private Camera cam = null;
    public float camAngle = 60f;
    public Plane ground;

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
        pos.z -= (Mathf.Atan(camAngle) * cameraHeight);
        cam.orthographicSize = cameraHeight;
        cam.transform.localPosition = pos;

    }

    void GetMouseOnPlane()
    {
        //RaycastHit hit;
        //Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        //float distance;
        //if (ground.collider.Raycast(ray, out hit, Mathf.Infinity))
        //{
        //    transform.position = hit.point;
        //}
        //return null;
    }
}

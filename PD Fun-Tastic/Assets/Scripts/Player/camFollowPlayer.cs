using UnityEngine;
using System.Collections;

public class camFollowPlayer : MonoBehaviour {
    public Transform player = null;
    public float cameraHeight = 3.0f;
    private Camera cam = null;
    public float camAngle = 60f;
    public GameObject ground;

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

    public Vector3 GetMouseOnPlane()
    {
        Vector3 result = new Vector3();
        Plane plane = new Plane(Vector3.up, ground.transform.position);
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        float distance=0f;
        if (plane.Raycast(ray,out distance))
        {
            result = ray.GetPoint(distance);
        }
        return result;
    }
}

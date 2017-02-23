using UnityEngine;
using System.Collections;

public class AbilityRangeIndicatorRenderer : MonoBehaviour {

    private GameObject projectileRangeRenderer;
    private GameObject AOERangeRenderer;

    

	// Use this for initialization
	void Start () {
        projectileRangeRenderer = GameObject.CreatePrimitive(PrimitiveType.Plane);
        projectileRangeRenderer.GetComponent<MeshCollider>().enabled = false;
        projectileRangeRenderer.GetComponent<MeshRenderer>().enabled = false;

        AOERangeRenderer = GameObject.CreatePrimitive(PrimitiveType.Plane);
        AOERangeRenderer.GetComponent<MeshCollider>().enabled = false;
        AOERangeRenderer.GetComponent<MeshRenderer>().enabled = false;
	}
	
	// Update is called once per frame
	void Update () {

        Vector2 mousePos = Input.mousePosition;
        mousePos.x -= Screen.width / 2;
        mousePos.y -= Screen.height / 2;

        if (projectileRangeRenderer.GetComponent<MeshRenderer>().enabled == true)
        {
            RaycastHit hit;

        }
        else if (AOERangeRenderer.GetComponent<MeshRenderer>().enabled == true)
        {

        }
	}
}

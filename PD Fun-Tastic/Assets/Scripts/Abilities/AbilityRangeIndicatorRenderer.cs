using UnityEngine;
using System.Collections;

public class AbilityRangeIndicatorRenderer : MonoBehaviour {

    private GameObject projectileRangeRenderer;
    private GameObject AOERangeRenderer;

    [HideInInspector]
    public float abilityRange = 1f;
    [HideInInspector]
    public bool skillInUse = false;
    [HideInInspector]
    public Vector3 fwd;

    public Camera cam;

	// Use this for initialization
	void Start () {
        projectileRangeRenderer = GameObject.CreatePrimitive(PrimitiveType.Plane);
        //projectileRangeRenderer.transform.Rotate(90, 0, 0, Space.World);
        projectileRangeRenderer.GetComponent<MeshCollider>().enabled = false;
        projectileRangeRenderer.GetComponent<MeshRenderer>().enabled = false;
        projectileRangeRenderer.transform.localScale.Set(0.1f, 0.1f, 0.1f);
        //projectileRangeRenderer.transform.localPosition.Set(0, , 0);

        Texture arrow = Resources.Load<Texture>("rangeIndicator");
        projectileRangeRenderer.GetComponent<Renderer>().material.mainTexture = arrow;
       

        AOERangeRenderer = GameObject.CreatePrimitive(PrimitiveType.Plane);
        AOERangeRenderer.GetComponent<MeshCollider>().enabled = false;
        AOERangeRenderer.GetComponent<MeshRenderer>().enabled = false;
        AOERangeRenderer.transform.localScale.Set(0.1f, 0.1f, 0.1f);
        Texture circle = Resources.Load<Texture>("MagicCircle");
        AOERangeRenderer.GetComponent<Renderer>().material.mainTexture = circle;
       
	}
	
	// Update is called once per frame
	void Update () {

        Vector3 mousePos = cam.GetComponent<camFollowPlayer>().GetMouseOnPlane();

        

        if (projectileRangeRenderer.GetComponent<MeshRenderer>().enabled == true)
        {
            float distance = (gameObject.transform.position - mousePos).magnitude;
            if(abilityRange<distance)
            {

                distance = abilityRange;
            }
            RaycastHit hit;
           
            if (Physics.Raycast(gameObject.transform.position, gameObject.transform.forward, out hit, distance))
            {
                if (hit.transform.tag == "Wall")
                {
                    distance = hit.distance;
                }
                
            }
            projectileRangeRenderer.transform.localScale = new Vector3(0.1f, 0.1f, 0.1f * distance);
            projectileRangeRenderer.transform.localPosition = gameObject.transform.position + (gameObject.transform.forward * ((distance / 2f) + 0.5f));
            //projectileRangeRenderer.transform.localPosition.Set(projectileRangeRenderer.transform.localPosition.x, cam.GetComponent<camFollowPlayer>().ground.transform.position.y, projectileRangeRenderer.transform.localPosition.z);
            projectileRangeRenderer.transform.Translate(0, 1, 0);

            projectileRangeRenderer.transform.LookAt(new Vector3(mousePos.x, 1f, mousePos.z), new Vector3(0, 1, 0));
            //projectileRangeRenderer.transform.Rotate(90, 0, 0, Space.World);
            }
        else if (AOERangeRenderer.GetComponent<MeshRenderer>().enabled == true)
        {
            AOERangeRenderer.transform.localPosition = cam.GetComponent<camFollowPlayer>().GetMouseOnPlane();
            AOERangeRenderer.transform.Translate(0, 1, 0);
            AOERangeRenderer.transform.localScale = new Vector3(0.1f * abilityRange, 1f, 0.1f * abilityRange);
        }
	}

    public void DrawProjectileAim(float range)
    {
        abilityRange = range;
        projectileRangeRenderer.GetComponent<MeshRenderer>().enabled = true;

        skillInUse = true;
    }

    public void DrawAOEAim(float range)
    {
        abilityRange = range;
        AOERangeRenderer.GetComponent<MeshRenderer>().enabled = true;
        skillInUse = true;
    }

    public void UndrawAim()
    {
        projectileRangeRenderer.GetComponent<MeshRenderer>().enabled = false;
        AOERangeRenderer.GetComponent<MeshRenderer>().enabled = false;
        skillInUse = false;
    }
}

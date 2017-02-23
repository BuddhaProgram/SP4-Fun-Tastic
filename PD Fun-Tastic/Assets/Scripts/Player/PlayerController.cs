using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

    public float f_moveSpeed = 1f;
    private Vector3 velocity = new Vector3(0,0,0);
    public SwapHotbar swapHotbar;
    public GameObject inventoryCanvas;
    public GameObject equipmentCanvas;
    public GameObject minimapCamera;
    private bool invOpen;
    private bool equipOpen;
    private bool swapToggle;
    
	void Start () {
	}
	
	void Update () {

        float forward = Input.GetAxis("ForwardMovement");
        float side = Input.GetAxis("SideMovement");
        velocity.Set(side * Time.deltaTime * f_moveSpeed, 0, forward * Time.deltaTime * f_moveSpeed);

        GetComponent<Rigidbody>().velocity = velocity ;

        //if (Input.GetKeyDown(KeyCode.I))
        if (Input.GetButtonDown("Open Inventory"))
        {
            invOpen = !invOpen;
            if (invOpen)
                inventoryCanvas.SetActive(true);
            else
                inventoryCanvas.SetActive(false);
        }

        //if (Input.GetKeyDown(KeyCode.E))
        if (Input.GetButtonDown("Open Equipment"))
        {
            equipOpen = !equipOpen;
            if (equipOpen)
                equipmentCanvas.SetActive(true);
            else
                equipmentCanvas.SetActive(false);
        }

        //if (Input.GetKeyDown(KeyCode.Tab))
        if (Input.GetButtonDown("Swap Hotbar"))
        {
            swapToggle = !swapToggle;
            if (swapToggle)
                swapHotbar.SwapHotbarItem();
            else
                swapHotbar.SwapHotbarItem();
        }

        //if (Input.GetKey(KeyCode.M))
        //if (Input.GetButton("Open Minimap"))
        //if (Input.GetButtonDown("Open Minimap"))
        //{
        //    Debug.Log(minimapCamera.transform.position.y);
        //    minimapCamera.transform.position += Vector3.up * 50;
        //}
	}

    void OnCollisionEnter(Collision collider)
    {
        //Destroy(gameObject);
        if (collider.gameObject.tag == "Enemy")
        {
            Physics.IgnoreCollision(collider.gameObject.GetComponent<SphereCollider>(),GetComponent<Collider>());
        }
     
    }
}

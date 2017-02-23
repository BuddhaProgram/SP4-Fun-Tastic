using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour {

    public float f_moveSpeed = 1f;
    private Vector3 velocity = new Vector3(0,0,0);

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {

        float forward = Input.GetAxis("ForwardMovement");
        float side = Input.GetAxis("SideMovement");
        velocity.Set(side * Time.deltaTime * f_moveSpeed, 0, forward * Time.deltaTime * f_moveSpeed);

        GetComponent<Rigidbody>().velocity = velocity ;

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

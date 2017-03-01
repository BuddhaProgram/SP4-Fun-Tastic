using UnityEngine;
using System.Collections;

public abstract class BaseProjectile : MonoBehaviour {

	public float speed = 5.0f;

	public abstract void FireProjectile (GameObject launcher,GameObject target, float damage);

  	void OnTriggerEnter(Collider collider)
	{
		if (collider.gameObject.tag == "Enemy") {
			Physics.IgnoreCollision (collider, this.GetComponent<Collider>());
		}
		if (collider.gameObject.tag == "Wall") {
			print ("fuck u");
			Destroy (gameObject);
		} 
		if (collider.gameObject.tag == "Player") {
			collider.gameObject.GetComponent<Health> ().ReceiveDamage (10);
			//print ("fuck u");
			Destroy (gameObject);
		} 


		//Destroy (gameObject);
	}

}

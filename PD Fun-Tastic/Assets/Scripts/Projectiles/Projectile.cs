using UnityEngine;
using System.Collections;


public class Projectile : MonoBehaviour {

    public float projectileSpeed;
    [HideInInspector]
    public Vector3 direction;
    public float damage = 10f;
    public string targetTag = "Enemy";
    public float range = 10f;

    private float distanceTravelled = 0f;
	// Use this for initialization
	void Start () {
        direction.Normalize();
	}
	
	// Update is called once per frame
	void Update () {
        //lifeTime -= Time.deltaTime;
        //if (lifeTime < 0)
        //{
        //   // Destroy(gameObject);
        //}
        distanceTravelled += projectileSpeed * Time.deltaTime;
        if (distanceTravelled > range)
        {
            Destroy(gameObject);
        }
        transform.rotation = Quaternion.LookRotation(direction);
        transform.Translate(direction * projectileSpeed * Time.deltaTime,Space.World);
        //GetComponent<Rigidbody>().velocity = direction * projectileSpeed * Time.deltaTime;
        
	}

    void OnTriggerEnter(Collider collider)
    {
        //Destroy(gameObject);
        if (collider.gameObject.tag == targetTag)
        {
            if (collider.GetType() == typeof(SphereCollider))
            {
                Physics.IgnoreCollision(collider.gameObject.GetComponent<SphereCollider>(), GetComponent<Collider>());
                return;
            }
            else {
                collider.gameObject.GetComponent<Health>().ReceiveDamage(damage);
                Destroy(gameObject);
            }
            
        }
        Destroy(gameObject);
        
    }

}

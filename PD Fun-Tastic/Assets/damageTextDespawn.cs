using UnityEngine;
using System.Collections;

public class damageTextDespawn : MonoBehaviour {

    private float lifetime = 3f;
    public float translateSpeed = 1f;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        lifetime -= Time.deltaTime;
        if (lifetime <= 0f)
        {
            Destroy(gameObject);
        }
        this.transform.Translate(new Vector3(0, 0, translateSpeed * Time.deltaTime),Space.World);
	}
}

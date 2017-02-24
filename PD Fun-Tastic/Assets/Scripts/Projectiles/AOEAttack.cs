using UnityEngine;
using System.Collections;

public class AOEAttack : MonoBehaviour {
    public float range;
    public int numOfPulses;
    private int currPulse;
    public float pulseFreq;
    private float timer;
    public float damage;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        timer += Time.deltaTime;
        if (timer > 1f / pulseFreq)
        {
            timer = 0f;
            currPulse++;
            Collider[] hitColliders = Physics.OverlapSphere(gameObject.transform.position, range);
            int i = 0;
            while (i < hitColliders.Length)
            {
                if (hitColliders[i].gameObject.tag == "Enemy")
                {
                    hitColliders[i].gameObject.GetComponent<Health>().ReceiveDamage(damage);
                }
                ++i;
            }
        }
        if (currPulse >= numOfPulses)
        {
            Destroy(gameObject);
        }



	}
}

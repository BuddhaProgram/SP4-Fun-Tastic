using UnityEngine;
using System.Collections;

public class NormalProjectile : BaseProjectile {

	Vector3 dir;
	bool fire;

	// Update is called once per frame
	void Update ()
	{
		if (fire)
		{
			transform.position += dir * (speed * Time.deltaTime);
		}
	}

	public override void FireProjectile (GameObject launcher,GameObject target, float damage)
	{
		if (launcher && target)
		{
			dir = (target.transform.position - launcher.transform.position).normalized;
			dir.y = target.transform.position.y;
			fire = true;
		}
	}
}

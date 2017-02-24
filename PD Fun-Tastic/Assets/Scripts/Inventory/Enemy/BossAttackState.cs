using UnityEngine;
using System.Collections;

public class BossAttackState : BossIEnemyState
{

	private readonly BossStatePatternEnemy enemy;
	public Animator[] animator;


	public BossAttackState(BossStatePatternEnemy statePatternEnemy)
	{
		enemy = statePatternEnemy;
	}

	public void UpdateState()
	{
		Look ();
		Attack();
	}

	public void OnTriggerEnter(Collider other)
	{

	}

	public void ToPatrolState()
	{

	}

	public void ToAlertState()
	{
		animator = enemy.GetComponentsInChildren<Animator> ();
		animator[0].SetTrigger("Idle");
		enemy.currentState = enemy.alertState;
	}

	public void ToAttackState()
	{

	}

	public void ToChaseState()
	{
		animator = enemy.GetComponentsInChildren<Animator> ();
		animator[0].SetTrigger("Walk");
		enemy.currentState = enemy.chaseState;
	}

	public void ToIdle()
	{
		animator = enemy.GetComponentsInChildren<Animator> ();
		animator[0].SetTrigger("Idle");
		enemy.currentState = enemy.idleState;
	}

	private void Look()
	{
		RaycastHit hit;
		Vector3 enemyToTarget = (enemy.chaseTarget.position + enemy.offset) - enemy.eyes.transform.position;
		if (Physics.Raycast(enemy.eyes.transform.position, enemyToTarget, out hit, enemy.sightRange) && hit.collider.CompareTag("Player"))
		{
			animator = enemy.GetComponentsInChildren<Animator> ();
			animator[0].SetTrigger("Walk");
			enemy.chaseTarget = hit.transform;

		}
	}

	private void Attack()
	{
		Debug.Log (enemy.attRan);

		if (enemy.attRan == 1)
		{
			animator = enemy.GetComponentsInChildren<Animator> ();
			animator[0].SetTrigger("RangeAttack");
			enemy.fireTimer += Time.deltaTime;
			Vector3 playerDir = (enemy.target.transform.position - enemy.transform.position).normalized;
			Quaternion lookRotation = Quaternion.LookRotation (new Vector3 (playerDir.x, 0, playerDir.z));
			enemy.transform.rotation = Quaternion.Slerp (enemy.transform.rotation, lookRotation, Time.deltaTime * 10);

			float enemyTarget = Vector3.Distance (enemy.target.transform.position, enemy.transform.position);

			if (enemy.fireTimer >= enemy.fireRate) {
				float angle = Quaternion.Angle (enemy.transform.rotation, Quaternion.LookRotation (enemy.target.transform.position - enemy.transform.position));

				if (angle < enemy.fieldOfView) {
					enemy.SpawnProjectile ();
					enemy.fireTimer = 0;
					if (enemyTarget > 4) {
						ToAlertState ();
					}
				}
			}

			enemy.navMeshAgent.Resume ();
		}
		if (enemy.attRan == 2) 
		{
			animator = enemy.GetComponentsInChildren<Animator> ();
			animator[0].SetTrigger("CloseAttack");
			RaycastHit hit;
			Vector3 enemyToTarget = (enemy.chaseTarget.position + enemy.offset) - enemy.eyes.transform.position;
			float dashTimer = 0;
			dashTimer += Time.deltaTime;
			enemy.navMeshAgent.acceleration = 150;
			enemy.navMeshAgent.speed = 150;


			//	animator = enemy.GetComponentsInChildren<Animator> ();

			if (Physics.Raycast (enemy.eyes.transform.position, enemyToTarget, out hit, 1f) && hit.collider.CompareTag ("Player")) {
				enemy.navMeshAgent.Stop ();
				hit.collider.GetComponent<Health> ().ReceiveDamage (10);
				ToIdle ();
			} 
			else
			{
				ToChaseState ();
			}
		}
	}
}
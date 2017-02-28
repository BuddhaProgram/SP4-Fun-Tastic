using UnityEngine;
using System.Collections;

public class BossAttackStateMelee : BossIEnemyState
{

	private readonly BossStatePatternEnemy enemy;
	public Animator[] animator;


	public BossAttackStateMelee(BossStatePatternEnemy statePatternEnemy)
	{
		enemy = statePatternEnemy;
	}

	public void UpdateState()
	{
		Look ();
		Attack();
	}

	public void ToHeal()
	{
		animator = enemy.GetComponentsInChildren<Animator> ();
		animator[0].SetTrigger("Walk");
		enemy.currentState = enemy.healState;
	}

	public void ToRun()
	{
		animator = enemy.GetComponentsInChildren<Animator> ();
		animator[0].SetTrigger("Walk");
		enemy.currentState = enemy.runState;
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
			if (enemy.GetComponent<Health> ().health >= 30) {
				animator = enemy.GetComponentsInChildren<Animator> ();
				animator [0].SetTrigger ("Walk");
				enemy.chaseTarget = hit.transform;
				ToChaseState ();
			}
			else
			{
				ToRun ();
			}
		}
	}

	private void Attack()
	{

			animator = enemy.GetComponentsInChildren<Animator> ();
			animator[0].SetTrigger("CloseAttack");
			RaycastHit hit;
			Vector3 enemyToTarget = (enemy.chaseTarget.position + enemy.offset) - enemy.eyes.transform.position;
			float dashTimer = 0;
			dashTimer += Time.deltaTime;
			enemy.navMeshAgent.acceleration = 300;
			enemy.navMeshAgent.speed = 300;


			//	animator = enemy.GetComponentsInChildren<Animator> ();

			if (Physics.Raycast (enemy.eyes.transform.position, enemyToTarget, out hit, 1f) && hit.collider.CompareTag ("Player")) {
				enemy.navMeshAgent.acceleration = 0;
				enemy.navMeshAgent.velocity = new Vector3 (0,0,0);
				enemy.navMeshAgent.speed = 0;
				enemy.navMeshAgent.Stop ();
				hit.collider.GetComponent<Health> ().ReceiveDamage (10);
				ToIdle ();
			} 
	}
}
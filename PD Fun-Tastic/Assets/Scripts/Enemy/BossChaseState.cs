using UnityEngine;
using System.Collections;

public class BossChaseState : BossIEnemyState
{

	private readonly BossStatePatternEnemy enemy;
	public Animator[] animator;

	public BossChaseState(BossStatePatternEnemy statePatternEnemy)
	{
		enemy = statePatternEnemy;
	}

	public void UpdateState()
	{
		Look();
		Chase();
	}

	public void OnTriggerEnter(Collider other)
	{

	}

	public void ToIdle()
	{

	}

	public void ToPatrolState()
	{

	}

	public void ToHeal()
	{
		animator = enemy.GetComponentsInChildren<Animator> ();
		animator[0].SetTrigger("Walk");
		enemy.currentState = enemy.healState;
	}


	public void ToAlertState()
	{
		animator = enemy.GetComponentsInChildren<Animator> ();
		animator[0].SetTrigger("Idle");
		enemy.currentState = enemy.alertState;
	}

	public void ToChaseState()
	{

	}

	public void ToRun()
	{
		animator = enemy.GetComponentsInChildren<Animator> ();
		animator[0].SetTrigger("Walk");
		enemy.currentState = enemy.runState;
	}

	public void ToAttackState()
	{
		if (Random.Range (1, 3) == 1) {
			enemy.currentState = enemy.attackStateRange;
		} else {
			enemy.currentState = enemy.attackStateMelee;
		}
	}

	private void Look()
	{
		RaycastHit hit;
		Vector3 enemyToTarget = (enemy.chaseTarget.position + enemy.offset) - enemy.eyes.transform.position;
		if (Physics.Raycast(enemy.eyes.transform.position, enemyToTarget, out hit, enemy.sightRange) && hit.collider.CompareTag("Player"))
		{
			enemy.chaseTarget = hit.transform;

		}
		else
		{
			ToAlertState();
		}

	}

	private void Chase()
	{
		enemy.navMeshAgent.acceleration = enemy.enemyAccelerationSpeed;
		enemy.navMeshAgent.speed = enemy.enemyChaseSpeed * Time.deltaTime;
		enemy.meshRendererFlag.material.color = Color.red;
		enemy.navMeshAgent.destination = enemy.chaseTarget.position;
		RaycastHit hit;
		Vector3 enemyToTarget = (enemy.chaseTarget.position + enemy.offset) - enemy.eyes.transform.position;
		if (Physics.Raycast(enemy.eyes.transform.position, enemyToTarget, out hit, 4f) && hit.collider.CompareTag("Player"))
		{
			ToAttackState ();
		}
		enemy.navMeshAgent.Resume();
	}
}

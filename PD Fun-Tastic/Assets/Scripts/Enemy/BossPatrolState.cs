using UnityEngine;
using System.Collections;

public class BossPatrolState : BossIEnemyState
{

	private readonly BossStatePatternEnemy enemy;
	private int nextWayPoint;
	public Animator[] animator;

	public BossPatrolState(BossStatePatternEnemy statePatternEnemy)
	{
		enemy = statePatternEnemy;
	}

	public void UpdateState()
	{
		Look();
		Patrol();
	}

	public void ToAttackState()
	{

	}

	public void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.CompareTag("Player"))
			ToAlertState();
	}
	public void ToIdle()
	{

	}
	public void ToPatrolState()
	{
		Debug.Log("Can't transition to same state");
	}

	public void ToAlertState()
	{
		animator = enemy.GetComponentsInChildren<Animator> ();
		animator[0].SetTrigger("Idle");
		enemy.currentState = enemy.alertState;
	}

	public void ToChaseState()
	{
		animator = enemy.GetComponentsInChildren<Animator> ();
		animator[0].SetTrigger("Walk");
		enemy.currentState = enemy.chaseState;
	}

	private void Look()
	{
		RaycastHit hit;
		if (Physics.Raycast(enemy.eyes.transform.position, enemy.eyes.transform.forward, out hit, enemy.sightRange) && hit.collider.CompareTag("Player"))
		{
			animator = enemy.GetComponentsInChildren<Animator> ();
			animator[0].SetTrigger("Walk");
			enemy.chaseTarget = hit.transform;
			ToChaseState();
		}
	}

	void Patrol()
	{
		animator = enemy.GetComponentsInChildren<Animator> ();
		animator[0].SetTrigger("Walk");
		enemy.navMeshAgent.acceleration = enemy.enemyAccelerationSpeed;
		enemy.navMeshAgent.speed = enemy.enemyPatrolSpeed * Time.deltaTime;
		enemy.meshRendererFlag.material.color = Color.green;
		enemy.navMeshAgent.destination = enemy.wayPoints [nextWayPoint].position;

		if (enemy.navMeshAgent.remainingDistance <= enemy.navMeshAgent.stoppingDistance && !enemy.navMeshAgent.pathPending)
		{
			animator = enemy.GetComponentsInChildren<Animator> ();
			animator[0].SetTrigger("Walk");
			nextWayPoint = (nextWayPoint + 1) % enemy.wayPoints.Length;
		}
		enemy.navMeshAgent.Resume();
	}
}


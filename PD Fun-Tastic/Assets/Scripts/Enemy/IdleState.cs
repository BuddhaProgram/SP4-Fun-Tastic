using UnityEngine;
using System.Collections;

public class IdleState : IEnemyState 
{

	private readonly StatePatternEnemy enemy;
	private float searchTimer;
	private float idleTimer = 0;

	public Animator[] animator;

	public IdleState(StatePatternEnemy statePatternEnemy)
	{
		enemy = statePatternEnemy;
	}

	public void UpdateState()
	{
		Idle ();
	}

	public void OnTriggerEnter(Collider other)
	{

	}

	public void ToIdle()
	{
		Debug.Log("Can't transition to same state");
	}

	public void ToAttackState()
	{

	}

	public void ToPatrolState()
	{
		animator = enemy.GetComponentsInChildren<Animator> ();
		animator[0].SetTrigger("Walk");
		enemy.currentState = enemy.patrolState;
	}

	public void ToAlertState()
	{
		
	}

	public void ToRun()
	{
		animator = enemy.GetComponentsInChildren<Animator> ();
		animator[0].SetTrigger("Walk");
		enemy.currentState = enemy.runState;
	}

	public void ToChaseState()
	{
		animator = enemy.GetComponentsInChildren<Animator> ();
		animator[0].SetTrigger("Walk");
		enemy.currentState = enemy.chaseState;
		searchTimer = 0f;
	}
		

	private void Idle()
	{
		animator = enemy.GetComponentsInChildren<Animator> ();
		animator[0].SetTrigger("Idle");
		idleTimer += Time.deltaTime;
		enemy.navMeshAgent.Stop ();


		if (idleTimer > 1) 
		{
			ToPatrolState ();
			idleTimer = 0;
		}
	}

}

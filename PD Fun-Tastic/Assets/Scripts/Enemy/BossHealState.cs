using UnityEngine;
using System.Collections;


public class BossHealState : BossIEnemyState 
{

	private readonly BossStatePatternEnemy enemy;
	private float searchTimer;
	private float healTimer = 0;

	public Animator[] animator;

	public BossHealState(BossStatePatternEnemy statePatternEnemy)
	{
		enemy = statePatternEnemy;
	}

	public void UpdateState()
	{
		Heal ();
	}

	public void OnTriggerEnter(Collider other)
	{

	}

	public void ToRun()
	{
		
	}

	public void ToIdle()
	{
		Debug.Log("Can't transition to same state");
	}

	public void ToAttackState()
	{

	}

	public void ToHeal()
	{

	}


	public void ToPatrolState()
	{
		animator = enemy.GetComponentsInChildren<Animator> ();
		animator [0].SetTrigger ("Walk");
		enemy.currentState = enemy.patrolState;
	}

	public void ToAlertState()
	{

	}

	public void ToChaseState()
	{
		animator = enemy.GetComponentsInChildren<Animator> ();
		animator [0].SetTrigger ("Walk");
		enemy.currentState = enemy.chaseState;
		searchTimer = 0f;
	}


	private void Heal()
	{
		enemy.navMeshAgent.Stop ();
		enemy.transform.position = enemy.transform.position;
		animator = enemy.GetComponentsInChildren<Animator> ();
		animator [0].SetTrigger ("Heal");

		enemy.GetComponent<Health> ().Heal(0.2f);

		healTimer += Time.deltaTime;

		if (healTimer > 2) 
		{
			ToPatrolState ();
			healTimer = 0;
		}
	}
}

using UnityEngine;
using System.Collections;


public class BossRunState : BossIEnemyState 
{

	private readonly BossStatePatternEnemy enemy;
	private float searchTimer;
	private float runTimer = 0;

	public Animator[] animator;

	public BossRunState(BossStatePatternEnemy statePatternEnemy)
	{
		enemy = statePatternEnemy;
	}

	public void UpdateState()
	{
		Run ();
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
		animator = enemy.GetComponentsInChildren<Animator> ();
		animator [0].SetTrigger ("Heal");
		enemy.currentState = enemy.healState;
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


	private void Run()
	{
		enemy.navMeshAgent.Stop ();
		animator = enemy.GetComponentsInChildren<Animator> ();
		animator [0].SetTrigger ("Walk");
		Vector3 playerDir = (enemy.chaseTarget.transform.position - enemy.transform.position).normalized;
		Quaternion lookRotation = Quaternion.LookRotation (new Vector3(-playerDir.x,0,-playerDir.z));
		enemy.transform.rotation = Quaternion.Slerp (enemy.transform.rotation,lookRotation,Time.deltaTime * 10);
		enemy.transform.position -= ((enemy.chaseTarget.transform.position - enemy.transform.position).normalized * Time.deltaTime) * 3;

		runTimer += Time.deltaTime;

		if (runTimer > 2) 
		{
			ToHeal ();
			runTimer = 0;
		}
	}
}

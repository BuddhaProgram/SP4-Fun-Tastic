using UnityEngine;
using System.Collections;

public class AttackState : IEnemyState
{

    private readonly StatePatternEnemy enemy;
	public Animator[] animator;


    public AttackState(StatePatternEnemy statePatternEnemy)
    {
        enemy = statePatternEnemy;
    }

    public void UpdateState()
    {
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
        
    }
    
    public void ToAttackState()
    {

    }


	public void ToIdle()
	{
		animator = enemy.GetComponentsInChildren<Animator> ();
		animator[0].SetTrigger("Idle");
		enemy.currentState = enemy.idleState;
	}

    public void ToChaseState()
	{
		animator = enemy.GetComponentsInChildren<Animator> ();
		animator[0].SetTrigger("Walk");
		enemy.currentState = enemy.chaseState;
    }


    private void Attack()
    {
        RaycastHit hit;
        Vector3 enemyToTarget = (enemy.chaseTarget.position + enemy.offset) - enemy.eyes.transform.position;
		float dashTimer = 0;
		dashTimer += Time.deltaTime;
		enemy.navMeshAgent.acceleration = 150;
		enemy.navMeshAgent.speed = 150;


		//	animator = enemy.GetComponentsInChildren<Animator> ();

		if (Physics.Raycast (enemy.eyes.transform.position, enemyToTarget, out hit, 1f) && hit.collider.CompareTag ("Player")) {
			animator = enemy.GetComponentsInChildren<Animator> ();
			animator[0].SetTrigger("Attack");
			enemy.navMeshAgent.Stop (true);
			hit.collider.GetComponent<Health> ().ReceiveDamage (10);
			ToIdle ();
		} 
		else
		{
			animator = enemy.GetComponentsInChildren<Animator> ();
			animator[0].SetTrigger("Walk");
			ToChaseState ();
		}
    }


}
using UnityEngine;
using System.Collections;

public class ChaseState : IEnemyState
{

    private readonly StatePatternEnemy enemy;
	public Animator[] animator;

    public ChaseState(StatePatternEnemy statePatternEnemy)
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

	public void ToRun()
	{
		animator = enemy.GetComponentsInChildren<Animator> ();
		animator[0].SetTrigger("Walk");
		enemy.currentState = enemy.runState;
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

    public void ToChaseState()
    {

    }


	public void ToIdle()
	{

	}

    public void ToAttackState()
    {
		animator = enemy.GetComponentsInChildren<Animator> ();
		animator[0].SetTrigger("Attack");
        enemy.currentState = enemy.attackState;
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
			}
			else
			{
				ToRun ();
			}
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
			animator = enemy.GetComponentsInChildren<Animator> ();
			animator[0].SetTrigger("Attack");
            ToAttackState();
        }
        enemy.navMeshAgent.Resume();
    }
}

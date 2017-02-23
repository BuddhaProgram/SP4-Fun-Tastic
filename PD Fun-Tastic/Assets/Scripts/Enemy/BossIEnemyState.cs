using UnityEngine;
using System.Collections;

public interface BossIEnemyState
{

    void UpdateState();

    void OnTriggerEnter(Collider other);

    void ToPatrolState();

    void ToAlertState();

    void ToChaseState();

    void ToAttackState();

	void ToIdle();
}
using UnityEngine;
using System.Collections;

public interface RangeIEnemyState
{

    void UpdateState();

    void OnTriggerEnter(Collider other);

    void ToPatrolState();

    void ToAlertState();

    void ToChaseState();

    void ToAttackState();

	void ToRun ();
}
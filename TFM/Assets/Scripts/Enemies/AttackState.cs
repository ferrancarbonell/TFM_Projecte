using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackState : IRobotState
{
    RobotAI myEnemy;
    
    public AttackState(RobotAI enemy)
    {
        myEnemy = enemy;
    }

    public void UpdateState()
    {
        myEnemy.anim.SetTrigger("Hit");
        myEnemy.navMeshAgent.isStopped = true;
        myEnemy.navMeshAgent.autoBraking = false;
    }

    public void GoToAlertState(){}
    public void GoToAttackState(){}
    public void GoToPatrolState(){}
    public void OnTriggerEnter(Collider other){}
    public void OnTriggerStay(Collider other){}
    public void OnTriggerExit(Collider other){}
}

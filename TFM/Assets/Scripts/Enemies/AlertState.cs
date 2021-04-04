using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlertState : IRobotState
{
    RobotAI myEnemy;
    
    public AlertState(RobotAI enemy)
    {
        myEnemy = enemy;
    }

    public void UpdateState()
    {
        myEnemy.myLight.color = Color.red;
        //myEnemy.ChangeToAlertMaterial();
        myEnemy.anim.SetBool("Patrol",false);
        myEnemy.anim.SetBool("Alert",true);
        myEnemy.navMeshAgent.speed = 1.5f;
        myEnemy.navMeshAgent.destination = myEnemy.player.transform.position;

            // Si encuentra al player pasa al estado Attack
            RaycastHit hit;
            if (Physics.Raycast(
                new Ray
                    (new Vector3(myEnemy.transform.position.x,
                                    0.5f,
                                    myEnemy.transform.position.z),
                    myEnemy.transform.forward * 100f)
                    ,out hit))
            {
                if(hit.collider.gameObject.tag != "Player")
                {
                    GoToPatrolState();
                }
            }
        //currentRotationTime += Time.deltaTime;
    }

    public void GoToAlertState(){}

    public void GoToAttackState()
    {
        myEnemy.currentState = myEnemy.attackState;
    }

    public void GoToPatrolState()
    {
        myEnemy.currentState = myEnemy.patrolState;
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            GoToAttackState();
        }
    }
    public void OnTriggerStay(Collider other){}
    public void OnTriggerExit(Collider other){}
}


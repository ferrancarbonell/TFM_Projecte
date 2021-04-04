using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatrolState : IRobotState
{
    RobotAI myEnemy;
    private int nextWayPoint = 0;
    
    public PatrolState(RobotAI enemy)
    {
        myEnemy = enemy;
    }

    public void UpdateState()
    {
        myEnemy.anim.SetBool("Patrol",true);
        myEnemy.anim.SetBool("Alert",false);
        myEnemy.navMeshAgent.speed = 0.7f;
        // El enemigo patrulla por los waypoints marcados
        myEnemy.myLight.color = Color.cyan;
        myEnemy.navMeshAgent.destination = myEnemy.wayPoints[nextWayPoint].position;
        if(myEnemy.navMeshAgent.remainingDistance <= myEnemy.navMeshAgent.stoppingDistance)
        {
            nextWayPoint = (nextWayPoint + 1) % myEnemy.wayPoints.Length;
        }
        // Si ve el player pasa al estado de atacar
        RaycastHit hit;
            if (Physics.Raycast(
                new Ray
                    (new Vector3(myEnemy.transform.position.x,
                                    0.5f,
                                    myEnemy.transform.position.z),
                    myEnemy.transform.forward * 200f)
                    ,out hit))
            {
                /*Debug.DrawLine(new Vector3(myEnemy.transform.position.x,
                                    0.5f,
                                    myEnemy.transform.position.z),
                     (myEnemy.transform.forward * 100f), Color.green, 2);*/
                if(hit.collider.gameObject.tag == "Player")
                {
                    Debug.Log("Jugador detectat");
                    GoToAlertState();
                }
            }
    }

    public void GoToAlertState()
    {
        //myEnemy.navMeshAgent.isStopped = true;
        myEnemy.currentState = myEnemy.alertState;
    }


    public void GoToAttackState(){}

    public void GoToPatrolState(){}

    public void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
            GoToAlertState();
    }

    public void OnTriggerStay(Collider other)
    {
        if(other.gameObject.tag == "Player")
            GoToAlertState();
    }
    public void OnTriggerExit(Collider other){}
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBallAI : MonoBehaviour
{
    public float maxSpeed = 10f;
	public float move = -0.1f;
	public float distance = 0.5f;

    enum EnemyState {alive, inactive}
	EnemyState enemyState;
    Rigidbody myRigidbody;
    AlarmBehaviour alarmBehaviour;

    void Start()
    {
        myRigidbody = GetComponent<Rigidbody>();
        alarmBehaviour = GetComponent<AlarmBehaviour>();

        enemyState = EnemyState.alive;
    }

    void Update()
    {
        if (!alarmBehaviour.activatedFireBall)
            enemyState = EnemyState.alive;
        if (alarmBehaviour.activatedFireBall)
            enemyState = EnemyState.inactive;
    }

    void FixedUpdate() 
    {
        if (enemyState == EnemyState.alive)
            myRigidbody.velocity = new Vector3 (move * maxSpeed, myRigidbody.velocity.y,myRigidbody.velocity.y);
        if (enemyState == EnemyState.inactive)
            myRigidbody.velocity = new Vector3 (0,0,0);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player" && enemyState == EnemyState.alive)
        {
            Debug.Log ("Player death");

            GameObject.Find("GameManager").GetComponent<GameManager>().GameOver();
        }
            
    }
}

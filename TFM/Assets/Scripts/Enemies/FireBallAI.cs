using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBallAI : MonoBehaviour
{
    public float maxSpeed = 10f;
	public float move = -0.1f;
	public float distance = 0.5f;
    public GameObject damage;

    private enum EnemyState {alive, inactive}
	private EnemyState enemyState;
    private Rigidbody myRigidbody;
    private AlarmBehaviour alarmBehaviour;
    private GameManager gameManager;

    void Start()
    {
        myRigidbody = GetComponent<Rigidbody>();
        alarmBehaviour = GetComponent<AlarmBehaviour>();
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        enemyState = EnemyState.alive;
    }

    void Update()
    {
        if (!alarmBehaviour.activatedFireBall)
        {
            enemyState = EnemyState.alive;
            damage.SetActive(true);
        }
        if (alarmBehaviour.activatedFireBall)
        {
            enemyState = EnemyState.inactive;
            damage.SetActive(false);
        }
    }

    void FixedUpdate() 
    {
        if (enemyState == EnemyState.alive)
            myRigidbody.velocity = new Vector3 (move * maxSpeed, myRigidbody.velocity.y,myRigidbody.velocity.y);
        if (enemyState == EnemyState.inactive)
            myRigidbody.velocity = Vector3.zero;
    }

    void OnTriggerEnter(Collider other)
    {
        if (gameManager.isPlayerAlive && other.tag == "Player" && enemyState == EnemyState.alive)
            gameManager.GameOver();
    }

    void OnTriggerStay(Collider other)
    {
        if (gameManager.isPlayerAlive && other.tag == "Player" && enemyState == EnemyState.alive)
            gameManager.GameOver();
    }
}

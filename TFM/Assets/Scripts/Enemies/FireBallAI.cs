using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBallAI : MonoBehaviour
{
    public float maxSpeed = 10f;
	public float move = -0.1f;
	public float distance = 0.5f;
    public GameObject damage;
    public ParticleSystem fire;
    public ParticleSystem ice;

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
            fire.Play();
            ice.Stop();
        }
        if (alarmBehaviour.activatedFireBall)
        {
            enemyState = EnemyState.inactive;
            damage.SetActive(false);
            fire.Stop();
            ice.Play();
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

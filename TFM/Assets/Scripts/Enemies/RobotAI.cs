using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class RobotAI : MonoBehaviour
{
    [HideInInspector] public PatrolState patrolState;
    [HideInInspector] public AlertState alertState;
    [HideInInspector] public AttackState attackState;
    [HideInInspector] public IRobotState currentState;

    [HideInInspector] public NavMeshAgent navMeshAgent;
    [HideInInspector] public GameObject player;
    [HideInInspector] public Animator anim;
    [HideInInspector] public GameManager gameManager;

    public Light myLight;
    public float bulletForwardForce = 300;
    public float timeBetweenShoots = 1f;
    public int damageForce = 10;
    public float rotationTime = 10f;
    public float shootHeight = 0.5f;
    public Transform[] wayPoints;
    public Material alertMaterial;
    private SkinnedMeshRenderer[] afectedMeshObjects;

    void Start()
    {
        player = GameObject.FindWithTag("Player");
        anim = GetComponent<Animator>();
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();

        //S'inicialitzen els estats i s'assigna l'estat patrol com actual
        patrolState = new PatrolState(this);
        alertState = new AlertState(this);
        attackState = new AttackState(this);

        currentState = patrolState;

        navMeshAgent = GetComponent<NavMeshAgent>();
        afectedMeshObjects = GetComponentsInChildren<SkinnedMeshRenderer>();
    }

    void Update()
    {
        currentState.UpdateState();
    }

    public void HitPlayer()
    {
        if (gameManager.isPlayerAlive)
            gameManager.GameOver();
    }

    public void ChangeToAlertMaterial()
    {
        foreach (var currentAfectedObject in afectedMeshObjects)
        {
            currentAfectedObject.materials[0] = alertMaterial;
            Debug.Log("Done");
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        currentState.OnTriggerEnter(other);
    }
    private void OnTriggerStay(Collider other)
    {
        currentState.OnTriggerStay(other);
    }
    private void OnTriggerExit(Collider other)
    {
        currentState.OnTriggerExit(other);
    }
}

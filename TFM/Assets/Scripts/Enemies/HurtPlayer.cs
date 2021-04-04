using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HurtPlayer : MonoBehaviour
{
    private GameManager gameManager;

    void Start()
    {
       gameManager = GameObject.Find("GameManager").GetComponent<GameManager>(); 
    }

    void OnTriggerEnter(Collider other)
    {
        if (gameManager.isPlayerAlive && other.tag == "Player")
            gameManager.GameOver();
    }
}

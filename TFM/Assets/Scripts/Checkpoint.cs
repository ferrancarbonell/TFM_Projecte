using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    public ParticleSystem getCheck;
    private RespawnManager respawnManager;
    private AudioSource audioSource;

    void Start()
    {
        respawnManager = GameObject.FindGameObjectWithTag("Respawn").GetComponent<RespawnManager>();
        getCheck.Stop();
        audioSource = GetComponent<AudioSource>();
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            respawnManager.lastCheckpointPos = transform.position;
            getCheck.Play();
            audioSource.Play();
        }
    }
}

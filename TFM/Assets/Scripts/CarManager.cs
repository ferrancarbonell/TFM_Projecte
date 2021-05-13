using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarManager : MonoBehaviour
{
    public GameObject car;
    public float thrust = 1.0f;
    private Animator anim;
    private AudioSource audioSource;
    
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        anim = car.GetComponent<Animator>();
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            audioSource.Play();
            anim.enabled = true;
            Debug.Log("Arrenca cotxe");
        }
    }
}

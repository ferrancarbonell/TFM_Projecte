using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformBehaviour : MonoBehaviour
{
    public bool activated = false;

    public GameObject player;

    private Animator anim;
 
    void Start ()
    {
        anim = GetComponent<Animator>();
        player = GameObject.FindWithTag("Player");
    }

    public void Activate()
    {
        anim.SetBool ("Activate", true);
        activated = true;
    }
 
    public void Disactivate()
    {
        anim.SetBool ("Activate", false);
        activated = false;
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == player)
            player.transform.parent = transform;
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject == player)
            player.transform.parent = null;
    }
}

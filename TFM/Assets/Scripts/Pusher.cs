using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pusher : MonoBehaviour
{
    public GameObject target;
    private Animator anim;
    private bool activate = false;

    void Start()
    {
        anim = GetComponentInChildren<Animator>();
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            activate = true;
            target.GetComponent<DoorBehaviour>().Activate();
            anim.SetBool ("Activate", activate);
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            activate = false;
            target.GetComponent<DoorBehaviour>().Deactivate();
            anim.SetBool ("Activate", activate);
        }
    }
}

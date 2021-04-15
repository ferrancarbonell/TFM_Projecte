using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pusher : MonoBehaviour
{
    public GameObject target;
    private Animator anim;
    private bool activate = false;
    private bool rockOver = false;

    void Start()
    {
        anim = GetComponentInChildren<Animator>();
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            if (!activate)
            {
                activate = true;
                target.GetComponent<DoorBehaviour>().Activate();
                anim.SetBool ("Activate", activate);
            }
        }

        if (other.gameObject.tag == "Enemy")
        {
            if (!activate)
            {
                activate = true;
                target.GetComponent<DoorBehaviour>().Activate();
                anim.SetBool ("Activate", activate);
                rockOver = true;
            }
        }
    }

    void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            if (!activate)
            {
                activate = true;
                target.GetComponent<DoorBehaviour>().Activate();
                anim.SetBool ("Activate", activate);
            }
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            if (!rockOver)
            {
                activate = false;
                target.GetComponent<DoorBehaviour>().Deactivate();
                anim.SetBool ("Activate", activate);
            }
        }
    }
}

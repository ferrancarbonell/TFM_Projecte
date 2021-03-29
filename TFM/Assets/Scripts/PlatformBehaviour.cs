using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformBehaviour : MonoBehaviour
{
    public bool activated = false;

    private Animator anim;
 
    void Start ()
    {
        anim = GetComponent<Animator>();
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
}

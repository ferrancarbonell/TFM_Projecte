using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Fade : MonoBehaviour
{
    private Animator anim;

    void Start()
    {
        anim = GetComponent<Animator>();
        FadeIn();
    }

    public void FadeIn()
    {
        anim.SetBool("Fadein",true);
    }

    public void FadeOut()
    {
        anim.SetBool("Fadein",false);
    }
}

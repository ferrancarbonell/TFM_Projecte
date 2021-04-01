using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorBehaviour : MonoBehaviour
{
    public bool opened = false;
    public bool activated = false;
    public GameObject mesh;

    private Animator anim;
    private Material oldMat;
 
    void Start ()
    {
        anim = GetComponent<Animator>();
        oldMat = mesh.GetComponent<MeshRenderer>().material;

        if (opened)
            OpenDoor();
    }

    public void OpenDoor()
    {
        anim.SetBool ("Opened", true);
        opened = true;
    }
 
    public void CloseDoor()
    {
        anim.SetBool ("Opened", false);
        opened = false;
    }

    public void Activate()
    {
        activated = true;
        
        if (GameObject.Find("GameManager").GetComponent<AlarmManager>().alarmState == AlarmManager.AlarmState.Red)
        {
            mesh.GetComponent<MeshRenderer>().material = GetComponent<AlarmBehaviour>().redMat;
            //Debug.Log("canvi color");
        }
        else
            mesh.GetComponent<MeshRenderer>().material = GetComponent<AlarmBehaviour>().blueMat;

        OpenDoor();
    }
    public void Deactivate()
    {
        activated = false;
        mesh.GetComponent<MeshRenderer>().material = oldMat;
    }
}

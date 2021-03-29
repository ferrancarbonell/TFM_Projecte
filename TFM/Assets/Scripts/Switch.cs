using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Switch : MonoBehaviour
{
    public GameObject target;
    private bool ready = false;
    private bool activated = false;
    private enum AlarmStateStart {door, light, platform};
    private AlarmStateStart alarmStateStart;

    void Start()
    {
    }
    void Update()
    {
        if (Input.GetButtonDown("Fire1") && ready)
        {
            if (!activated)
                Activate();
            if (activated)
                Disactivate();
            
            activated = !activated;
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            ready = true;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            ready = false;
        }
    }

    void Activate()
    {
        target.GetComponent<DoorBehaviour>().Activate();
    }

    void Disactivate()
    {
        target.GetComponent<DoorBehaviour>().Disactivate();
    }
}

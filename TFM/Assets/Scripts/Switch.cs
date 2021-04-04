using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Switch : MonoBehaviour
{
    public GameObject target;
    private bool ready = false;
    private bool activated = false;
    private enum targetType {door, light, platform};
    private targetType alarmStateStart;

    void Update()
    {
        if (Input.GetButtonDown("Fire1") && ready)
            ToggleActivity();
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
            ready = true;
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
            ready = false;
    }

    void Activate()
    {
        target.GetComponent<DoorBehaviour>().Activate();
        activated = true;
    }

    void Deactivate()
    {
        target.GetComponent<DoorBehaviour>().Deactivate();
        activated = false;
    }

    void ToggleActivity()
    {
        if (activated)
            Deactivate();
        else
            Activate();
}
}

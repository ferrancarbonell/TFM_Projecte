using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlarmBehaviour : MonoBehaviour
{
    public bool changeColor = false;
    public bool changeMovement = false;
    public bool disappear = false;
    public bool turnLight = false;
    public Material blueMat;
    public Material redMat;
    public enum AlarmStateStart {Blue, Red};
    public AlarmStateStart alarmStateStart;

    private bool changeMaterial;

    void Start()
    {
        if (changeColor)
            if (alarmStateStart == AlarmStateStart.Blue)
                changeMaterial = true;
            if (alarmStateStart == AlarmStateStart.Red)
                changeMaterial = false;

        if (turnLight)
            if (alarmStateStart == AlarmStateStart.Red)
                gameObject.GetComponent<Light>().enabled = false;
    }

    public void ChangeState ()
    {
        if (changeColor)
        {
            if (changeMaterial)
                gameObject.GetComponent<MeshRenderer>().material = redMat;
            if (!changeMaterial)
                gameObject.GetComponent<MeshRenderer>().material = blueMat;

            changeMaterial = !changeMaterial;   
        }

        if (turnLight)
        {
            Light light;
            light = gameObject.GetComponent<Light>();
            light.enabled = !light.enabled;
        }
    }
}

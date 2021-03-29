using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlarmBehaviour : MonoBehaviour
{
    public bool changeColor = false;
    public bool changeMovement = false;
    public bool disappear = false;
    public bool turnLight = false;
    public bool fireBall = false;

    public Material blueMat;
    public Material redMat;
    public enum AlarmStateStart {Blue, Red};
    public AlarmStateStart alarmStateStart;
    public enum MovementType {Door, Platform};
    public MovementType movementType;


    private bool changeMaterial;
    private DoorBehaviour door;
    private PlatformBehaviour platform;
    public bool activatedFireBall;

    void Start()
    {
        if (changeColor)
        {
            if (alarmStateStart == AlarmStateStart.Blue)
                changeMaterial = true;
            if (alarmStateStart == AlarmStateStart.Red)
                changeMaterial = false;
        }

        if (turnLight)
            if (alarmStateStart == AlarmStateStart.Red)
                gameObject.GetComponent<Light>().enabled = false;

        if (fireBall)
        {
            if (alarmStateStart == AlarmStateStart.Blue)
                activatedFireBall = false;
            if (alarmStateStart == AlarmStateStart.Red)
                activatedFireBall = true;
        }        
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

        if (fireBall)
        { 
            if (activatedFireBall)
                gameObject.GetComponent<Light>().color = Color.red;
            if (!activatedFireBall)
                gameObject.GetComponent<Light>().color = Color.cyan;

            activatedFireBall = !activatedFireBall;
        }

        if (changeMovement)
        {
            if (movementType == MovementType.Door)
            {
                door = gameObject.GetComponent<DoorBehaviour>();
                if (door.activated)
                {
                    if (!door.opened)
                        door.OpenDoor();
                    else
                        door.CloseDoor();
                }
            }

            if (movementType == MovementType.Platform)
            {
                platform = gameObject.GetComponent<PlatformBehaviour>();
                if (!platform.activated)
                    platform.Activate();
                else
                    platform.Disactivate();
            }
        }
    }
}

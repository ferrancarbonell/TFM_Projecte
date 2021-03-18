using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlarmManager : MonoBehaviour
{
    public float stateTime = 2f;
    public enum AlarmState {Blue, Red};
    public AlarmState alarmState;
    public GameObject blueFlag;
    public GameObject redFlag;

    private float increase = 0;

    void Start()
    {
        alarmState = AlarmState.Blue;
    }

    void Update()
    {
        if (increase < stateTime)
        {
            increase += Time.deltaTime;
        }
        else
        {
            ChangeState();
        }
        
        
    }

    private void ChangeState()
    {
        var afectedObjects = GameObject.Find("AlarmAssets").GetComponentsInChildren<AlarmBehaviour>();

        if (alarmState == AlarmState.Blue)
        {
            alarmState = AlarmState.Red;
            redFlag.SetActive(true);
            blueFlag.SetActive(false);
            //Debug.Log("Red State");
        }
        else
        {
            if (alarmState == AlarmState.Red)
            {
            alarmState = AlarmState.Blue;
            redFlag.SetActive(false);
            blueFlag.SetActive(true);
            //Debug.Log("Blue State");
            }
        }

        foreach (var currentAfectedObject in afectedObjects)
        {
            currentAfectedObject.ChangeState();
            //currentAfectedObject.enabled = !currentAfectedObject.enabled;
            //Debug.Log("Objecte trobat");
        }
  
        increase = 0;
    }
}

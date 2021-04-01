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
    private AlarmBehaviour[] afectedObjects;

    void Start()
    {
        alarmState = AlarmState.Blue;
        afectedObjects = GameObject.Find("AlarmAssets").GetComponentsInChildren<AlarmBehaviour>();
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
        switch (alarmState)
        {
        case AlarmState.Blue: 
            alarmState = AlarmState.Red;
            redFlag.SetActive(true);
            blueFlag.SetActive(false);
            break;
            //Debug.Log("Red State");

        case AlarmState.Red:
            alarmState = AlarmState.Blue;
            redFlag.SetActive(false);
            blueFlag.SetActive(true);
            break;
            //Debug.Log("Blue State");
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

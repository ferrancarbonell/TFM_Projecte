using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject target;
    private AlarmManager alarmManager;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            target.SetActive (true);
            alarmManager = GameObject.Find("GameManager").GetComponent<AlarmManager>();
            alarmManager.SearchElements();
            this.gameObject.SetActive (false);
        }
    } 
}

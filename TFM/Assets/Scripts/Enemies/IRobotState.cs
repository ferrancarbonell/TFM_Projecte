using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IRobotState
{
    // Interfície para los funciones de los estados
    void UpdateState();
    void GoToAttackState();
    void GoToAlertState();
    void GoToPatrolState();
    void OnTriggerEnter(Collider other);
    void OnTriggerStay(Collider other);
    void OnTriggerExit(Collider other);
}

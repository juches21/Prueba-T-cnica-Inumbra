using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;

public class EnemyChaseState : MonoBehaviour
{

    EnemyStateMachine ESM;

    bool isActive = true;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

        ESM = GetComponent<EnemyStateMachine>();
    }
    // Update is called once per frame
    void Update()
    {
        if (isActive) return;

        if (Vector3.Distance(transform.position, ESM.Player.transform.position) >= 2f)
        {
            ESM.m_Agent.isStopped = false;
            ESM.m_Agent.SetDestination(ESM.Player.transform.position);



        }
        else
        {
            ESM.m_Agent.isStopped = true;
            ESM.Cambio(EnemyStateMachine.States.Attacking);

        }

    }
    public void StartChase()
    {
        ESM._animatorController.AnimationTrigger("WalkAttack");
        isActive = false;

    }
    public void Stop()
    {
        isActive = true;

    }









    //-----------------------------

}

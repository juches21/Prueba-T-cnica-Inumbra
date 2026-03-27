using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyWalkState : MonoBehaviour
{
    [SerializeField] private List<Waypoints> WaypointsList = new List<Waypoints>();
    public EnemyStateMachine ESM;
    DetectionSistem DetectionSistem;

    bool Chequer;

    int currentWaypoint;


    public bool isActive = false;
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    private void Awake()
    {

    }
    void Start()
    {

       // ESM = GetComponent<EnemyStateMachine>();


    }

    // Update is called once per frame
    void Update()
    {
        if (isActive == true) return;


        if (!ESM.m_Agent.pathPending && ESM.m_Agent.remainingDistance <= ESM.m_Agent.stoppingDistance)
        {



            ESM.miCorrutina = StartCoroutine(PatrolStop());

        }

    }


    public void Stop()
    {
        isActive = true;
    }
    public void StartWalk()
    {
        isActive = false;

        print("comienza patrulla");





        //ESM.Animator.SetBool("Attack", false);
        //ESM.Animator.SetBool("WalkAttack", false);


        //ESM.Animator.SetTrigger("Walk");
        NextWaypoint();
    }


    void NextWaypoint()
    {

        ESM.m_Agent.isStopped = false;
        ESM._DetectionSistem.Reset();

        ESM._animatorController.AnimationTrigger("Walk");
        print("camina el siguiente punto");
        currentWaypoint++;

        // Si llega al final vuelve al primero
        if (currentWaypoint >= WaypointsList.Count)
        {
            currentWaypoint = 0;
        }

        ESM.m_Agent.SetDestination(WaypointsList[currentWaypoint].Spot.position);
        //ESM.Animator.SetTrigger("Walk");
        Chequer = true;

    }



    IEnumerator PatrolStop()
    {
        print("llega al punto");
        if (WaypointsList[currentWaypoint].Wait)
        {
            isActive = true;

            print("Espera " + WaypointsList[currentWaypoint].tiempo + " segundos en el punto");

            ESM._animatorController.StopAnimation();

            float Time = WaypointsList[currentWaypoint].tiempo;
            yield return new WaitForSeconds(Time);

            isActive = false;

        }

        NextWaypoint();
    }












    [System.Serializable]
    public class Waypoints
    {
        public Transform Spot;
        public bool Wait;
        public float tiempo;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using static EnemyMotion;

public class EnemyMotion : MonoBehaviour
{
    public List<Waypoints> WaypointsList = new List<Waypoints>();


    private NavMeshAgent m_Agent;

    public bool IsPatrol;

    public int currentWaypoint;

    private Animator Animator;

    bool Chequer;
    bool ChequerWalck;
    bool ChequerStop;


    GameObject Player;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
        Animator = GetComponent<Animator>();
        m_Agent = GetComponent<NavMeshAgent>();
        //NextWaypoint();
        AtackMode();
    }

    // Update is called once per frame
    void Update()
    {
        if (WaypointsList.Count == 0) return;
        if (IsPatrol)
        {

            // Cuando llega al destino
            if (!m_Agent.pathPending && m_Agent.remainingDistance <= m_Agent.stoppingDistance && Chequer)
            {
                Chequer = false;

                //Animator.SetTrigger("Stop");
                StartCoroutine(PatrolStop());

            }
        }
        else
        {

            if (Vector3.Distance(transform.position, Player.transform.position) >= 2)
            {
                // Mover hacia el jugador
                ChequerStop=true;
                m_Agent.isStopped = false;
                m_Agent.SetDestination(Player.transform.position);
                if (ChequerWalck)
                {
                    ChequerWalck=false;
                Animator.SetTrigger("Walk");
                }
            }
            else
            {
                ChequerWalck = true;

                // Detenerse antes de llegar
                m_Agent.isStopped = true;
                if (ChequerStop)
                {
                    ChequerStop=false;
                Animator.SetTrigger("Stop");

                }
            }

        }
    }

    void NextWaypoint()
    {
        
        currentWaypoint++;

        // Si llega al final vuelve al primero
        if (currentWaypoint >= WaypointsList.Count)
        {
            currentWaypoint = 0;
        }

        m_Agent.SetDestination(WaypointsList[currentWaypoint].Spot.position);
        Animator.SetTrigger("Walk");
        Chequer = true;

    }


    IEnumerator PatrolStop()
    {
        if (WaypointsList[currentWaypoint].Wait)
        {
            Animator.SetTrigger("Stop");

            float Time = WaypointsList[currentWaypoint].tiempo;
            yield return new WaitForSeconds(Time);


        }

        NextWaypoint();
    }


    void AtackMode()
    {
   
        Animator.SetBool("Attack", true);
        StopAllCoroutines();
        IsPatrol = false;

    }


    [System.Serializable]
    public class Waypoints
    {
        public Transform Spot;
        public bool Wait;
        public float tiempo;
    }

}

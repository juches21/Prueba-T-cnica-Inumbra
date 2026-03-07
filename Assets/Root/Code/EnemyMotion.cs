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


    Rigidbody rb;


    bool Chequer;
    bool Spinning;
    bool Stunned;


    GameObject Player;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        Player = GameObject.FindGameObjectWithTag("Player");
        Animator = GetComponent<Animator>();
        m_Agent = GetComponent<NavMeshAgent>();
        //NextWaypoint();
        //AtackMode();
        //GetStunned();
        StartWalck();
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
           
        }
    }


    public void StartWalck()
    {
        print("restart");
        m_Agent.isStopped = false;

        IsPatrol = true;
        Chequer = true;
        Animator.SetBool("Attack", false);

        NextWaypoint();
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













    public void AtackMode()
    {
   
        Animator.SetBool("Attack", true);
        StopAllCoroutines();
        IsPatrol = false;
        StartCoroutine(Chase());
    }





    IEnumerator Chase()
    {
        while (true)
        {
            if (Vector3.Distance(transform.position, Player.transform.position) >= 2f)
            {
                // Mover hacia el jugador
                m_Agent.isStopped = false;
                m_Agent.SetDestination(Player.transform.position);

         

            }
            else
            {

                // Detenerse antes de llegar
                m_Agent.isStopped = true;

                StartAttack();
            }


            if (m_Agent.velocity.magnitude > 0.1f)
            {
                Animator.SetBool("WalkAttack", true);

                Debug.Log("El agente se está moviendo");
            }
            else
            {
                Animator.SetBool("WalkAttack", false);

                
            }
            yield return null; // esperar al siguiente frame
        }

    }



    void StartAttack()
    {

        StopAllCoroutines();
        Animator.SetBool("WalkAttack", false);
        StartCoroutine(LoadAttack());
    }


    IEnumerator LoadAttack()
    {
        Animator.SetBool("WalkAttack", false);

        yield return new WaitForSeconds(0.5f);

        Animator.SetTrigger("Load");

        yield return new WaitForSeconds(3f);
        Animator.SetTrigger("Assault");
        m_Agent.isStopped = true;
        Spinning = true;
        float t = 0;

        while (t < 1)
        {
            m_Agent.Move(transform.forward * 2 * Time.deltaTime);
            t += Time.deltaTime;
            yield return null;
        }


        Animator.SetTrigger("Stop");
        yield return new WaitForSeconds(0.5f);
        StartWalck();
    }






    public void GetStunned()
    {
        Stunned=true;
        StopAllCoroutines();
        Animator.SetTrigger("Stunned");
        StartCoroutine(StunnedTime());
    }

    IEnumerator StunnedTime()
    {
        yield return new WaitForSeconds(3f);
        Animator.SetTrigger("Stop");
        IsPatrol=true;
        StartWalck();
    }











    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Wall") && Spinning)
        {
            GetStunned();
        }
    }




    [System.Serializable]
    public class Waypoints
    {
        public Transform Spot;
        public bool Wait;
        public float tiempo;
    }

}

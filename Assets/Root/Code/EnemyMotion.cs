using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using static EnemyMotion;

public class EnemyMotion : MonoBehaviour
{
    [SerializeField] private List<Waypoints> WaypointsList = new List<Waypoints>();

    public float AttackDistance;

    private NavMeshAgent m_Agent;

    bool IsPatrol;

    int currentWaypoint;

    private Animator Animator;


    public Renderer Material1;

    bool Chequer;
    bool Spinning;
    bool Stunned;


    GameObject Player;

    [SerializeField] private ParticleSystem ParticlePreload;
    [SerializeField] private ParticleSystem ParticleStunned;




    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
       
        Player = GameObject.FindGameObjectWithTag("Player");
        Animator = GetComponent<Animator>();
        m_Agent = GetComponent<NavMeshAgent>();
        StartWalk();
    }

    // Update is called once per frame
    void Update()
    {
        if (WaypointsList.Count == 0) return;
        if (IsPatrol)
        {

         
            if (!m_Agent.pathPending && m_Agent.remainingDistance <= m_Agent.stoppingDistance && Chequer)
            {
                Chequer = false;

               
                StartCoroutine(PatrolStop());

            }
        }
      
    }


    #region Patrol


    public void StartWalk()
    {
        print("comienza patrulla");
        ParticlePreload.Stop();

        Spinning = false;
        m_Agent.isStopped = false;
        gameObject.GetComponent<DetectionSistem>().Reset(); 
        IsPatrol = true;
        Chequer = true;
        Animator.SetBool("Attack", false);
        Animator.SetBool("WalkAttack", false);

        NextWaypoint();
        Animator.SetTrigger("Walk");
    }


    void NextWaypoint()
    {
        print("camina el siguiente punto");
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
        print("llega al punto");
        if (WaypointsList[currentWaypoint].Wait)
        {
            print("Espera " + WaypointsList[currentWaypoint].tiempo + " segundos en el punto");

            Animator.SetTrigger("Stop");

            float Time = WaypointsList[currentWaypoint].tiempo;
            yield return new WaitForSeconds(Time);


        }

        NextWaypoint();
    }


    #endregion



    #region Persecution




    public void AttackMode()
    {
        print("Jugador localizado");
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
                m_Agent.isStopped = false;
                m_Agent.SetDestination(Player.transform.position);

         

            }
            else
            {

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
            yield return null; 
        }

    }

    #endregion

    #region Attack

    void StartAttack()
    {
        print("iniciando ataque");
        StopAllCoroutines();
        Animator.SetBool("WalkAttack", false);
        StartCoroutine(LoadAttack());
    }


    IEnumerator LoadAttack()
    {
        ParticlePreload.Play();
        transform.LookAt(Player.transform);
        Animator.SetBool("WalkAttack", false);

        yield return new WaitForSeconds(0.5f);

        Animator.SetTrigger("Load");

        yield return new WaitForSeconds(3f);
        Animator.SetTrigger("Assault");
        m_Agent.isStopped = true;
        Spinning = true;
        float t = 0;

        while (t < 0.5f)
        {
            m_Agent.Move(transform.forward * AttackDistance * Time.deltaTime);
            t += Time.deltaTime;
            yield return null;
        }
        print("ataque lanzado");

        yield return new WaitForSeconds(0.5f);
        StartWalk();
    }



    #endregion

    #region Stunned


    public void GetStunned()
    {
        print("Aturdido");
        ParticleStunned.Play();
        ParticlePreload.Stop();

        Stunned = true;
        StopAllCoroutines();
        Animator.SetTrigger("Stunned");
        StartCoroutine(StunnedTime());
    }

    IEnumerator StunnedTime()
    {
        yield return new WaitForSeconds(2f);
    
        ParticleStunned.Stop();

        IsPatrol = true;
        StartWalk();
    }


    #endregion

    #region Dead


    void Dead()
    {
        print("derrotado");
        StopAllCoroutines();
        ParticleStunned.Stop();
        StartCoroutine(Disappear());

    }

 
    IEnumerator Disappear()
    {
        float x = 1f;

        Color c = Material1.material.color;
        while (x > 0)
        {
            x -= Time.deltaTime;

            c.a = x;
        

            Material1.material.color = c;

            yield return null;
        }

        // asegurarse de que quede totalmente invisible
        c.a = 0;
       

        Material1.material.color = c;
        gameObject.SetActive(false);
    }

    #endregion


    #region Trigger/Colliders


    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Wall") && Spinning)
        {
            GetStunned();
        }
        if(other.CompareTag("AttackArea") && Stunned)
        {
            Dead();
            print("dead");
        }
    
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.CompareTag("Player") && Spinning)
        {
            print("hit");
            collision.gameObject.GetComponent<CharacterControl>().Damage();
        }
    }

    #endregion


    #region WaypointClass

    [System.Serializable]
    public class Waypoints
    {
        public Transform Spot;
        public bool Wait;
        public float tiempo;
    }
    #endregion

}

using UnityEngine;
using UnityEngine.AI;

    [RequireComponent(typeof(EnemyWalkState))]
    [RequireComponent(typeof(EnemyChaseState))]
    [RequireComponent(typeof(EnemyAttackState))]
    [RequireComponent(typeof(EnemyStunnedState))]
    [RequireComponent(typeof(EnemyDeadState))]
    [RequireComponent(typeof(DetectionSistem))]
    [RequireComponent(typeof(EnemyAnimatorController))]


    [RequireComponent(typeof(Animator))]
    [RequireComponent(typeof(Animator))]
public class EnemyStateMachine : MonoBehaviour
{

    public float StunnedTime_n;
    public float AttackDistance;



    public enum States
    {
        Idle, Moving, Chasing, Attacking, Stunned, Dead
    }


    [HideInInspector]
    public NavMeshAgent m_Agent;
    [HideInInspector] public Animator Animator;

    [HideInInspector] public GameObject Player;

    [HideInInspector] public bool Spinning;

    [HideInInspector] public bool Stunned;


    [HideInInspector] public Coroutine miCorrutina;


    private EnemyWalkState _walkState;
    private EnemyChaseState _chaseState;
    private EnemyAttackState _attackState;
    private EnemyStunnedState _stunnedState;
    private EnemyDeadState _deadState;
    [HideInInspector] public DetectionSistem _DetectionSistem;
    [HideInInspector] public EnemyAnimatorController _animatorController;


    void Awake()
    {
        Player = GameObject.FindGameObjectWithTag("Player");

        m_Agent = GetComponent<NavMeshAgent>();
        Animator = GetComponent<Animator>();

        _walkState = GetComponent<EnemyWalkState>();
        _chaseState = GetComponent<EnemyChaseState>();
        _attackState = GetComponent<EnemyAttackState>();
        _stunnedState = GetComponent<EnemyStunnedState>();
        _deadState = GetComponent<EnemyDeadState>();
        _animatorController = GetComponent<EnemyAnimatorController>();
        _DetectionSistem = GetComponent<DetectionSistem>();
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {


        Cambio(States.Moving);
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void Cambio(States estado)
    {

        KillStates();

        switch (estado)
        {
            case States.Idle:

                break;

            case States.Moving:
                _walkState.StartWalk();

                break;

            case States.Chasing:
                _chaseState.StartChase();

                break;


            case States.Attacking:
                _attackState.StartAttack();

                break;

            case States.Stunned:
                _stunnedState.StartStunned();

                break;

            case States.Dead:
                _deadState.StartDead();

                break;
        }
    }

    private void KillStates()
    {
        if (miCorrutina != null)
        {

            StopCoroutine(miCorrutina);
        }
       
        _walkState.Stop();
        _chaseState.Stop();
    }
}

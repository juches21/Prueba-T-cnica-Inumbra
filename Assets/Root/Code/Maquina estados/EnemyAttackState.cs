using System.Collections;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAttackState : MonoBehaviour
{




    EnemyStateMachine ESM;




















    [SerializeField] private ParticleSystem ParticlePreload;



    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        ESM = GetComponent<EnemyStateMachine>();

    }

    // Update is called once per frame
    void Update()
    {

    }


    public void StartAttack()
    {
        print("iniciando ataque");

        ESM.miCorrutina = StartCoroutine(LoadAttack());
    }


    IEnumerator LoadAttack()
    {
        ParticlePreload.Play();
        transform.LookAt(ESM.Player.transform);


        yield return new WaitForSeconds(0.5f);



        ESM._animatorController.AnimationTrigger("Load");


        yield return new WaitForSeconds(3f);

        ParticlePreload.Stop();

        ESM._animatorController.AnimationTrigger("Assault");




        ESM.m_Agent.isStopped = true;
        ESM.Spinning = true;
        float t = 0;

        while (t < 0.5f)
        {
            ESM.m_Agent.Move(transform.forward * ESM.AttackDistance * Time.deltaTime);
            t += Time.deltaTime;
            yield return null;
        }


        yield return new WaitForSeconds(0.5f);
        Stop();

    }

    private void Stop()
    {
        print("ataque lanzado");

        ESM.Spinning = false;

        ESM.Cambio(EnemyStateMachine.States.Moving);

    }

}

using System.Collections;
using UnityEngine;

public class EnemyStunnedState : MonoBehaviour
{


    [SerializeField] private ParticleSystem ParticleStunned;
    EnemyStateMachine ESM;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        ESM = GetComponent<EnemyStateMachine>();

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartStunned()
    {

        print("Aturdido");
        ParticleStunned.Play();


        ESM.Spinning = false;
        ESM.Stunned = true;
     
        ESM.miCorrutina = StartCoroutine(StunnedTime());
    }

    IEnumerator StunnedTime()
    {
        yield return new WaitForSeconds(0.5f);

        ESM._animatorController.AnimationTrigger("Stunned");
        yield return new WaitForSeconds(ESM.StunnedTime_n);

        ParticleStunned.Stop();

        ESM.Stunned = false;

        ESM.Cambio(EnemyStateMachine.States.Moving);

    }
}

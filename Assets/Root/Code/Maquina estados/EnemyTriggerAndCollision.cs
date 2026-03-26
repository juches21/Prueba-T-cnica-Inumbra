using UnityEngine;

public class EnemyTriggerAndCollision : MonoBehaviour
{

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


    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Wall") && ESM.Spinning)
        {
            ESM.Cambio(EnemyStateMachine.States.Stunned);
            ESM.Spinning = false;

        }
        if (other.CompareTag("AttackArea") && ESM.Stunned)
        {
          
            print("dead");
            ESM.Cambio(EnemyStateMachine.States.Dead);

        }

    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.CompareTag("Player") && ESM.Spinning)
        {
            print("hit");
            collision.gameObject.GetComponent<CharacterControl>().Damage();
        }
    }
}

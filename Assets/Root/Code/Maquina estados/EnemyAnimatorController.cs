using UnityEngine;

public class EnemyAnimatorController : MonoBehaviour
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

    public void StopAnimation()
    {
        ESM.Animator.SetTrigger("Stop");

    }
    public void AnimationTrigger(string Trigger)
    {
        ESM.Animator.SetTrigger(Trigger);

    }


}

using System.Collections;
using UnityEngine;

public class EnemyDeadState : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    public void StartDead()
    {

        print("derrotado");


        StartCoroutine(Disappear());

    }


    IEnumerator Disappear()
    {
        yield return new WaitForSeconds(2f);

        gameObject.SetActive(false);
    }
}

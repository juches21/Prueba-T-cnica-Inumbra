using UnityEngine;

public class DetectionSistem : MonoBehaviour
{

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            print("entra");
            gameObject.GetComponent<EnemyMotion>().AtackMode();
        }
    }
}

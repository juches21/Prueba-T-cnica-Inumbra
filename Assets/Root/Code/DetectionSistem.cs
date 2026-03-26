//-------------------------------------------------Chovi-------------------------------------------------//

using Unity.VisualScripting;
using UnityEngine;

public class DetectionSistem : MonoBehaviour
{
    [SerializeField] private GameObject Vision1;
    [SerializeField] private GameObject Vision2;
    private EnemyStateMachine Machine;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Machine= gameObject.GetComponent<EnemyStateMachine>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Reset()
    {
        Vision1.SetActive(true);

        Vision2.SetActive(true);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Vision1.SetActive(false);
            Vision2.SetActive(false);

            Machine.Cambio(EnemyStateMachine.States.Chasing);
        }
    }
}
//-------------------------------------------------Chovi-------------------------------------------------//


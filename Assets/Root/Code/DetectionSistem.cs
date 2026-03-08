//-------------------------------------------------Chovi-------------------------------------------------//

using Unity.VisualScripting;
using UnityEngine;
using static EnemyMotion;

public class DetectionSistem : MonoBehaviour
{
    [SerializeField] private GameObject Vision1;
    [SerializeField] private GameObject Vision2;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
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
            gameObject.GetComponent<EnemyMotion>().AttackMode();
        }
    }
}
//-------------------------------------------------Chovi-------------------------------------------------//


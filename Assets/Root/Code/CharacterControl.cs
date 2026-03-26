//-------------------------------------------------Chovi-------------------------------------------------//

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class CharacterControl : MonoBehaviour
{
    [SerializeField] private GameObject AttackArea;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }


    // Start is called before the first frame update
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            AttackArea.SetActive(true);
        }
        if (Input.GetMouseButtonUp(0))
        {
            AttackArea.SetActive(false);

        }

    }

    // Update is called once per frame


  
    public void Damage()
    {

        StartCoroutine(VisualFailure());

    }


    [SerializeField] GameObject panel;
    IEnumerator VisualFailure()
    {
        panel.gameObject.GetComponent<Image>().color = new Color32(250, 0, 0, 50);
        yield return new WaitForSeconds(0.5f);
        panel.gameObject.GetComponent<Image>().color = new Color32(0, 100, 100, 0);

    }
    //-------------------------------------------















}
//-------------------------------------------------Chovi-------------------------------------------------//

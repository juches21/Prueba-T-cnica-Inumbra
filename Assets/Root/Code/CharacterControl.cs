using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class CharacterControl : MonoBehaviour
{
    [SerializeField] private GameObject AttackArea;

    private Rigidbody player_rb;
    //public PlayerInput playerInput;
    private Vector2 meveinput;
    private Vector2 rotacion;
    //public GameObject jugador;
    Vector3 direccion;
    public Animator Animator;
    public bool movible = true;
    public float speed;


    // Start is called before the first frame update
    void Start()
    {
        player_rb = GetComponent <Rigidbody>();
        //playerInput = GetComponent<PlayerInput>();

        Animator = gameObject.GetComponent<Animator>();
        //AudioManager.INSTANCE.PlaySFX(0);

    }

    // Update is called once per frame
    void Update()
    {
   //rotacion camara
        if (rotacion.x != 0)
        {

       
            transform.rotation = transform.rotation * Quaternion.Euler(0, rotacion.x, 0);


        }
        //-------------------------------------------
    }
    private void FixedUpdate()
    {
        // movimiento

        direccion = meveinput.y * transform.forward ;

        //jugador.transform.rotation = jugador.transform.rotation * Quaternion.Euler(0, meveinput.x, 0);

        player_rb.linearVelocity = direccion * speed + new Vector3(0, player_rb.linearVelocity.y, 0);
        if(direccion!= Vector3.zero)
        {
        Animator.SetTrigger("Walk");

            //animaciones.SetBool("movimiento",true);
        }
        else
        {
            //animaciones.SetBool("movimiento", false);
            Animator.SetTrigger("Stop");


        }
        //-------------------------------------------

    }

    //leer controles
    public void mov(InputAction.CallbackContext context)
    {
        if (movible)
        {
            meveinput = context.ReadValue<Vector2>();

        }
        else
        {

            meveinput = Vector2.zero;
        }
        
    }
    public void rotar(InputAction.CallbackContext context)
    {
        
        if(movible )
        {

        rotacion = context.ReadValue<Vector2>();
        }
        else
        {

            rotacion = Vector2.zero;
        }

    }



    public void Attack(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            AttackArea.SetActive(true);
            Animator.SetTrigger("Attack");
        }
        if (context.canceled)
        {
            AttackArea.SetActive(false);
        }
    }

    public void Damage()
    {
        Animator.SetTrigger("Hit");
        StartCoroutine(VisualFailure());

    }


    [SerializeField] GameObject panel;
    IEnumerator VisualFailure()
    {
        panel.gameObject.GetComponent<Image>().color = new Color32(250, 0, 0,10);
        yield return new WaitForSeconds(0.5f);
        panel.gameObject.GetComponent<Image>().color = new Color32(0, 100, 100, 0);
    
    }
    //-------------------------------------------















}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerController : MonoBehaviour
{
    private Rigidbody playerRigidbody;

    private float jumpForce = 700f;
    private float gravityModifier = 3f;

    private bool isOnFloor = true;
    public bool isGameOver = false;

    private Animator playerAnimator;

    public ParticleSystem explosionPS;
    public ParticleSystem playerRunningPS;

    private AudioSource playerAS;
    public AudioSource cameraAS;

    public AudioClip jumpClip;
    public AudioClip explosionClip;

    void Start()
    {
        //Accedemos a los componentes de player.
        playerRigidbody = GetComponent<Rigidbody>();
        playerAnimator = GetComponent<Animator>();
        playerAS = GetComponent<AudioSource>();

        //Acedemos a la audiosource de la c�mara.
        cameraAS = GameObject.Find("Main Camera").GetComponent<AudioSource>();

        //Iniciamos las part�culas de correr.
        playerRunningPS.Play();

        Physics.gravity *= gravityModifier;
    }

    void Update()
    {
        //Salto.
        if (Input.GetKeyDown(KeyCode.Space) && isOnFloor && !isGameOver)
        {
            playerRigidbody.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);

            //Ejecutamos la animaci�n de salto.
            playerAnimator.SetTrigger("Jump_trig");
            
            //Paramos part�culas al saltar.
            playerRunningPS.Stop();

            //Llamamos el sonido del salto.
            playerAS.PlayOneShot(jumpClip, 1f);

            isOnFloor = false;
           
        }

    }

    private void OnCollisionEnter(Collision otherCollision)
    {
        if (!isGameOver)
        {
            if (otherCollision.gameObject.CompareTag("Ground"))
            {
                //Volvemos a activar las part�culas al caer del salto (tocar el suelo).
                playerRunningPS.Play();
                isOnFloor = true;
            }

            else if (otherCollision.gameObject.CompareTag("Obstacle"))
            {
                //Si colisiona con un objeto, seleciona randomly una animaci�n de muerte.
                int deathType = Random.Range(1, 3);
                Debug.Log("GAME OVER");
                playerAnimator.SetBool("Death_b", true);
                playerAnimator.SetInteger("DeathType_int", deathType);


                //Activa la explosi�n en la muerte.
                explosionPS.Play();

                //Activa sonido de la explosi�n, y al morir baja el volumen general de la m�sica.
                playerAS.PlayOneShot(explosionClip, 1f);
                cameraAS.volume = 0.01f;
                
                //Desactivamos las part�culas de tierra.
                playerRunningPS.Stop();

                //Morimos.
                isGameOver = true;
            } 
        }
        
        
    }
}

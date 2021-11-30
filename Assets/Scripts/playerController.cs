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

        //Acedemos a la audiosource de la cámara.
        cameraAS = GameObject.Find("Main Camera").GetComponent<AudioSource>();

        //Iniciamos las partículas de correr.
        playerRunningPS.Play();

        Physics.gravity *= gravityModifier;
    }

    void Update()
    {
        //Salto.
        if (Input.GetKeyDown(KeyCode.Space) && isOnFloor && !isGameOver)
        {
            playerRigidbody.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);

            //Ejecutamos la animación de salto.
            playerAnimator.SetTrigger("Jump_trig");
            
            //Paramos partículas al saltar.
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
                //Volvemos a activar las partículas al caer del salto (tocar el suelo).
                playerRunningPS.Play();
                isOnFloor = true;
            }

            else if (otherCollision.gameObject.CompareTag("Obstacle"))
            {
                //Si colisiona con un objeto, seleciona randomly una animación de muerte.
                int deathType = Random.Range(1, 3);
                Debug.Log("GAME OVER");
                playerAnimator.SetBool("Death_b", true);
                playerAnimator.SetInteger("DeathType_int", deathType);


                //Activa la explosión en la muerte.
                explosionPS.Play();

                //Activa sonido de la explosión, y al morir baja el volumen general de la música.
                playerAS.PlayOneShot(explosionClip, 1f);
                cameraAS.volume = 0.01f;
                
                //Desactivamos las partículas de tierra.
                playerRunningPS.Stop();

                //Morimos.
                isGameOver = true;
            } 
        }
        
        
    }
}

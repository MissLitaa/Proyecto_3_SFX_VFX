using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerController : MonoBehaviour
{
    private Rigidbody playerRigidbody;
    public float jumpForce = 550;
    public float gravityModifier = 1;
    public bool isOnFloor = true;
    public bool isGameOver = false;
    private Animator playerAnimator;

    // Start is called before the first frame update
    void Start()
    {
        playerRigidbody = GetComponent<Rigidbody>();
        playerAnimator = GetComponent<Animator>();
        Physics.gravity *= gravityModifier;
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isOnFloor)
        {
            playerRigidbody.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            playerAnimator.SetTrigger("Jump_trig");
            isOnFloor = false;
        }

    }

    private void OnCollisionEnter(Collision otherCollision)
    {
        if (otherCollision.gameObject.CompareTag("Ground"))
        {
            isOnFloor = true; 
        }
        
        else if (otherCollision.gameObject.CompareTag("Obstacle"))
        {
            Debug.Log("GAME OVER");
            playerAnimator.SetBool("Death_b", true);
            isGameOver = true;
        }
    }
}

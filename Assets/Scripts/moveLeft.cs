using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moveLeft : MonoBehaviour
{
    private float objectSpeed = 10;
    private playerController playerControllerScript;
    private float lowerLimit = -1;
   
    void Start()
    {
        //Nos comunicamos con el script PlayerController
        playerControllerScript = GameObject.Find("Player").GetComponent<playerController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!playerControllerScript.isGameOver)
        { 
            transform.Translate(Vector3.left * objectSpeed * Time.deltaTime);
        }

        if (transform.position.y < lowerLimit)
        {
            Destroy(gameObject);
        }
    }
}

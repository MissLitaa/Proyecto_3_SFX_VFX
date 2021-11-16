using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moveLeft : MonoBehaviour
{
    public float objectSpeed = 10;
    private playerController playerControllerScript;
    // Start is called before the first frame update
    void Start()
    {
        playerControllerScript = GameObject.Find("Player").GetComponent<playerController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!playerControllerScript.isGameOver)
        { 
            transform.Translate(Vector3.left * objectSpeed * Time.deltaTime);
        }

        if (transform.position.y < -1)
        {
            Destroy(gameObject);
        }
    }
}

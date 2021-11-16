using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnManager : MonoBehaviour
{
   
    public float spawnPoint = 35;

    public float startDelay = 2f;
    public float repeatRate = 2f;

    public playerController playerControllerScript;

    public GameObject[] obstacleIndex;
    public int obstacleCount;
   


    // Start is called before the first frame update
    void Start()
    {
        playerControllerScript = GameObject.Find("Player").GetComponent<playerController>();
        InvokeRepeating("spawnObstacle", startDelay, repeatRate);
    }

    // Update is called once per frame
    void Update()
    {
        
        
    }

    public void spawnObstacle()
    {
        if (!playerControllerScript.isGameOver)
        {
            obstacleCount = Random.Range(0, obstacleIndex.Length);
           Instantiate(obstacleIndex[obstacleCount], new Vector3(spawnPoint, 0, 0), obstacleIndex[obstacleCount].transform.rotation); 
        }

        
    }
}

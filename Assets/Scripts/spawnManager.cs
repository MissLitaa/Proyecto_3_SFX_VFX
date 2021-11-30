using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnManager : MonoBehaviour
{
   
    public float spawnPoint = 35;

    private float startDelay = 3f;
    private float repeatRate = 2f;

    public playerController playerControllerScript;

    public GameObject[] obstacleIndex;
    public int obstacleCount;
   


    // Start is called before the first frame update
    void Start()
    {
        playerControllerScript = GameObject.Find("Player").GetComponent<playerController>();
        InvokeRepeating("spawnObstacle", startDelay, repeatRate);
    }


    private void spawnObstacle()
    {
        if (!playerControllerScript.isGameOver)
        {
            obstacleCount = Random.Range(0, obstacleIndex.Length);
           Instantiate(obstacleIndex[obstacleCount], new Vector3(spawnPoint, 0, 0), obstacleIndex[obstacleCount].transform.rotation); 
        }

        
    }
}

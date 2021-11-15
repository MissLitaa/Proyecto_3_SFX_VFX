using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnManager : MonoBehaviour
{
    public GameObject obstaclePrefab;
    public float spawnPoint = 35;

    public float startDelay = 2f;
    public float repeatRate = 2f;
    
    
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("spawnObstacle", startDelay, repeatRate);
    }

    // Update is called once per frame
    void Update()
    {

        
    }

    public void spawnObstacle()
    {
        Instantiate(obstaclePrefab, new Vector3(spawnPoint, 0, 0), obstaclePrefab.transform.rotation);
    }
}

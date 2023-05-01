using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] Obstacles;
    private Vector3 spawnPos = new Vector3(20,0,0);
    private float startDelay = 4;
    private float repeadRate = 3;
    private PlayerController playerControllerScript;


    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnObstacle",startDelay,repeadRate);
        playerControllerScript = GameObject.Find("Player").GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }



    void SpawnObstacle()
    {
        if (playerControllerScript.gameOver == false)
        {
            int index = Random.Range(0, 4);
            Instantiate(Obstacles[index], spawnPos, Obstacles[index].transform.rotation);
        }
    }
}

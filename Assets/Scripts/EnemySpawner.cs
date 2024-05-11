using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] //To access prefab
    private GameObject enemy;

    [SerializeField] //Number of seconds till next enemy is spawned
    private float interval;

    [SerializeField]
    private float minSpawn = 1;
    private float maxSpawn = 2;


    public Transform player; //Current position of the player
    public float speed = 5.0f; //Speed of the player


    void Awake()
    {
        SetTimeUntilSpawn();    
    }

    private void Update()
    {

        interval -= Time.deltaTime;
        if(interval <= 0)
        {

            Enemy e = enemy.GetComponent<Enemy>();
            if(e != null)
            {
                e.player = player;
            }
            //Instantiate the enemy prefab
            Instantiate(enemy, transform.position, Quaternion.identity);
            SetTimeUntilSpawn();
        }
    }

    private void SetTimeUntilSpawn()
    {
        interval = Random.Range(minSpawn, maxSpawn);
    }

}

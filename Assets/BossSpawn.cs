using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BossSpawn : MonoBehaviour
{
    [SerializeField] //To access prefab
    private GameObject enemy;

    //public Animator animator;


    [SerializeField] public float bossSpawnInterval = 20;


    public Transform player; //Current position of the player


    void Awake()
    {
        SetTimeUntilSpawn();
    }

    private void Update()
    {
        
        if (Timer.Instance.remainingTime <= 0)
        {

            Enemy e = enemy.GetComponent<Enemy>();

            if (e != null)
            {
                e.player = player;
                //e.animator = animator;
            }
            //Instantiate the enemy prefab
            Instantiate(enemy, transform.position, Quaternion.identity);
            SetTimeUntilSpawn();
        }
    }

    private void SetTimeUntilSpawn()
    {
        Timer.Instance.remainingTime = bossSpawnInterval;
    }

}

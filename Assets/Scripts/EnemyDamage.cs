using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    public int health = 100;
    public Transform player;
    public float speed = 5.0f;
    private bool isCollidingWithPlayer = false;
    public int damagePerSecond = 5;
    //public GameObject deathEffect;

    public void TakeDamage(int damage)
    {
        health -= damage;

        if(health <= 0)
        {
            Die();
        }
    }

    public void getTransform(Transform t)
    {
        //if (t == null) Debug.Log("NULL T!");
        player = t;
        if (player != null) { Debug.Log("NOT NULL!"); }
    }

    void Die()
    {
        //Instantiate(deathEffect, transform.position, Quaternion.identity); 
        Destroy(gameObject);
    }

    public void Update()
    {
        if (player != null)
        {
            Vector3 direction = (player.position - transform.position).normalized; // Get the normalized direction to the player
            transform.position += direction * speed * Time.deltaTime; // Move towards the player
        }
    }

    void OnTriggerStay(Collider other)
    {
        Debug.Log("FUNCTION CALLED!");
        if (other.CompareTag("Player"))
        {
            isCollidingWithPlayer = true;
            // Deduct health continuously
            other.GetComponent<PlayerHealth>().TakeDamage((int)(damagePerSecond * Time.deltaTime));
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isCollidingWithPlayer = false;
        }
    }

    void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            PlayerHealth playerHealth = collision.gameObject.GetComponent<PlayerHealth>();
            if (playerHealth != null)
            {
                playerHealth.TakeDamage(1);
            }
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BottomlessPitDeath : MonoBehaviour {
    public float timeBetweenAttacks = 0.5f;
    public int damage = 100;

    Animator anim;
    GameObject player;
    PlayerHealth playerHealth;
    bool playerInRange;
    float timer;
    // Use this for initialization
    void Awake () {
        player = GameObject.FindGameObjectWithTag("Player");
        playerHealth = player.GetComponent<PlayerHealth>();
    }

    void OnTriggerEnter(Collider other)
    {
        // If the entering collider is the player the player is in range.
        if (other.gameObject == player)
        {
            Debug.Log("yo");
            playerInRange = true;
        }
    }

    void OnTriggerExit(Collider other)
    {
        // If the exiting collider is the player the player is no longer in range.
        if (other.gameObject == player)
        {
            playerInRange = false;
        }
    }

    // Update is called once per frame
    void Update () {
        timer += Time.deltaTime;

        // If timer exceeds the time between attacks, the player is in range and this enemy is alive...
        if (timer >= timeBetweenAttacks && playerInRange)
        {
            // ... attack.
            Fall();
        }

        // If the player has zero or less health...
        if (playerHealth.currHealth <= 0)
        {
            Debug.Log("dead");
            //FIX
            //Animate death
            //anim.SetTrigger("PlayerDead");
        }
    }

    void Fall()
    {
        // Reset timer.
        timer = 0f;
        Debug.Log("yo3");
        // If the player has health to lose he gets D A M A G E D
        if (playerHealth.currHealth > 0)
        {
            // ... damage the player.
            playerHealth.TakeDamage(damage);
        }
    }
}

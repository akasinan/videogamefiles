using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPickup : MonoBehaviour {
    public int heal = 30;

    Animator anim;
    GameObject player;
    PlayerHealth playerHealth;
    public AudioClip pickupClip;
    AudioSource pickupAudio;
    CapsuleCollider capsuleCollider;
    bool playerInRange;
    float timer;
    public float timeBetweenHeal = 0.5f;

    // Use this for initialization
    void Awake () {
        player = GameObject.FindGameObjectWithTag("Player");
        playerHealth = player.GetComponent<PlayerHealth>();
        pickupAudio = GetComponent<AudioSource>();
        capsuleCollider = GetComponent<CapsuleCollider>();
        anim = GetComponent<Animator>();
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

        if (timer >= timeBetweenHeal && playerInRange)
        {
            // ... heal the player.
            Heal();
        }

        // If the player has over 100 health...
        if (playerHealth.currHealth > 100)
        {
            playerHealth.currHealth = 100;
        }
    }

    void Heal()
    {
        timer = 0f;
        // If the player has health to lose he gets healed
        if (playerHealth.currHealth > 0)
        {
            // ... heal the player.
            playerHealth.GainHealth(heal);
            GetPickedUp();
        }
    }

    void GetPickedUp()
    {
        capsuleCollider.isTrigger = true;
        pickupAudio.clip = pickupClip;
        pickupAudio.Play();
        GetComponent<Rigidbody>().isKinematic = true;
        Destroy(gameObject,0.1f);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoalObjectPickup : MonoBehaviour {

    Animator anim;
    GameObject player;
    TrackGoalObjects goal;
    public AudioClip pickupClip;
    AudioSource pickupAudio;
    SphereCollider sphereCollider;
    bool playerInRange;
    float timer;
    public float timeBetweenWin = 0.5f;

    // Use this for initialization
    void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        goal = player.GetComponent<TrackGoalObjects>();
        pickupAudio = GetComponent<AudioSource>();
        sphereCollider = GetComponent<SphereCollider>();
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
    void Update()
    {
        timer += Time.deltaTime;

        if (timer >= timeBetweenWin && playerInRange)
        {
            // ... let the player win.
            Win();
        }
        
    }

    void Win()
    {
        timer = 0f;
        Debug.Log("yeee");
        goal.PickupGoal();
        GetPickedUp();
    }

    void GetPickedUp()
    {
        sphereCollider.isTrigger = true;
        pickupAudio.clip = pickupClip;
        pickupAudio.Play();
        //GetComponent<Rigidbody>().isKinematic = true;
        Destroy(gameObject, 0.1f);
    }
}

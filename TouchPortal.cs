using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchPortal : MonoBehaviour {

    Animator anim;
    GameObject player;
    TrackPortals portal;
    public AudioClip pickupClip;
    AudioSource pickupAudio;
    BoxCollider boxCollider;
    bool playerInRange;
    float timer;
    public float timeBetweenWin = 0.5f;
    public string level;


    // Use this for initialization
    void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        portal = player.GetComponent<TrackPortals>();
        pickupAudio = GetComponent<AudioSource>();
        boxCollider = GetComponent<BoxCollider>();
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
            // ... let the player enter next level.
            Enter();
        }

    }

    void Enter()
    {
        timer = 0f;
        portal.EnterPortal(level);
        GetEntered();
    }

    void GetEntered()
    {
        boxCollider.isTrigger = true;
        pickupAudio.clip = pickupClip;
        pickupAudio.Play();
        //GetComponent<Rigidbody>().isKinematic = true;
        Destroy(gameObject, 0.1f);
    }
}

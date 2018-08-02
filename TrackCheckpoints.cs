using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrackCheckpoints : MonoBehaviour {
    GameObject player;
    PlayerHealth health;
    TrackGoalObjects goal;
    Transform checkpoint;
    private static bool passedCheckpoint = false;
    private static bool created = false;

    // Use this for initialization
    void Awake () {
        if (!created)
        {
            DontDestroyOnLoad(this.gameObject);
            created = true;
            Debug.Log("Awake " + this.gameObject);
        }
        player = GameObject.FindGameObjectWithTag("Player");
        health = player.GetComponent<PlayerHealth>();
        goal = player.GetComponent<TrackGoalObjects>();
        checkpoint = GetComponent<Transform>();
        
    }

    void OnTriggerEnter(Collider other)
    {
        // If the entering collider is the player the player is in range.
        if (other.gameObject == player)
        {
            Debug.Log("PASSED CHECKPOINT");
            health.woke = false;
            passedCheckpoint = true;
        }
    }

    // Update is called once per frame
    void Update () {
        if (passedCheckpoint && health.woke)
        {
            health.woke = false;
            updateSpawn();
        }
    }

    void updateSpawn()
    {
        if (player != null)
        {
            player.transform.position = checkpoint.position;
            player.transform.rotation = checkpoint.rotation;
        }
    }
}

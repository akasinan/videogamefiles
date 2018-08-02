using System.Collections;
using System.Collections.Generic;
using UnityEngine.AI;
using UnityEngine;

public class EnemyMovement : MonoBehaviour {
    Transform player;
    PlayerHealth playerHealth;
    EnemyHealth enemyHealth;
    NavMeshAgent nav;
    float dist;
    //public float activedist;

    // Use this for initialization
    void Awake () {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        playerHealth = player.GetComponent<PlayerHealth>();
        enemyHealth = GetComponent<EnemyHealth>();
        nav = GetComponent<NavMeshAgent>();
	}
	
	// Update is called once per frame
	void Update () {
        dist = Vector3.Distance(player.position, transform.position);
        //Debug.Log(dist);
        if (enemyHealth.currHealth > 0 && playerHealth.currHealth > 0 && dist < 30f)//FIX
        {
            //Set nav mesh agent destination to the player
            
            if (!nav.enabled)
            {
                nav.enabled = true;
            }
            nav.SetDestination(player.position);
        }
        else
        {
            nav.enabled = false;
        }
	}
}

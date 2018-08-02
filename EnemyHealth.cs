using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour {

    public int initHealth = 100;
    public int currHealth;
    public float sinkSpeed = 2.5f;
    public AudioClip deathClip;

    Animator anim;
    AudioSource enemyAudio;
    ParticleSystem hitParticles;
    CapsuleCollider capsuleCollider;
    bool isKill;
    bool isSinking;

    // Use this for initialization
    void Awake() {
        anim = GetComponent<Animator>(); 
        enemyAudio = GetComponent<AudioSource>();
        //hitParticles = GetComponentInChildren();
        capsuleCollider = GetComponent <CapsuleCollider> ();
        currHealth = initHealth;
    }

    // Update is called once per frame
    void Update() {
        //If the enemy is sinking
        if (isSinking)
        {
            //move the enemy down
            transform.Translate(-Vector3.up * sinkSpeed * Time.deltaTime);
        }
    }

    public void GetHitByBat(int hitValue, Vector3 hitPoint)
    {
        if (isKill)
            return; //STOP STOP HE'S ALREADY DEAAAD
        enemyAudio.Play();
        currHealth -= hitValue; 
        if (currHealth <= 0)
        {
            Death(); //WHAT IS THE MEANING OF DEATH??
        }
        //Debug.Log("DIRECT HIT");
    }

    void Death()
    {
        isKill = true;
        capsuleCollider.isTrigger = true;
        anim.SetTrigger("DeadEnemy"); 
        enemyAudio.clip = deathClip;
        enemyAudio.Play();
        GetComponent<Rigidbody>().isKinematic = true;
        Destroy(gameObject, 1f);//TEMP
    }

    public void StartSinking()
    {
        //GetComponent<NavMeshAgent>().enabled = false; For navmesh  Fix later
        //GetComponent<Rigidbody>().isKinematic = true;
        // The enemy should no sink.
        isSinking = true;
        // After 2 seconds destory the enemy.
        //Destroy(gameObject, 2f);

    }
}

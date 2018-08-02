using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseballBat : MonoBehaviour {

    public int batDamage = 100;
    public float timeBetweenStrikes = 1f;
    public float range = 5f;

    float timer;
    Ray batRay;
    RaycastHit batHit;
    int hittableMask;
    //ParticleSystem batParticles;
    LineRenderer batLine;
    AudioSource batAudio;
    Light batLight; // maaaaybe
    float effectsDisplayTime = 0.2f;
    Animator anim;
    //CapsuleCollider cc;
    //public GameObject target;

	// Use this for initialization
	void Awake ()
    {
        //Create a layer mask for Shootable layer
        hittableMask = LayerMask.GetMask("Hittable");
        //Set up references FIX PLS I'll give you a dollar
        //batParticles = GetComponent<ParticleSystem>();
        batLine = GetComponent<LineRenderer>();
        batAudio = GetComponent<AudioSource>();
        batLight = GetComponent<Light>();
        anim = GetComponent<Animator>();
    }
	
	// Update is called once per frame
	void Update ()
    {
        //Add the time since Update was last called to the timer
        timer += Time.deltaTime;

        if (Input.GetMouseButtonDown(0) && timer >= timeBetweenStrikes)
        {
            //PUT ANIMATION HERE
            Strike();

        }
        // If the timer has exceeded the proportion of timeBetweenBullets that the effects should be displayed for...
        if(timer >= timeBetweenStrikes*effectsDisplayTime)
        {
            DisableEffects();
        }
    }

    public void Strike()
    {
        //RESET TIMER
        timer = 0f;
        Debug.Log("Bam");

        //Play bat sfx
        //batAudio.Play();

        //Stop the particles from playing if they were, then start the particles. FIX
        //batParticles.Stop();
        //batParticles.Play();

        batLine.enabled = true;
        batLine.SetPosition(0, transform.position);

        batRay.origin = transform.position;
        batRay.direction = transform.forward;
        
        //Perform raycast against game objects on the hittable layer if the hit happens
        if (Physics.Raycast(batRay, out batHit, range, hittableMask))
        {
            //Play bat sfx
            anim.SetTrigger("SwingBat");
            batAudio.Play();
            //Try to find EnemyHealth script on hit gameobject
            EnemyHealth enemyHealth = batHit.collider.GetComponent<EnemyHealth>();
            if(enemyHealth != null)
            {
                //Enable light
                batLight.enabled = true;
                enemyHealth.GetHitByBat(batDamage, batHit.point);
            }
            //Try to find NPCTrigger script
            NPCTrigger npcTrigger = batHit.collider.GetComponent<NPCTrigger>();
            if(npcTrigger != null)
            {
                npcTrigger.GetTalkedTo();
            }
            batLine.SetPosition(1, batHit.point);
        }
        else
        {
            //set the second position of the line renderer to the fullest extent of the bat's range.
            batLine.SetPosition(1, batRay.origin + batRay.direction * range);
            anim.SetTrigger("SwingBat");
        }

    }

    public void DisableEffects()
    {
        batLine.enabled = false;
        batLight.enabled = false;
    }
}

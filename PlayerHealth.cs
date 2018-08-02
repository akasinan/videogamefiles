using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityStandardAssets.Characters.FirstPerson;
using UnityEngine;

public class PlayerHealth : MonoBehaviour {

    public int initHealth = 100;
    public int currHealth;
    public Slider healthSlider;
    public Image damageImage;
    public AudioClip deathClip;
    public float flashSpeed = 1f;
    public Color flashColor = new Color(1f, 0f, 0f, 0.3f);
    public Color healColor = new Color(0f, 1f, 0.2f, 1f);
    RigidbodyFirstPersonController fpcontroller;
    AudioSource playerAudio;
    BaseballBat baseball;
    bool isDead;
    bool damaged;
    bool healed;
    public bool woke = false;

    // Use this for initialization
    void Awake () {
        playerAudio = GetComponent<AudioSource>();
        fpcontroller = GetComponent<RigidbodyFirstPersonController>();
        baseball = GetComponentInChildren<BaseballBat>();
        currHealth = initHealth;
        woke = true;
        Debug.Log(woke);
	}
	
	// Update is called once per frame
	void Update ()
    {
        //If player is healed flash other color
        if (healed)
        {
            Debug.Log("that's better");
            damageImage.color = healColor;
        }
        else
        {
            damageImage.color = Color.Lerp(damageImage.color, Color.clear, flashSpeed * Time.deltaTime);
        }
        healed = false;

        //If the player has been damaged flash color
        if (damaged)
        {
            Debug.Log("ow");
            damageImage.color = flashColor;
        }
        else
        {
            damageImage.color = Color.Lerp(damageImage.color, Color.clear, flashSpeed * Time.deltaTime);
        }
        damaged = false;

        
	}
    
    public void TakeDamage (int amount)
    {
        //Screen flashes when damaged
        damaged = true;
        currHealth -= amount;
        healthSlider.value = currHealth;
        playerAudio.Play();
        if(currHealth <= 0 && !isDead)
        {
            Death();
        }
    }

    public void GainHealth(int amount)
    {
        healed = true;
        currHealth += amount;
        healthSlider.value = currHealth;
    }

    void Death()
    {
        isDead = true;
        baseball.DisableEffects();
        playerAudio.clip = deathClip;
        playerAudio.Play();
        baseball.enabled = false;
        fpcontroller.enabled = false;
    }
}

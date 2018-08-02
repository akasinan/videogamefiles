using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityStandardAssets.Characters.FirstPerson;
using UnityEngine.SceneManagement;

public class TrackGoalObjects : MonoBehaviour {

    public int currHealth;
    public AudioClip winClip;
    RigidbodyFirstPersonController fpcontroller;
    AudioSource playerAudio;
    BaseballBat baseball;
    public bool isWon;
    bool pickup;
    public float restartDelay = 5f;
    Animator anim;
    float restartTimer;
    public int goalnum;
    GameObject signpost;
    SignPostTracker signpostGoals;
    bool updateGoals = true;


    // Use this for initialization
    void Awake()
    {
        playerAudio = GetComponent<AudioSource>();
        fpcontroller = GetComponent<RigidbodyFirstPersonController>();
        baseball = GetComponentInChildren<BaseballBat>();
        currHealth = GetComponent<PlayerHealth>().currHealth;
        signpost = GameObject.FindGameObjectWithTag("Signpost");
        signpostGoals = signpost.GetComponent<SignPostTracker>();
        goalnum = signpostGoals.goals;
    }

    // Update is called once per frame
    void Update()
    {   }

    public void PickupGoal()
    {
        //Screen flashes when winning
        pickup = true;
        Debug.Log("YEET");
        playerAudio.Play();
        signpostGoals.GoalGet();
        goalnum = signpostGoals.goals;
        Win();
    }
    

    void Win()
    {
        isWon = true;
        baseball.DisableEffects();
        playerAudio.clip = winClip;
        playerAudio.Play();
        baseball.enabled = false;
        fpcontroller.enabled = false;
        //anim.SetTrigger("Win");
    }
}

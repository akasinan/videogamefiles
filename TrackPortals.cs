using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityStandardAssets.Characters.FirstPerson;
using UnityEngine.SceneManagement;

public class TrackPortals : MonoBehaviour {

    public int currHealth;
    public AudioClip warpClip;
    RigidbodyFirstPersonController fpcontroller;
    AudioSource playerAudio;
    BaseballBat baseball;
    public bool isTouching;
    bool pickup;
    int goalnum;
    GameObject signpost;
    SignPostTracker signpostGoals;
    bool updateGoals = true;
    public string nextlevel;

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
    { }

    public void EnterPortal(string level)
    {
        //Screen flashes when winning
        pickup = true;
        nextlevel = level;
        Debug.Log("YEET");
        playerAudio.Play();
        goalnum = signpostGoals.goals;
        Enter();
    }


    void Enter()
    {
        isTouching = true;
        baseball.DisableEffects();
        playerAudio.clip = warpClip;
        playerAudio.Play();
        baseball.enabled = false;
        fpcontroller.enabled = false;
        //anim.SetTrigger("Win");
    }
}

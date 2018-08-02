using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCTrigger : MonoBehaviour {

    public Dialogue[] dialogue;
    Animator anim;
    AudioSource npcAudio;
    CapsuleCollider capsuleCollider;
    GameObject sign;
    SignPostTracker signpost;
    int goals;
    bool isTalking;

    // Use this for initialization
    void Awake()
    {
        //anim = GetComponent(); WILL FIX THIS LATER!!!
        npcAudio = GetComponent<AudioSource>();
        capsuleCollider = GetComponent<CapsuleCollider>();
        sign = GameObject.FindGameObjectWithTag("Signpost");
        signpost = sign.GetComponent<SignPostTracker>();
        goals = signpost.goals;
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void GetTalkedTo(/*int hitValue, Vector3 hitPoint*/)
    {
        Debug.Log("Hey");
        npcAudio.Play();
        TriggerDialogue();
    }

    public void TriggerDialogue()
    {
        if(FindObjectOfType<DialogueManager>().Talking())
        {
            return;
        }
        FindObjectOfType<DialogueManager>().StartDialogue(dialogue[goals]);
    }
}

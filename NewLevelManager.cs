using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class NewLevelManager : MonoBehaviour
{

    public TrackPortals portal;
    public float restartDelay = 5f;
    //Animator anim;
    float restartTimer;
    GameObject player;
    Text numGoals;

    // Use this for initialization
    void Awake()
    {
        //anim = GetComponent<Animator>();
        player = GameObject.FindGameObjectWithTag("Player");
        portal = player.GetComponent<TrackPortals>();
        //numGoals = GetComponentsInChildren<Text>()[5];
        //numGoals.text = goal.goalnum.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        if (portal.isTouching)
        {
            //numGoals.text = goal.goalnum.ToString();
            //anim.SetTrigger("Win");
            restartTimer += Time.deltaTime;
            Debug.Log(portal.nextlevel);
            if (restartTimer >= restartDelay)
            {
                SceneManager.LoadScene(portal.nextlevel, LoadSceneMode.Single);
            }
        }
    }
}
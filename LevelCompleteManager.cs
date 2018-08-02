using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelCompleteManager : MonoBehaviour {

    public TrackGoalObjects goal;
    public float restartDelay = 5f;
    Animator anim;
    float restartTimer;
    GameObject player;
    GameObject checkpoint;
    Text numGoals;

    // Use this for initialization
    void Awake () {
        anim = GetComponent<Animator>();
        player = GameObject.FindGameObjectWithTag("Player");
        goal = player.GetComponent<TrackGoalObjects>();
        numGoals = GetComponentsInChildren<Text>()[5];
        numGoals.text = goal.goalnum.ToString();
        checkpoint = GameObject.FindGameObjectWithTag("Checkpoint");
    }
	
	// Update is called once per frame
	void Update () {
		if(goal.isWon)
        {
            numGoals.text = goal.goalnum.ToString();
            Destroy(checkpoint);
            anim.SetTrigger("Win");
            restartTimer += Time.deltaTime;
            if(restartTimer >= restartDelay)
            {
                SceneManager.LoadScene("Level 1", LoadSceneMode.Single);
            }
        }
	}
}

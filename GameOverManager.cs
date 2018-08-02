using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverManager : MonoBehaviour {
    public PlayerHealth playerHealth;
    public float restartDelay = 5f;
    Animator anim;
    float restartTimer;
    GameObject player;

    // Use this for initialization
    void Awake () {
        anim = GetComponent<Animator>();
        player = GameObject.FindGameObjectWithTag("Player");
        playerHealth = player.GetComponent<PlayerHealth>();
    }
	
	// Update is called once per frame
	void Update () {
		if(playerHealth.currHealth<=0)
        {
            anim.SetTrigger("GameOver"); //FIX
            restartTimer += Time.deltaTime;
            if(restartTimer>=restartDelay)
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            }
        }
	}
}

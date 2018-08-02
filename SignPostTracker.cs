using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SignPostTracker : MonoBehaviour {

    public int goals = 0;
    private static bool created = false;

    // Use this for initialization
    void Awake () {
        if(!created)
        {
            DontDestroyOnLoad(this.gameObject);
            created = true;
            Debug.Log("Awake " + this.gameObject);
        }
    }

    // Update is called once per frame
    void Update () {
		
	}

    public void GoalGet ()
    {
        goals++;
    }
}

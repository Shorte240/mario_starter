using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoalScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    // Detect if player enters Goal
    void OnTriggerEnter (Collider col)
    {
        if (col.gameObject.name == "Player")
        {
            Application.LoadLevel("menu");
        }
    }
}

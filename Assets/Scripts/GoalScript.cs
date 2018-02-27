using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GoalScript : MonoBehaviour {

    AudioSource audioSource;

	// Use this for initialization
	void Start () {
        audioSource = GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    // Detect if player enters Goal
    void OnTriggerEnter (Collider col)
    {
        if (col.gameObject.name == "Player")
        {
            audioSource.Play();
            StartCoroutine("Wait");
        }
    }

    IEnumerator Wait()
    {
        yield return new WaitForSeconds(1);
        SceneManager.LoadScene("winGame");
    }
}

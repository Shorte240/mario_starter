using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinScript : MonoBehaviour {

    AudioSource audioSource;

    // Use this for initialization
    void Start () {
        audioSource = GetComponent<AudioSource>();
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    // Detect if player collides with Coin
    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.name == "Player")
        {
            audioSource.Play();
            // Add X to players score.
            StartCoroutine("Wait");
        }
    }

    IEnumerator Wait()
    {
        yield return new WaitForSecondsRealtime(0.45F);
        Destroy(gameObject);
    }
}

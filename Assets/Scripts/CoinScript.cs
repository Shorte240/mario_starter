using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinScript : MonoBehaviour {

    AudioSource audioSource;

    GameObject playerGameObject; // this is a reference to the player game object

    // Use this for initialization
    void Start () {
        audioSource = GetComponent<AudioSource>();
        // find the player game object in the scene
        playerGameObject = GameObject.FindGameObjectWithTag("Player");
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    // Detect if player collides with Coin
    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.name == "Player")
        {
            // play coin collection sound
            audioSource.Play();

            // get player script component
            Player playerComponent = playerGameObject.GetComponent<Player>();

            // add 100 to the players score
            playerComponent.Score = playerComponent.Score + 100;

            // wait before deleting coin
            StartCoroutine("Wait");
        }
    }

    IEnumerator Wait()
    {
        yield return new WaitForSecondsRealtime(0.45F);
        Destroy(gameObject);
    }
}

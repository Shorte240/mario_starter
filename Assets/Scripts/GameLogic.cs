using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameLogic : MonoBehaviour {

	Player playerComponent;

	public bool gameOver = false; // is the game over?

	// Use this for initialization
	void Start () {
		// find the player component
		playerComponent = GameObject.FindGameObjectWithTag ("Player").GetComponent<Player> ();
	}
	
	// Update is called once per frame
	void Update () {
		// if the player number of lives is zero, game over
		if (playerComponent.Lives == 0) {
			gameOver = true;

            // pause the game
            //Time.timeScale = 0.0f;
            // Go back to menu instead of pause.
            SceneManager.LoadScene("menu");
        }
	}
}

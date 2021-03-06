﻿using UnityEngine;
using System.Collections;
using System.IO;
using UnityEngine.SceneManagement;

public class Enemy : MonoBehaviour {

	// variables taken from CharacterController.Move example script
	// https://docs.unity3d.com/ScriptReference/CharacterController.Move.html
	public float speed = 6.0F;
	public float jumpSpeed = 8.0F;
	public float gravity = 20.0F;
	private Vector3 moveDirection = Vector3.zero;

	GameObject playerGameObject; // this is a reference to the player game object

	public Vector3 direction = new Vector3(1.0f, 0.0f, 0.0f); // normalised direction the enemy will move in

	Vector3 start_position; // start position of the enemy

	Vector3 start_direction; // start direction of the enemy

    public AudioSource audioSource; // source to play audio

    void Start()
	{
		// find the player game object in the scene
		playerGameObject = GameObject.FindGameObjectWithTag("Player");

		// record the start position
		start_position = transform.position;

		// record the start direction
		start_direction = direction;

        // get audio component
        audioSource = GetComponent<AudioSource>();
    }

	public void Reset()
	{
		// reset the enemy position to the start position
		transform.position = start_position;

		// reset the movement direction
		direction = start_direction;
	}

	void Update()
	{
		// get the character controller attached to the enemy game object
		CharacterController controller = GetComponent<CharacterController>();

		// check to see if the enemy is on the ground
		if (controller.isGrounded) 
		{
			// set character controller moveDirection to be the direction I want the enemy to move in
			moveDirection = direction;
			moveDirection *= speed;
		}


		// apply gravity to movement direction
		moveDirection.y -= gravity * Time.deltaTime;

		// make the call to move the character controller
		controller.Move(moveDirection * Time.deltaTime);
	}

	//
	// This function is called when a CharacterController moves into an object
	//
	void OnControllerColliderHit(ControllerColliderHit hit)
	{
		// find out what we've hit
		if (hit.collider.gameObject.CompareTag ("Pipe")) {
			// we've hit the pipe

			// flip the direction of the enemy
			direction = -direction;
		} else if (hit.collider.gameObject.CompareTag ("Player")) {
            // we've hit the player

            // remove a life from the player
            PlayerPrefs.SetInt("Lives", (PlayerPrefs.GetInt("Lives") - 1));

            // reset the player
            SceneManager.LoadScene("lostLife");

			// reset the enemy
			Reset();
		}
	}

    void OnTriggerEnter(Collider coll)
    {
        if(coll.gameObject.CompareTag ("Player"))
        {
            Debug.Log("HIT");
            Reset();

            // play coin collection sound
            audioSource.Play();

            // get player script component
            Player playerComponent = playerGameObject.GetComponent<Player>();

            // remove a life from the player
            playerComponent.Score = playerComponent.Score + 100;
        }
    }
}
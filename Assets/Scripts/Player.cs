﻿using UnityEngine;
using System.Collections;
using System.IO;

public class Player : MonoBehaviour {

	// variables taken from CharacterController.Move example script
	// https://docs.unity3d.com/ScriptReference/CharacterController.Move.html
	public float speed = 6.0F;
	public float jumpSpeed = 8.0F;
	public float gravity = 20.0F;
	private Vector3 moveDirection = Vector3.zero;

	public int Lives = 0; // number of lives the player has
    public int Score = 0; // score the player has

    AudioSource audioSource; // source to play audio

    Vector3 start_position; // start position of the player


	void Start()
	{
        // get audio component
        audioSource = GetComponent<AudioSource>();

        // record the start position of the player
        start_position = transform.position;

        if (PlayerPrefs.HasKey("Lives"))
        {
            Lives = PlayerPrefs.GetInt("Lives");
        }
    }

	public void Reset()
	{
		// reset the player position to the start position
		transform.position = start_position;
	}

	void Update()
	{

		// get the character controller attached to the player game object
		CharacterController controller = GetComponent<CharacterController>();


		// check to see if the player is on the ground
		if (controller.isGrounded) 
		{
			// set the movement direction based on user input and the desired speed
			moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0, 0);
			moveDirection = transform.TransformDirection(moveDirection);
			moveDirection *= speed;

			// check to see if the player should jump
			if (Input.GetButton("Jump"))
            {
				moveDirection.y = jumpSpeed;

                // play coin collection sound
                audioSource.Play();
            }
		}

		// apply gravity to movement direction
		moveDirection.y -= gravity * Time.deltaTime;

		// make the call to move the character controller
		controller.Move(moveDirection * Time.deltaTime);
	}
}
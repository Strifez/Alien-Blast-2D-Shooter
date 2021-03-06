﻿using UnityEngine;
using System.Collections;

//Jason Huang 300818592
//Source: Unity 2D Space Shooter Tutorial BY PIXELELMENT GAMES
//Last Modified: Oct,5,2015
//Description: Use to control the instantiation and destruction of the player bullet

public class PlayerBullet : MonoBehaviour {
	//public instances
	public int addPoints; // adding points
	public float speed;
	//private instances
	private PlayerCollider playerCollider; //reference purposes
	// Use this for initialization
	void Start () {
		GameObject playerColliderObject = GameObject.FindWithTag("Player"); //to call another method from another script, reference is required
		if (playerColliderObject != null)
		{
			playerCollider = playerColliderObject.GetComponent<PlayerCollider>();
		}
	}
	
	// Update is called once per frame
	void Update () {
		//Get the Bullet's current position;
		Vector2 position = transform.position;

		//compute the bullet's new position
		position = new Vector2 (position.x + speed + Time.deltaTime, position.y );

		//update the bullet's position
		transform.position = position;

		// this is the top-right point of the screen
		Vector2 max = Camera.main.ViewportToWorldPoint (new Vector2 (1, 1));

		// if the bullet went outside the screen on the right, then destroy the bullet (this code is found in a Unity tutorial, please check External Document for source)
		if (transform.position.x > max.x) {
			Destroy(gameObject);
		}
	}
	//triggers
	void OnTriggerEnter2D(Collider2D otherGameObject) { //trigger to add points and destroy gameObject
		if (otherGameObject.tag == "Enemy") {
			Destroy (gameObject); 
			playerCollider.ScoreCheck(addPoints); //add 100 points
		}

	}

}


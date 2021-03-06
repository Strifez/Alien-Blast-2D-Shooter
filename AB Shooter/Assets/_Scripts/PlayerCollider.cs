﻿using UnityEngine;
using System.Collections;
using UnityEngine.UI;

//Jason Huang 300818592
//Source: Professor Tom's Mail Pilot
//Last Modified: Oct,5,2015
//Description: Contains the GUI of the Game and the Triggers used to Add Points and Minus Lives

public class PlayerCollider : MonoBehaviour {

	public Text pointsLabel; // this is mostly taken from Mail Pilot done in Class
	public Text heartsLabel;
	public int pointsValue = 0;
	public int heartsValue = 10;
	public Text gameOverLabel;
	public Text totalPointsLabel;
	public int minusDmg= 1;
	public int DstonePoints= 300;

	private AudioSource[] _audioSources; // an array of AudioSources
	private AudioSource _backgroundMusic, _splat;
	// Use this for initialization
	void Start () {
			this.gameOverLabel.enabled = false;			// this is for the GUI text making sure the gameover text is not displayed until its time
			this.totalPointsLabel.enabled = false;
			this._audioSources = this.GetComponents<AudioSource> ();
			this._backgroundMusic = this._audioSources [1];
			//this._splat = this._audioSources [2];
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter2D(Collider2D otherGameObject) { //Pick Up Item trigger
		if (otherGameObject.tag == "DStone") {
			ScoreCheck (DstonePoints); //+ 300 points for picking up Dstone
		}

		if (otherGameObject.tag == "Enemy") { 	//Enemy Trigger
			LifeCheck (minusDmg); // minus 1 life
			}
		}

		public void ScoreCheck(int newScoreCheck) // This checks and updates the score
	{
		pointsValue += newScoreCheck;
		DisplayScore ();
	}

	public void DisplayScore (){
		pointsLabel.text = "DStone: " + pointsValue; // This displays the score
	}

	public void LifeCheck (int newLifeCheck)//This checks and updates the life
	{
		heartsValue -= newLifeCheck;
		DisplayLife ();
	}
	public void DisplayLife() // This displays the Life
	{
		heartsLabel.text = "Hearts: " + heartsValue;
		if (this.heartsValue == 0) {
			this._EndGame ();
		}
	}
		
		public void _EndGame(){
			Destroy (gameObject);
			this.pointsLabel.enabled = false;
			this.heartsLabel.enabled = false;
			this.gameOverLabel.enabled = true;
			this.totalPointsLabel.enabled = true;
			this.totalPointsLabel.text = "Score: " + this.pointsValue;
		}

	}
	


using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PlayerCollider : MonoBehaviour {

	public Text pointsLabel; // this is mostly taken from Mail Pilot done in Class
	public Text heartsLabel;
	public int pointsValue = 0;
	public int heartsValue = 10;
	public Text gameOverLabel;
	public Text totalPointsLabel;
	public int minusDmg= 1;

	private AudioSource[] _audioSources; // an array of AudioSources
	private AudioSource _backgroundMusic, _bulletshot;
	// Use this for initialization
	void Start () {
			this.gameOverLabel.enabled = false;			// this is for the GUI text making sure the gameover text is not displayed until its time
			this.totalPointsLabel.enabled = false;
			this._audioSources = this.GetComponents<AudioSource> ();
			this._backgroundMusic = this._audioSources [1];
			this._bulletshot = this._audioSources [2];
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter2D(Collider2D otherGameObject) { //Pick Up Item trigger
		if (otherGameObject.tag == "DStone") {
			this.pointsValue += 300;
		}

		if (otherGameObject.tag == "Enemy") { 		//Enemy Trigger
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
	


using UnityEngine;
using System.Collections;

[System.Serializable]
public class Speed {
	public float minSpeed, maxSpeed;
}

[System.Serializable]
public class Drift {
	public float minDrift, maxDrift;
}

[System.Serializable]
public class BoundaryEnemy {
	public float xMin, xMax, yMin, yMax;
}

public class EnemyController : MonoBehaviour {

		// PUBLIC INSTANCE VARIABLES
		public Speed speed;
		public Drift drift;
		public BoundaryEnemy boundary;
		
		// PRIVATE INSTANCE VARIABLES
		private float _CurrentSpeed;
		private float _CurrentDrift;
		
		// Single Audio being played is when the enemy dies it makes the sound
		AudioSource _deathSound;

		// Use this for initialization
		void Start () {
		this._Reset ();
		_deathSound = GetComponent<AudioSource> (); // reason for not using the array is because it had problems when playing the sound and destroying the object
	}
		
		// Update is called once per frame
		void Update () {
			Vector2 currentPosition = gameObject.GetComponent<Transform> ().position;
			currentPosition.x -= this._CurrentDrift;
			currentPosition.y += this._CurrentSpeed;
			gameObject.GetComponent<Transform> ().position = currentPosition;
			
			// Check left boundary, if the enemy passes the left side reset the enemy 
			if (currentPosition.x <= boundary.xMin) { 
				this._Reset();
			}
		}
		
	void OnTriggerEnter2D(Collider2D otherGameObject) {
		if (otherGameObject.tag == "Bullet"){
			this._Reset();
			_deathSound.Play ();
		}

	}
		// resets the Enemy method
		public void _Reset() {
			this._CurrentDrift = Random.Range (drift.minDrift, drift.maxDrift);
			this._CurrentSpeed = Random.Range (speed.minSpeed, speed.maxSpeed);
			Vector2 resetPosition = new Vector2 (boundary.xMax, Random.Range (boundary.yMin, boundary.yMax));
			gameObject.GetComponent<Transform> ().position = resetPosition;
		}
		

	}



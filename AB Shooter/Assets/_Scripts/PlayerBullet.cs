using UnityEngine;
using System.Collections;

public class PlayerBullet : MonoBehaviour {
	public int addPoints;
	public float speed;
	private PlayerCollider playerCollider;
	// Use this for initialization
	void Start () {
		GameObject playerColliderObject = GameObject.FindWithTag("Player");
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

		// if the bullet went outside the screen on the right, then destroy the bullet
		if (transform.position.x > max.x) {
			Destroy(gameObject);
		}
	}

	void OnTriggerEnter2D(Collider2D otherGameObject) {
		if (otherGameObject.tag == "Enemy") {
			Destroy (gameObject); 
			playerCollider.ScoreCheck(addPoints); //add 100 points
		}

	}

	private void _death ()
	{
		Destroy (gameObject);
	}
}


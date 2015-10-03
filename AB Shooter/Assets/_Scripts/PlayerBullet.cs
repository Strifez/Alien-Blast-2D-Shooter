using UnityEngine;
using System.Collections;

public class PlayerBullet : MonoBehaviour {

	float speed;
	// Use this for initialization
	void Start () {
		speed = 0.25f;
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
}

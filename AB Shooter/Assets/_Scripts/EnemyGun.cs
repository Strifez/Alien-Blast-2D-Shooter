using UnityEngine;
using System.Collections;

public class EnemyGun : MonoBehaviour {

	public GameObject EnemyBulletGo;
	// Use this for initialization
	void Start () {
		//fire an enemy bullet after 1 second
		Invoke ("FireEnemyBullet", 1f);
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	//Function to fire an enemy bullet
	void FireEnemyBullet()
	{
		GameObject playerShip = GameObject.Find ("Player");

		if (playerShip != null) {
			GameObject bullet = (GameObject)Instantiate(EnemyBulletGo);

			//set the bullets initial position
			bullet.transform.position = transform.position;

			//compute the bullet's direction towards the player's ship
			Vector2 direction = playerShip.transform.position - bullet.transform.position;

			//set the bullet's direction
			bullet.GetComponent<EnemyBullet>().SetDirection(direction);

			//Fire more bullets
			Invoke ("FireEnemyBullet", 3f);
		}
	}
}

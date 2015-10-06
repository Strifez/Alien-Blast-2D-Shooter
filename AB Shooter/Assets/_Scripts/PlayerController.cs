using UnityEngine;
using System.Collections;

//Jason Huang 300818592
//Source: Unity 2D Space Shooter Tutorial
//Last Modified: Oct,5,2015
//Description: Controls the Players Movement

[System.Serializable]
public class Boundary
{
	public float xMin, xMax, yMin, yMax;
}

public class PlayerController : MonoBehaviour {

		//public instances
		public GameObject PlayerBulletGo;
		public GameObject BulletSpawn;
		
		public float speed;
		public Boundary boundary;

		public float fireRate;

		//private instances
		private float nextFire;
		
		void Update ()
		{
		if (Input.GetKeyDown ("space") && Time.time > nextFire) { //the fire button will be the spacebar

			nextFire = Time.time + fireRate;
			GameObject bullet1= (GameObject) Instantiate (PlayerBulletGo); //Instantiate the bullet
			bullet1.transform.position = BulletSpawn.transform.position; //set initial bullet position
		
		}

	}
		
		void FixedUpdate (){
			float moveHorizontal = Input.GetAxis ("Horizontal"); // how the player will move
			float moveVertical = Input.GetAxis ("Vertical");
			
			Vector2 movement = new Vector2(moveHorizontal, moveVertical); 
			GetComponent<Rigidbody2D>().velocity = movement * speed;
			
			GetComponent<Rigidbody2D>().position = new Vector2 //Boundary for the player so they dont move too close to the waves or off screen
				(
					Mathf.Clamp (GetComponent<Rigidbody2D>().position.x, boundary.xMin, boundary.xMax), 
					
					Mathf.Clamp (GetComponent<Rigidbody2D>().position.y, boundary.yMin, boundary.yMax)
					);
		}
	
}

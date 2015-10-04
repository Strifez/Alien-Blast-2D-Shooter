using UnityEngine;
using System.Collections;

[System.Serializable]
public class Boundary
{
	public float xMin, xMax, yMin, yMax;
}

public class PlayerController : MonoBehaviour {
		
		public GameObject PlayerBulletGo;
		public GameObject BulletSpawn;
		
		public float speed;
		public Boundary boundary;
		
		//public GameObject shot;
		//public Transform shotSpawn;
		public float fireRate;
		
		private float nextFire;
		
		void Update ()
		{
		if (Input.GetKeyDown ("space") && Time.time > nextFire) {

			nextFire = Time.time + fireRate;
			GameObject bullet1= (GameObject) Instantiate (PlayerBulletGo);
			bullet1.transform.position = BulletSpawn.transform.position; //set initial bullet position
		
		}


		/*if (Input.GetButton ("Fire1") && Time.time > nextFire) {
			nextFire = Time.time + fireRate;
			//Rigidbody.velocity.x = new Vector3 (shot, shotSpawn.Transform,Quaternion.identity); 
			Instantiate (shot, shotSpawn.position, Quaternion.identity); //as GameObject;
			//GetComponent<AudioSource>().Play ();
		}*/
	}
		
		void FixedUpdate (){
			float moveHorizontal = Input.GetAxis ("Horizontal");
			float moveVertical = Input.GetAxis ("Vertical");
			
			Vector2 movement = new Vector2(moveHorizontal, moveVertical); 
			GetComponent<Rigidbody2D>().velocity = movement * speed;
			
			GetComponent<Rigidbody2D>().position = new Vector2 
				(
					Mathf.Clamp (GetComponent<Rigidbody2D>().position.x, boundary.xMin, boundary.xMax), 
					
					Mathf.Clamp (GetComponent<Rigidbody2D>().position.y, boundary.yMin, boundary.yMax)
					);
		}


 }

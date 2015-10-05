using UnityEngine;
using System.Collections;

public class DStoneController : MonoBehaviour {

	public float speed;
	public Vector2 dStoneDirection = Vector2.left; //the Vector is travelling means moving to the left
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		transform.Translate (dStoneDirection * speed * Time.deltaTime);

		Vector2 min = Camera.main.ViewportToWorldPoint(new Vector2 (0,0));
		//this is the top-right
		Vector2 max = Camera.main.ViewportToWorldPoint(new Vector2 (1,1));
		
		//Destory the bullet
		if((transform.position.x < min.x) || (transform.position.x > max.x) || 
		   (transform.position.y <min.y) || (transform.position.y > max.y))
		{
			Destroy(gameObject);
		}
	}
	void OnTriggerEnter2D (Collider2D otherGameObject)
	{
		if (otherGameObject.tag == "Player") {
			Destroy (gameObject); //+ 300 points for picking up Dstone
		}
	}
}

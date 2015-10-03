using UnityEngine;
using System.Collections;

public class EnemyBullet : MonoBehaviour 
{
	float speed;
	Vector2 _direction;
	bool isReady;

	void Awake ()
	{
		speed = 5f;
		isReady = false;
	}

	void Start () 
	{
	
	}
	//Function to set the bullet's direction
	public void SetDirection(Vector2 direction)
	{
		//set the direction normalized, to get an unit vector
		_direction = direction.normalized;

		isReady = true;
	}

	void Update () 
	{
	if(isReady)
		{
			//get the bullet's current position
			Vector2 position = transform.position;
			//compute the bullet's new position
			position += _direction * speed * Time.deltaTime;
			//update the bulle's position
			transform.position = position;

			//Destorying the bullet when it leaves the screen
			//this is the bottom-left point of the screen
			Vector2 min = Camera.main.ViewportToWorldPoint(new Vector2 (0,0));
			//this is the top-right
			Vector2 max = Camera.main.ViewportToWorldPoint(new Vector2 (1,1));

			//Destory the bullet
			if((transform.position.x < min.x) || (transform.position.x> max.x) || 
			   (transform.position.y<min.y) || (transform.position.y > max.y))
			{
				Destroy(gameObject);
			}
		}
	}
}

	



using UnityEngine;
using System.Collections;

//Jason Huang 300818592
//Source: Unity 2D Space Shooter Tutorial
//Last Modified: Oct,5,2015
//Description: Use to control where and when the Pick Up Object is spawned

public class PickUpSpawn : MonoBehaviour {
	//public instance variables
	public int DstonePoints;
	public GameObject pickUp;
	public Vector2 spawnValues;
	public int pickUpCount;
	public float spawnWait;
	public float startWait;
	public float waveWait;
	//private instance variables
	private PlayerCollider playerCollider;

	// Use this for initialization
	void Start () {
		StartCoroutine (PickUpWaves ());

		GameObject playerColliderObject = GameObject.FindWithTag("Player"); //to call another method from another script, reference is required
		if (playerColliderObject != null)
		{
			 playerCollider= playerColliderObject.GetComponent<PlayerCollider>();
		}
	}
	
	// Update is called once per frame
	void Update () {

	}
		//Spawner
		IEnumerator PickUpWaves ()
		{
			yield return new WaitForSeconds (startWait);
			while (true)
			{
				for (int i = 0; i < pickUpCount; i++) 
				{
				  //(-spawnValues.x, spawnValues.x),(spawnValues.y)
				Vector2 spawnPosition = new Vector2 (spawnValues.x, Random.Range(spawnValues.y, -spawnValues.y));
					Quaternion spawnRotation = Quaternion.identity;
					Instantiate (pickUp, spawnPosition, spawnRotation);
					yield return new WaitForSeconds (spawnWait);
				}
				
				yield return new WaitForSeconds(waveWait);
			}
		}

	//Triggers
	void OnTriggerEnter2D(Collider2D otherGameObject) { //trigger to add points and destroy gameObject
		if (otherGameObject.tag == "Player") {
			Destroy (gameObject); 
			playerCollider.ScoreCheck (DstonePoints); //add 300 points
		}
	}

}




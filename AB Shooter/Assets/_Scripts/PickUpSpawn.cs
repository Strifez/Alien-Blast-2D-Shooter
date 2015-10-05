using UnityEngine;
using System.Collections;

public class PickUpSpawn : MonoBehaviour {
	public int DstonePoints;
	public GameObject pickUp;
	public Vector3 spawnValues;
	public int pickUpCount;
	public float spawnWait;
	public float startWait;
	public float waveWait;
	private PlayerCollider playerCollider;

	//public GUIText restartText;

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
	
		IEnumerator PickUpWaves ()
		{
			yield return new WaitForSeconds (startWait);
			while (true)
			{
				for (int i = 0; i < pickUpCount; i++) 
				{
					Vector3 spawnPosition = new Vector3 (Random.Range (-spawnValues.x, spawnValues.x), spawnValues.y, spawnValues.z);
					Quaternion spawnRotation = Quaternion.identity;
					Instantiate (pickUp, spawnPosition, spawnRotation);
					yield return new WaitForSeconds (spawnWait);
				}
				
				yield return new WaitForSeconds(waveWait);
				
			}
		}

	void OnTriggerEnter2D(Collider2D otherGameObject) { //trigger to add points and destroy gameObject
		if (otherGameObject.tag == "Player") {
			Destroy (gameObject); 
			playerCollider.ScoreCheck(DstonePoints); //add 300 points
		}
}
}




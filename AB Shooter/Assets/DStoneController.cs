using UnityEngine;
using System.Collections;

public class DStoneController : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	void OnTriggerEnter2D (Collider2D otherGameObject)
	{
		if (otherGameObject.tag == "Player") {
			Destroy (gameObject); //+ 300 points for picking up Dstone
		}
	}
}

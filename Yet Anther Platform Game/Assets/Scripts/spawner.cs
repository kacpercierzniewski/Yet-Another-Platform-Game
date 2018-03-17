using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawner : MonoBehaviour {
	public GameObject rock;
	public bool canSpawn;
	public int itemsToSpawn=1;
	public float xPosition=0f;
	public float yPosition=0f;
	public float xDistanceBeetwenSpawns=0f;
	public float yDistanceBeetwenSpawns=0f;


	// Use this for initialization
	void Awake(){
	}
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		StartCoroutine ("waitForSpawn");
	}
	private void 	OnTriggerEnter2D (Collider2D other){

		if (other.gameObject.CompareTag("Player") && canSpawn==true){
			canSpawn = false;
			for (int i = 0; i<itemsToSpawn; i++) {
				Instantiate (rock, new Vector3 (xPosition+ xDistanceBeetwenSpawns*i, yPosition+ yDistanceBeetwenSpawns*i, 0), Quaternion.identity);
			}
			Debug.Log ("test");

		}


	}
	IEnumerator waitForSpawn(){
		if (canSpawn==false)
		yield return new WaitForSeconds (5f);
		canSpawn = true;


	}
}

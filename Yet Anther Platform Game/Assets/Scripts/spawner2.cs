using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawner2 : MonoBehaviour {
	GameObject[] rock;

	// Use this for initialization
	void Awake(){

		rock = GameObject.FindGameObjectsWithTag("Rock2");
	}
	void Start () {

	}

	// Update is called once per frame
	void Update () {

	}
	private void 	OnTriggerEnter2D (Collider2D other){

		if (other.gameObject.CompareTag("Player")){

			rock[0].GetComponent<Rigidbody2D> ().WakeUp ();
			rock[1].GetComponent<Rigidbody2D> ().WakeUp ();

			Debug.Log ("DUPA1");
		}


	}
}


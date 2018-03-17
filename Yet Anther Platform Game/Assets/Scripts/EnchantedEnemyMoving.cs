using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnchantedEnemyMoving : MonoBehaviour {
	public  Rigidbody2D enemy;

	public float xDifference=10f;
	public float yDifference = 10f;
	public float yForce = 10f;	
	public float xForce = 10f;
	float x;
	float y;
	public bool xForceOn=false;
	public bool yForceOn=false;

	// Use this for initialization
	void Start () {
		  x = enemy.transform.position.x;
		 y = enemy.transform.position.y;
		if (yForceOn)
			enemy.AddForce(new Vector2 (0, 5*yForce));
		if (xForceOn)
			enemy.AddForce (new Vector2(5*xForce,0));
		
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		if (yForceOn) {
			if (enemy.transform.position.y >= y - yDifference)
				enemy.AddForce (new Vector2 (0, -yForce));

			if (enemy.transform.position.y <= y + yDifference)
				enemy.AddForce (new Vector2 (0, yForce));
		}
		if (xForceOn) {
			if (enemy.transform.position.x <= x - xDifference)
				enemy.AddForce (new Vector2 (xForce,0));

			if (enemy.transform.position.x >= x + xDifference)
				enemy.AddForce (new Vector2 (-xForce,0));
		}
	}
}

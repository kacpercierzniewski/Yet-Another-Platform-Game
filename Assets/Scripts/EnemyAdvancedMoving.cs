using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyAdvancedMoving : MonoBehaviour {
	private Rigidbody2D m_Rigidbody2D;
	public float yHighPosition;
	public float yLowPosition ;
	public float speed;
	public float rotation;
	public int direction;


	// Use this for initialization
	void Start () {
		m_Rigidbody2D = GetComponent<Rigidbody2D>();


	}

	// Update is called once per frame
	void Update () {

	}
	void FixedUpdate(){

		transform.Rotate(new Vector3 (0, 0,rotation*Time.deltaTime));
		if (transform.position.y<yLowPosition) {
			m_Rigidbody2D.AddForce( new Vector2(direction*2*speed, 2*speed));

		}
		if (transform.position.y>yHighPosition) {
			m_Rigidbody2D.AddForce(new Vector2(direction*(-2)*speed, -2*speed));

		}



	}

}

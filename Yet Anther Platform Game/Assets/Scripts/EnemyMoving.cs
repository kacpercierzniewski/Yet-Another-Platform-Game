using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyMoving : MonoBehaviour {
	public float speed = 10f;
	public Text text;
	private Rigidbody2D m_Rigidbody2D;
	public float yHighPosition=10f ;
	public float yLowPosition=-4f ;
	public float xHighPosition=10f ;
	public float xLowPosition=-4f ;
	public float forceY= -50f;
	public float forceX= 0f;
	public float rotation=5;


	// Use this for initialization
	void Start () {
		m_Rigidbody2D = GetComponent<Rigidbody2D>();
		m_Rigidbody2D.AddForce (new Vector2 (forceX, forceY));


	}
	
	// Update is called once per frame
	void Update () {
		
	}
	void FixedUpdate(){

		transform.Rotate(new Vector3 (0, 0,rotation*Time.deltaTime));
		if (transform.position.y<yLowPosition) {
			m_Rigidbody2D.AddForce( new Vector2(0, -2*forceY));

		}
		if (transform.position.y>yHighPosition) {
			m_Rigidbody2D.AddForce(new Vector2(0, 2*forceY));

		}

		if (transform.position.x<xLowPosition) {
			m_Rigidbody2D.AddForce( new Vector2(-2*forceX,0 ));

		}
		if (transform.position.x>xHighPosition) {
			m_Rigidbody2D.AddForce(new Vector2(2*forceX,0));

		}




}

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnchantedEnemyMoving : MonoBehaviour {
    private Rigidbody2D m_Rigidbody2D;

    public float xDifference=10f;
	public float yDifference = 10f;
	public float yForce = 10f;	
	public float xForce = 10f;
    public float rotation;

    float x;
	float y;
	public bool xForceOn=false;
	public bool yForceOn=false;

	// Use this for initialization
	void Start () {
        m_Rigidbody2D = GetComponent<Rigidbody2D>();

        x = m_Rigidbody2D.transform.position.x;
		 y = m_Rigidbody2D.transform.position.y;
		if (yForceOn)
            m_Rigidbody2D.AddForce(new Vector2 (0, 5*yForce));
		if (xForceOn)
            m_Rigidbody2D.AddForce (new Vector2(5*xForce,0));
		
	}
	
	// Update is called once per frame
	void FixedUpdate () {

        transform.Rotate(new Vector3(0, 0, rotation * Time.deltaTime));
        if (yForceOn) {
			if (m_Rigidbody2D.transform.position.y >= y - yDifference)
                m_Rigidbody2D.AddForce (new Vector2 (0, -yForce));

			if (m_Rigidbody2D.transform.position.y <= y + yDifference)
                m_Rigidbody2D.AddForce (new Vector2 (0, yForce));
		}
		if (xForceOn) {
			if (m_Rigidbody2D.transform.position.x <= x - xDifference)
                m_Rigidbody2D.AddForce (new Vector2 (xForce,0));

			if (m_Rigidbody2D.transform.position.x >= x + xDifference)
                m_Rigidbody2D.AddForce (new Vector2 (-xForce,0));
		}
	}
}

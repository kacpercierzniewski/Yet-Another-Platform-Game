using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnowBallRespawner : MonoBehaviour {
    public GameObject snowB;
    public float x;
    public float y;
    bool canSpawn;
    // Use this for initialization
    void Start () {
        Instantiate(snowB, new Vector3(x,y,0), Quaternion.identity);

    }

    // Update is called once per frame
    void FixedUpdate () {
	    if (GameObject.FindGameObjectWithTag("snowBall").transform.position.y<25) {
            Destroy(GameObject.FindGameObjectWithTag("snowBall"));
            Instantiate(snowB, new Vector3(x, y, 0), Quaternion.identity);

        }

    }

  


}

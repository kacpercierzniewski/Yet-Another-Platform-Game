using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonScripts : MonoBehaviour {
    // Use this for initialization
    AudioSource audioSource;
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		
	}


	public void goToOptions(){

		SceneManager.LoadScene ("Options");

	}

	public void goToMenu(){

		SceneManager.LoadScene ("Menu");

	}
	public void goToLevel1(){

		SceneManager.LoadScene ("aa");

	}
	public void goToLevel2(){

		SceneManager.LoadScene ("level 2");

	}
	public void OnValueChanged(float newValue)
	{
		audioSource.volume = newValue;
	}

}

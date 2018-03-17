using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace UnityStandardAssets._2D
{
[RequireComponent(typeof (PlatformerCharacter2D))]
public class Footsteps : MonoBehaviour {
		public  PlatformerCharacter2D m_Character;
		AudioSource audioSource;
	// Use this for initialization
	void Start () {
			audioSource = GetComponent<AudioSource>();
			}
	
	// Update is called once per frame
	void Update () {
			if (m_Character.m_Grounded==true && (Input.GetAxis("Horizontal")>=0.1f || Input.GetAxis("Horizontal")<=-0.1f) && audioSource.isPlaying==false) {
				audioSource.pitch = Random.Range (0.4f, 0.8f);
				audioSource.volume = Random.Range (0.6f, 0.8f) * PlayerPrefs.GetFloat("sfx volume");
				audioSource.Play ();
		}
	}


}
}
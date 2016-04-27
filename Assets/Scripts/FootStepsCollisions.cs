using UnityEngine;
using System.Collections;

public class FootStepsCollisions : MonoBehaviour {

	public GameObject footStepsParticles;
	public AudioClip footStepsSound;
	public GameObject player;
	// Use this for initialization
	void Awake(){

		//player = GameObject.FindGameObjectWithTag ("Player");


	}

	void OnTriggerEnter(Collider other) {

		if (other.tag == "Floor") {
		
			Instantiate (footStepsParticles, transform.position, transform.rotation);
			Invoke ("PlaySounds", 0.01f);

		}

	}
	void PlaySounds(){
	
		player.GetComponent<AudioSource> ().PlayOneShot (footStepsSound);
	
	}
}

using UnityEngine;
using System.Collections;

public class FootStepsCollisionsEnemy : MonoBehaviour {

	public GameObject footStepsParticles;
	public AudioClip footStepsSound;
	public GameObject enemy;
	// Use this for initialization
	void Awake(){




	}

	void OnTriggerEnter(Collider other) {

		if (other.tag == "Floor" ) {

			Debug.Log ("lel");
			Instantiate (footStepsParticles,new Vector3 (gameObject.transform.position.x, gameObject.transform.position.y- 0.07f , gameObject.transform.position.z), Quaternion.Euler (transform.rotation.x + 90, transform.rotation.y, transform.rotation.z));
			Invoke ("PlaySounds", 0.01f);

		}
		if (other.tag == "Player") {
		
			Instantiate (footStepsParticles,new Vector3 (gameObject.transform.position.x, gameObject.transform.position.y- 0.07f , gameObject.transform.position.z), Quaternion.Euler (transform.rotation.x + 180, transform.rotation.y, transform.rotation.z));
		
		}

	}
	void PlaySounds(){

		enemy.GetComponent<AudioSource> ().PlayOneShot (footStepsSound);

	}
}

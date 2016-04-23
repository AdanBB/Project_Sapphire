using UnityEngine;
using System.Collections;

public class FootStepsCollisions : MonoBehaviour {

	public GameObject footStepsParticles;
	// Use this for initialization
	void OnTriggerEnter(Collider other) {

		if (other.tag == "Floor") {
		
			Instantiate (footStepsParticles, transform.position, transform.rotation);

		}

	}
}

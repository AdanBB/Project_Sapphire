using UnityEngine;
using System.Collections;

public class BoosDetection : MonoBehaviour {

	private Animator boosAnimator;
	public AudioClip epicMusic;
	// Use this for initialization
	void Start () {
	

		boosAnimator = GetComponentInChildren<Animator> ();


	}
	
	// Update is called once per frame
	void Update () {
	
	}
	void OnTriggerEnter(Collider other) {

		if (other.tag == "Player") {
		
		
			boosAnimator.SetBool ("isBuilding", true);

			GetComponent<AudioSource> ().PlayOneShot (epicMusic);
		
		}
			
	} 
}

using UnityEngine;
using System.Collections;

public class BoosDetection : MonoBehaviour {

	private Animator boosAnimator;
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
		
		}
			
	} 
}

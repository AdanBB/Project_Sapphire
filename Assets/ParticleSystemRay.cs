using UnityEngine;
using System.Collections;

public class ParticleSystemRay : MonoBehaviour {

	private bool active;

	public GameObject particleSystemCollision;
	// Use this for initialization
	void Start () {
		active = false;
	}
	
	// Update is called once per frame
	void Update () {
	

		if (active) {
		
			Instantiate (particleSystemCollision, new Vector3 (transform.position.x, -0.59f, transform.position.z),transform.rotation );
		
		}else if (!active) {



		}
	}
		
	public void setActive(){

		active = true;

	}
	public void setDesactive(){

		active = false;

	}
}

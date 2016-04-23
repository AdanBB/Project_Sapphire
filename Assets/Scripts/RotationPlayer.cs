using UnityEngine;
using System.Collections;

public class RotationPlayer : MonoBehaviour {

	private GameObject camera;
	// Use this for initialization
	void Start () {

		camera = GameObject.FindGameObjectWithTag ("Camera");
	}
	
	// Update is called once per frame
	void Update () {
	
		if (Input.GetKey (KeyCode.A)) {

			this.transform.Rotate (Vector3.down);
			//camera.transform.Rotate (Vector3.down);

		
		}
		if (Input.GetKey (KeyCode.D)) {

			this.transform.Rotate (Vector3.up);
			//camera.transform.Rotate (Vector3.up);
		}
	}
}

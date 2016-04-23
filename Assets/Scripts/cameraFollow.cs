using UnityEngine;
using System.Collections;

public class cameraFollow : MonoBehaviour {

	private GameObject camera;
	private GameObject player;

	public Vector3 rotationEuler;

	public Vector3 playerRotation;

	public bool isRotate;

	// Use this for initialization

	void Start () {

		camera = GameObject.FindGameObjectWithTag ("Camera");

		player = GameObject.FindGameObjectWithTag ("Player");

	}
	
	// Update is called once per frame
	void Update () {

		playerRotation = player.transform.rotation.eulerAngles;

		rotationEuler = camera.transform.rotation.eulerAngles;

		transform.rotation = Quaternion.Euler (0, Mathf.Abs (rotationEuler.y), 0 );


		//if((playerRotation <= rotationEuler+10)&&(playerRotation <= rotationEuler+10))

		if (rotationEuler.y != playerRotation.y) {
		
			isRotate = false;
		
		} else
			isRotate = true;

		/*if (rotationEuler.y <= playerRotation.y + 20f) {
			
			Debug.Log ("true");
			isRotate = true;

		} else if (rotationEuler.y >= playerRotation.y + 340f) {

			Debug.Log ("true");
			isRotate = true;

		} else {
		
			isRotate = false;
			Debug.Log("false");
		}
		*/
			
	}
}

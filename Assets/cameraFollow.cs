using UnityEngine;
using System.Collections;

public class cameraFollow : MonoBehaviour {

	private GameObject camera;

	public Quaternion rotation;

	public Vector3 rotationEuler;

	// Use this for initialization

	void Start () {

		camera = GameObject.FindGameObjectWithTag ("Camera");
	}
	
	// Update is called once per frame
	void Update () {
	
		//this.transform.Rotate (new Vector3 (0, camera.transform.localEulerAngles.y, 0));

		rotation = camera.transform.rotation;

		rotationEuler = camera.transform.rotation.eulerAngles;


		transform.rotation = Quaternion.Euler (0, Mathf.Abs (rotationEuler.y), 0 );

		//this.transform.rotation.y = rotationEuler.y;

		//transform.rotation.eulerAngles = rotationEuler;

		//rotation = (Vector3)camera.transform.rotation;
	}
}

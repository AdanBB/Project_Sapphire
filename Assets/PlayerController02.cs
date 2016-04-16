using UnityEngine;
using System.Collections;

public class PlayerController02 : MonoBehaviour {


	private Rigidbody rb;
	private Animator myAnimator;
	private cameraFollow direction;

	public float speed;
	public bool isJumping;
	public float jumpHeight;

	public bool isRotating;

	// Use this for initialization
	void Awake () {
	
		rb = transform.parent.GetComponent<Rigidbody>();
		myAnimator = transform.parent.GetComponent<Animator>();
		direction = transform.GetComponent<cameraFollow> ();
		rb.useGravity = true;
	}
	
	// Update is called once per frame
	void Update () {

		if (Input.GetButtonDown ("Jump")) {
			rb.velocity = new Vector3 (0, jumpHeight, 0);
		}
		if (Input.GetKey(KeyCode.W))
		{
			rb.velocity = new Vector3(0, rb.velocity.y, speed);
			//rigidbody.AddForce(Vector3.right * movementForce * Time.deltaTime * 100);
		}
		if (Input.GetKey(KeyCode.S))
		{
			rb.velocity = new Vector3(0, rb.velocity.y, - speed);
			//rigidbody.AddForce(Vector3.right * movementForce * Time.deltaTime * 100);
		}
		if (Input.GetKey(KeyCode.D))
		{

			//Rotate Player, check detection.isRotate true and W
			Rotate(1);
			//rigidbody.AddForce(Vector3.right * movementForce * Time.deltaTime * 100);
		}
		if (Input.GetKey(KeyCode.A))
		{
			//Rotate Player, check detection.isRotate true and W
			Rotate(2);
			//rigidbody.AddForce(Vector3.right * movementForce * Time.deltaTime * 100);
		}

	}
	void Rotate(int i){
		if (i == 1) {
		
			//Rotation to the Right
			Debug.Log(direction.rotationEuler.y + 90);
			Debug.Log((direction.rotationEuler.y + 90) % 360);
			/*if (transform.parent.rotation.eulerAngles.y <= direction.rotationEuler.y + 90) {
				transform.parent.transform.rotation = Quaternion.Euler (0, (direction.rotationEuler.y + 90) %360, 0 );
			}*/
			transform.parent.transform.rotation = Quaternion.Euler (0, (direction.rotationEuler.y + 90) %360, 0 );

		
		}
		if (i == 2) {
			//rotation to the Left


			Debug.Log(direction.rotationEuler.y - 90);
			Debug.Log((direction.rotationEuler.y - 90) % 360);
			/*if (transform.parent.rotation.eulerAngles.y != direction.rotationEuler.y) {
				transform.parent.transform.rotation = Quaternion.Euler (0, (direction.rotationEuler.y -90) %360, 0 );
			
			}*/
			transform.parent.transform.rotation = Quaternion.Euler (0, (direction.rotationEuler.y -90) %360, 0 );
		}
	
	
	}
}

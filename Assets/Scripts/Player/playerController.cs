using UnityEngine;
using System.Collections;

public class playerController : MonoBehaviour
{

    //Public Variables

    public Rigidbody rb;

    public float speed = 10.0f;
	private float _speed;
    public float gravity = 10.0f;
    public float maxVelocityChange = 10.0f;
    public bool canJump = true;
    public float jumpHeight = 2.0f;
    public bool grounded = false;
    public bool isInvulnerable;
    public bool _isMoving;
    private Animator myAnimator;
	private cameraFollow direction;
	public bool isRotating;
	private float counterJump;
	public bool isJumping;
	public PlayerAI weapon;


    void Awake()
    {
		
		rb = transform.parent.GetComponent<Rigidbody>();
		myAnimator = transform.parent.GetComponent<Animator>();
		direction = transform.GetComponent<cameraFollow> ();

		_speed = speed;
		isRotating = false;
        rb.freezeRotation = true;
        rb.useGravity = false;
        isInvulnerable = false;
		isJumping = false;
        _isMoving = false;
    }

	void FixedUpdate(){

		if (weapon.isAiming) {

			transform.parent.transform.rotation = Quaternion.Euler (0, (direction.rotationEuler.y) %360, 0 );
			speed = 3;
		
		} else if (!weapon.isAiming) {
		
		
			speed = _speed;
		}


        if (weapon.isAttacking) {
		
			speed = 0;
		
		} else if (speed == 0){

			speed = _speed;
		}
			

		if (Input.GetKeyDown (KeyCode.G)) {
			//gravity = 0;
			isInvulnerable = !isInvulnerable;
		}
		if (!grounded) {
			// Calculate how fast we should be moving
		Vector3 targetVelocity = new Vector3 (Input.GetAxis ("Horizontal")	, 0, Input.GetAxis ("Vertical"));
			targetVelocity = transform.TransformDirection (targetVelocity);
			targetVelocity *= (speed - 2);
		if (Input.GetButton ("Vertical")) {
			myAnimator.SetBool ("IsMoving", true);
            _isMoving = true;
		} else {
			myAnimator.SetBool ("IsMoving", false);
            _isMoving = false;
		}
			// Apply a force that attempts to reach our target velocity
			Vector3 velocity = rb.velocity;
			Vector3 velocityChange = (targetVelocity - velocity);
			velocityChange.x = Mathf.Clamp (velocityChange.x, -maxVelocityChange, maxVelocityChange);
			velocityChange.z = Mathf.Clamp (velocityChange.z, -maxVelocityChange, maxVelocityChange);
			velocityChange.y = 0;
			rb.AddForce (velocityChange, ForceMode.VelocityChange);
		} else if (grounded) {
			// Calculate how fast we should be moving
		Vector3 targetVelocity = new Vector3 (Input.GetAxis ("Horizontal"), 0 , Input.GetAxis ("Vertical"));
			targetVelocity = transform.TransformDirection (targetVelocity);
			targetVelocity *= speed;
		if (Input.GetButton ("Vertical") || Input.GetButton ("Horizontal") ) {
			myAnimator.SetBool ("IsMoving", true);
            _isMoving = true;
		} else {
			myAnimator.SetBool ("IsMoving", false);
            _isMoving = false;
		}
			// Apply a force that attempts to reach our target velocity
			Vector3 velocity = rb.velocity;
			Vector3 velocityChange = (targetVelocity - velocity);
			velocityChange.x = Mathf.Clamp (velocityChange.x, -maxVelocityChange, maxVelocityChange);
			velocityChange.z = Mathf.Clamp (velocityChange.z, -maxVelocityChange, maxVelocityChange);
			velocityChange.y = 0;
			rb.AddForce (velocityChange, ForceMode.VelocityChange);

		CalculateDirection ();
			

			// Jump
		if (canJump && Input.GetButton ("Jump")) {

				Invoke ("Jump", 0.2f);
				isJumping = true;
				myAnimator.SetBool ("IsGrounded", false);

		}

	}



		if ((!direction.isRotate) && ((Input.GetButton ("Horizontal") || Input.GetButton ("Vertical"))))  {
		
		
			isRotating = true;

		
		}
		if (isRotating) {
		
			//Rotate ();
		
		}
		// We apply gravity manually for more tuning control
		rb.AddForce (new Vector3 (0, -gravity * rb.mass, 0));

		grounded = false;

	
	}
	void OnTriggerStay(Collider other) {
		if (other.tag == "Floor" || other.tag == "Platform") {
			if (!isJumping) {
				myAnimator.SetBool ("IsGrounded", true);
				grounded = true;
				Debug.Log ("Estoy tocando el suelo");
			}
		}




	}
	float CalculateJumpVerticalSpeed()
	{
		// From the jump height and gravity we deduce the upwards speed 
		// for the character to reach at the apex.
		return Mathf.Sqrt(2 * jumpHeight * gravity);

	}
	void Jump(){
	
		Vector3 velocity = rb.velocity;

		rb.velocity = new Vector3 (velocity.x, CalculateJumpVerticalSpeed (), velocity.z);
		isJumping = false;
	
	}

	void CalculateDirection(){


		if (Input.GetKey(KeyCode.W))
		{

			//Rotate Player, check detection.isRotate true and W


			if (Input.GetKey (KeyCode.D)) {
			
				Rotate (5);
			
			} else if (Input.GetKey (KeyCode.A)) {

				Rotate (6);

			} else
				Rotate (3);

			//rigidbody.AddForce(Vector3.right * movementForce * Time.deltaTime * 100);
		}
		else if (Input.GetKey(KeyCode.S))
		{

			//Rotate Player, check detection.isRotate true and W
			if (Input.GetKey (KeyCode.D)) {

				Rotate (7);

			} else if (Input.GetKey (KeyCode.A)) {

				Rotate (8);

			} else Rotate(4);
			//rigidbody.AddForce(Vector3.right * movementForce * Time.deltaTime * 100);
		}
		else if (Input.GetKey(KeyCode.D))
		{

			if (Input.GetKey (KeyCode.W)) {

				Rotate (5);

			}else if (Input.GetKey (KeyCode.S)) {

				Rotate (7);

			}else 
				Rotate(1);
			//rigidbody.AddForce(Vector3.right * movementForce * Time.deltaTime * 100);
		}

		else if (Input.GetKey(KeyCode.A))
		{
			//Rotate Player, check detection.isRotate true and W
			if (Input.GetKey (KeyCode.W)) {

				Rotate (6);

			}else if (Input.GetKey (KeyCode.S)) {

				Rotate (8);

			}else Rotate(2);
			//rigidbody.AddForce(Vector3.right * movementForce * Time.deltaTime * 100);
		}

	}
	void Rotate(int i){
		if (i == 1) {

			transform.parent.transform.rotation = Quaternion.Euler (0, (direction.rotationEuler.y + 90) %360, 0 );
		}
		else if (i == 2) {
			
			transform.parent.transform.rotation = Quaternion.Euler (0, (direction.rotationEuler.y -90) %360, 0 );
		}
		else if (i == 3) {
			
			transform.parent.transform.rotation = Quaternion.Euler (0, (direction.rotationEuler.y) %360, 0 );
		}
		else if (i == 4) {
			
			transform.parent.transform.rotation = Quaternion.Euler (0, (direction.rotationEuler.y + 180) %360, 0 );
		}
		else if (i == 5) {
			
			transform.parent.transform.rotation = Quaternion.Euler (0, (direction.rotationEuler.y + 45) %360, 0 );
		}
		else if (i == 6) {

			transform.parent.transform.rotation = Quaternion.Euler (0, (direction.rotationEuler.y -45) %360, 0 );
		}else if (i == 7) {

			transform.parent.transform.rotation = Quaternion.Euler (0, (direction.rotationEuler.y + 135) %360, 0 );
		}
		else if (i == 8) {

			transform.parent.transform.rotation = Quaternion.Euler (0, (direction.rotationEuler.y - 135) %360, 0 );
		}




	}
}
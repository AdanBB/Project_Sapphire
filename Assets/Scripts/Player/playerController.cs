using UnityEngine;
using System.Collections;

public class playerController : MonoBehaviour
{

    //Public Variables

    public Rigidbody rb;

    public float speed = 10.0f;
    public float gravity = 10.0f;
    public float maxVelocityChange = 10.0f;
    public bool canJump = true;
    public float jumpHeight = 2.0f;
    public bool grounded = false;
    public bool isInvulnerable;
    private Animator myAnimator;



    void Awake()
    {
		
		rb = transform.parent.GetComponent<Rigidbody>();
		myAnimator = transform.parent.GetComponent<Animator>();
        
        rb.freezeRotation = true;
        rb.useGravity = false;
        isInvulnerable = false;

    }

	void FixedUpdate(){
	
		if (Input.GetKeyDown(KeyCode.G))
		{
			//gravity = 0;
			isInvulnerable = !isInvulnerable;
		}
		if (!grounded)
		{
			// Calculate how fast we should be moving
			Vector3 targetVelocity = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
			targetVelocity = transform.TransformDirection(targetVelocity);
			targetVelocity *= (speed - 2);
			if (Input.GetButton("Horizontal") || Input.GetButton("Vertical"))
			{
				myAnimator.SetBool("IsMoving", true);
			}
			else
			{
				myAnimator.SetBool("IsMoving", false);
			}
			// Apply a force that attempts to reach our target velocity
			Vector3 velocity = rb.velocity;
			Vector3 velocityChange = (targetVelocity - velocity);
			velocityChange.x = Mathf.Clamp(velocityChange.x, -maxVelocityChange , maxVelocityChange);
			velocityChange.z = Mathf.Clamp(velocityChange.z, -maxVelocityChange , maxVelocityChange);
			velocityChange.y = 0;
			rb.AddForce(velocityChange, ForceMode.VelocityChange);
		}
		else if (grounded)
		{
			// Calculate how fast we should be moving
			Vector3 targetVelocity = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
			targetVelocity = transform.TransformDirection(targetVelocity);
			targetVelocity *= speed;
			if (Input.GetButton("Horizontal") || Input.GetButton("Vertical"))
			{
				myAnimator.SetBool("IsMoving", true);
			}
			else
			{
				myAnimator.SetBool("IsMoving", false);
			}
			// Apply a force that attempts to reach our target velocity
			Vector3 velocity = rb.velocity;
			Vector3 velocityChange = (targetVelocity - velocity);
			velocityChange.x = Mathf.Clamp(velocityChange.x, -maxVelocityChange, maxVelocityChange);
			velocityChange.z = Mathf.Clamp(velocityChange.z, -maxVelocityChange, maxVelocityChange);
			velocityChange.y = 0;
			rb.AddForce(velocityChange, ForceMode.VelocityChange);

			// Jump
			if (canJump && Input.GetButton("Jump"))
			{
				rb.velocity = new Vector3(velocity.x, CalculateJumpVerticalSpeed(), velocity.z);
				myAnimator.SetBool("IsGrounded", false);
			}
		}

		// We apply gravity manually for more tuning control
		rb.AddForce(new Vector3(0, -gravity * rb.mass, 0));

		grounded = false;

	
	}
	void OnTriggerStay(Collider other) {
		if (other.tag == "Floor") {

			myAnimator.SetBool ("IsGrounded", true);
			grounded = true;
			Debug.Log ("Estoy tocando el suelo");

		}




	}
	float CalculateJumpVerticalSpeed()
	{
		// From the jump height and gravity we deduce the upwards speed 
		// for the character to reach at the apex.
		return Mathf.Sqrt(2 * jumpHeight * gravity);

	}




    /*void FixedUpdate()
    {
        if (Input.GetKeyDown(KeyCode.G))
        {
            //gravity = 0;
            isInvulnerable = !isInvulnerable;
        }
        if (!grounded)
        {
            // Calculate how fast we should be moving
            Vector3 targetVelocity = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
            targetVelocity = transform.TransformDirection(targetVelocity);
            targetVelocity *= (speed - 2);
            if (Input.GetButton("Horizontal") || Input.GetButton("Vertical"))
            {
                myAnimator.SetBool("IsMoving", true);
            }
            else
            {
                myAnimator.SetBool("IsMoving", false);
            }
            // Apply a force that attempts to reach our target velocity
            Vector3 velocity = rb.velocity;
            Vector3 velocityChange = (targetVelocity - velocity);
            velocityChange.x = Mathf.Clamp(velocityChange.x, -maxVelocityChange , maxVelocityChange);
            velocityChange.z = Mathf.Clamp(velocityChange.z, -maxVelocityChange , maxVelocityChange);
            velocityChange.y = 0;
            rb.AddForce(velocityChange, ForceMode.VelocityChange);
        }
        else if (grounded)
        {
            // Calculate how fast we should be moving
            Vector3 targetVelocity = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
            targetVelocity = transform.TransformDirection(targetVelocity);
            targetVelocity *= speed;
            if (Input.GetButton("Horizontal") || Input.GetButton("Vertical"))
            {
                myAnimator.SetBool("IsMoving", true);
            }
            else
            {
                myAnimator.SetBool("IsMoving", false);
            }
            // Apply a force that attempts to reach our target velocity
            Vector3 velocity = rb.velocity;
            Vector3 velocityChange = (targetVelocity - velocity);
            velocityChange.x = Mathf.Clamp(velocityChange.x, -maxVelocityChange, maxVelocityChange);
            velocityChange.z = Mathf.Clamp(velocityChange.z, -maxVelocityChange, maxVelocityChange);
            velocityChange.y = 0;
            rb.AddForce(velocityChange, ForceMode.VelocityChange);

            // Jump
            if (canJump && Input.GetButton("Jump"))
            {
                rb.velocity = new Vector3(velocity.x, CalculateJumpVerticalSpeed(), velocity.z);
                myAnimator.SetBool("IsGrounded", false);
            }
        }

        // We apply gravity manually for more tuning control
        rb.AddForce(new Vector3(0, -gravity * rb.mass, 0));

        grounded = false;
    }
	void OnCollisionStay()
	{
		myAnimator.SetBool ("IsGrounded", true);
		grounded = true;

	}
   

    float CalculateJumpVerticalSpeed()
    {
        // From the jump height and gravity we deduce the upwards speed 
        // for the character to reach at the apex.
        return Mathf.Sqrt(2 * jumpHeight * gravity);

    }*/
	
}
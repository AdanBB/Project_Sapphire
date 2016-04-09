using UnityEngine;
using System.Collections;

public class MoveCharacterController : MonoBehaviour {
	float speed;
	float speedSprint;
	public float jumpSpeed = 8.0F;
	public float gravity = 20.0F;
	private Vector3 moveDirection = Vector3.zero;
	private CharacterController controller;

	Animation anim;

	private bool action = false;

	void Start() {
		speed = PlayerPrefs.GetFloat ("PLAYER_SPEED");
		speedSprint = speed * 1.75F;
		anim = GameObject.FindGameObjectWithTag("Hand").GetComponent<Animation>();
		controller = GetComponent<CharacterController>();
	}


	void Update() {



		if (Input.GetKeyDown (KeyCode.F)) action = true;
		else action = false;

		if (Input.GetKey (KeyCode.LeftShift))
			speed = speedSprint;
		else
			speed = PlayerPrefs.GetFloat ("PLAYER_SPEED");;

		if (!anim.IsPlaying ("Shoot")) anim.Play ("Idle");
		//if ((Input.GetKey (KeyCode.W) || Input.GetKey (KeyCode.A) || Input.GetKey (KeyCode.S) || Input.GetKey (KeyCode.D)) && !anim.IsPlaying ("Moving") && !anim.IsPlaying ("Shoot")) anim.Play ("Moving");


		if (controller.isGrounded) {
			moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
			moveDirection = transform.TransformDirection(moveDirection);
			moveDirection *= speed;
			if (Input.GetButton("Jump"))
				moveDirection.y = jumpSpeed;
			
		}
		moveDirection.y -= gravity * Time.deltaTime;
		controller.Move(moveDirection * Time.deltaTime);
	}

	public bool ActionPressed(){
		return action;
	}

	public void changeSpeed(){
		speed += 1;
		speedSprint = speed * 1.75F;
		PlayerPrefs.SetFloat ("PLAYER_SPEED", speed);
	}
}

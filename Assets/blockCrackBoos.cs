using UnityEngine;
using System.Collections;

public class blockCrackBoos : MonoBehaviour {

	public Animator anim;


	private int counet;

	private bool down = true;
	private bool up = false;

	public Transform A;


	void FixedUpdate(){

		if (down ) {


			transform.Translate(0,0 ,-20f* Time.deltaTime) ;


		}
		if (transform.position.y <= -60f || up ) {
			up = true;
			down = false;
			transform.Translate(0,0 ,20f* Time.deltaTime) ;
			anim.SetBool ("IsGrow", false);

		}
		if (transform.position.y >= -0.72f) {
			up = false;
			down = false;

		}


	}

	public void PreDown(){

		Invoke ("Down",0.7f);

	}
	void Down(){

		down = true;
	}

}
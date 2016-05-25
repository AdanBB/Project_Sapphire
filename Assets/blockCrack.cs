using UnityEngine;
using System.Collections;

public class blockCrack : MonoBehaviour {

	public Animator anim;


	private int counet;

	private bool down = false;
	private bool up = false;

	public Transform A;


	void FixedUpdate(){

		if (down ) {
		
		
			transform.Translate(0,0 ,20f* Time.deltaTime) ;

		
		}
		if (transform.position.y <= -50f || up) {
			up = true;
			down = false;
			transform.Translate(0,0 ,-20f* Time.deltaTime) ;
			anim.SetBool ("IsGrow", false);
		
		}
		if (transform.position.y >= -0.72f) {
			up = false;
			down = false;
		
		}

	}
	void OnTriggerEnter(Collider other)
	{

		if (other.tag == "Player") {


			Debug.Log ("dsadsa");
			anim.SetBool ("IsGrow", true);

			PreDown ();
		}


	}
	public void PreDown(){
	
		Invoke ("Down",1.3f);
	
	}
	void Down(){
	
		down = true;
	}

}

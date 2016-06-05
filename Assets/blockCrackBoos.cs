using UnityEngine;
using System.Collections;

public class blockCrackBoos : MonoBehaviour {

	public Animator anim;


	private float counter;

	public bool down = true;
	private bool up = false;
	private bool scale = false;

	public GameObject explosionParticles;

	public Transform A;

	public Renderer[] childs;

	void Awake(){


		childs = GetComponentsInChildren<Renderer>();

	}

	void FixedUpdate(){

		if (down ) {


			transform.Translate(0,0 ,-20f* Time.deltaTime) ;


		}
		if (transform.position.y <= -60f || up ) {
			up = true;
			down = false;
			transform.position = new Vector3 (transform.position.x ,-0.59f , transform.position.z);

			anim.SetBool ("IsGrow", false);

		}
		if (transform.position.y >= -0.72f) {
			up = false;
			down = false;

		}


	}

	public void PreDown(){
		//Instantiate (explosionParticles,transform.position,transform.rotation);
		Invoke ("Down",0.7f);

	}
	void Down(){

		down = true;
	}

}
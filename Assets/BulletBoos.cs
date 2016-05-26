using UnityEngine;
using System.Collections;

public class BulletBoos : MonoBehaviour {

	public float speed;

	public float damage;

	// Use this for initialization

	
	// Update is called once per frame
	void FixedUpdate()
	{

		transform.Translate(Vector3.forward * Time.deltaTime * speed);

	}
	void OnTriggerEnter(Collider other)
	{
		//Debug.Log (other.name);

		if (other.tag == "Floor") {
		
		
			other.GetComponent<blockCrackBoos> ().anim.SetBool ("IsGrow", true);
			other.GetComponent<blockCrackBoos> ().PreDown ();

			Destroy (this.gameObject);
		}


	}

}

using UnityEngine;
using System.Collections;

public class PaintProperties_Green : MonoBehaviour {

	public float addSpeed;
	private playerController playerCon;
	private GameObject parent;

	void Awake()
	{
		playerCon = GameObject.Find ("Direction").GetComponent<playerController> ();
		parent = GameObject.Find ("SplashParent");
		gameObject.transform.parent = parent.transform;

	}

	void OnTriggerEnter(Collider other)
	{
		if (other.tag == "Player") 
		{
			playerCon.rb.AddRelativeForce (Vector3.forward * addSpeed);
		}
	}

	void OnTriggerStay(Collider other)
	{
		if (other.tag == "Player") 
		{
			playerCon.rb.AddRelativeForce (Vector3.forward * addSpeed);
		}
	}

	void OnTriggerExit(Collider other)
	{
		if (other.tag == "Player") 
		{
			playerCon.rb.AddRelativeForce (Vector3.forward * (addSpeed * 2));
		}
	}
}
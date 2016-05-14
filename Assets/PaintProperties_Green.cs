using UnityEngine;
using System.Collections;

public class PaintProperties_Green : MonoBehaviour {

	public float addSpeed;
	private playerController playerCon;

	void Awake()
	{
		playerCon = GameObject.Find ("Direction").GetComponent<playerController> ();
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
using UnityEngine;
using System.Collections;

public class PaintProperties_Blue : MonoBehaviour {

	public float addJump;
	private playerController playerCon;

	void Awake()
	{
		playerCon = GameObject.Find ("Direction").GetComponent<playerController> ();
	}

	void OnTriggerEnter(Collider other)
	{
		if (other.tag == "Player") 
		{
			playerCon.jumpHeight += addJump;
		}
	}

	void OnTriggerExit(Collider other)
	{
		if (other.tag == "Player") 
		{
			playerCon.jumpHeight -= addJump;
		}
	}
}
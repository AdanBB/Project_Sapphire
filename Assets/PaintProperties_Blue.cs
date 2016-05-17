using UnityEngine;
using System.Collections;

public class PaintProperties_Blue : MonoBehaviour {

	public float addJump;
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
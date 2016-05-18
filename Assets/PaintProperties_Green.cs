using UnityEngine;
using System.Collections.Generic;

public class PaintProperties_Green : MonoBehaviour {

	public float addSpeed;

    public List<Texture> splashImages;

    private playerController playerCon;
	private GameObject parent;

	void Awake()
	{
        int randomImage = Random.Range(0, splashImages.Count);
        GetComponent<Renderer>().material.SetTexture("_MainTex", splashImages[randomImage]);

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
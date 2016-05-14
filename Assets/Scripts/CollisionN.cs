using UnityEngine;
using System.Collections;

public class CollisionN : MonoBehaviour {
	private Rigidbody rb;

	public playerController playerCont;
	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnCollisionStay()
	{
		playerCont.grounded = true;

	}

}

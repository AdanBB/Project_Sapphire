using UnityEngine;
using System.Collections;

public class boosLockAt : MonoBehaviour {

	private Transform player;

	public laserScript laser;




	// Use this for initialization
	void Start () {
	
		player = GameObject.FindGameObjectWithTag ("Player").transform;


	}
	
	// Update is called once per frame
	void Update () {
	

		transform.LookAt (player);






	}
	public void Shoot(){
	
	


	
	}
}

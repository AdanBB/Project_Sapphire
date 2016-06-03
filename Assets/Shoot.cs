using UnityEngine;
using System.Collections;

public class Shoot : MonoBehaviour {


	public GameObject shoot;

	private float counter;

	public float shootRatio;

	// Use this for initialization
	void Start () {
	
		counter = 0;

	}
	
	// Update is called once per frame
	void Update () {
	
		counter += Time.deltaTime;
		if (counter >= shootRatio) {
			Instantiate (shoot, transform.position, transform.rotation);
			counter = 0;
		}


	}
}

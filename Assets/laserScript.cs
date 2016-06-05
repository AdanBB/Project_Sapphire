using UnityEngine;
using System.Collections;

public class laserScript : MonoBehaviour {
	public Transform startPoint;
	public Transform endPoint;

	public Transform trail;

	LineRenderer laserLine;

	private float counter;

	public Transform head;

	private float ratioShoot;
	public Shoot shoot;
	private float delay;


	public ParticleSystemRay systemRay;

	// Use this for initialization
	void Start () {
		laserLine = GetComponentInChildren<LineRenderer> ();
		laserLine.SetWidth (1f, 1f);
		ratioShoot = shoot.shootRatio;
		trail.position = startPoint.position;
		delay = 0.5f;
	}
	
	// Update is called once per frame
	void Update () {
		laserLine.SetPosition (0, startPoint.position);

		counter += Time.deltaTime;

		if (counter >= (ratioShoot - delay) && Vector3.Distance (startPoint.position, trail.position) <= 20) {
			
			trail.Translate (0, 0, 1000* Time.deltaTime);
			systemRay.setActive ();
		}
		if (counter >= ratioShoot) {

			trail.position = startPoint.position;
			counter = 0;
			systemRay.setDesactive ();
		
		}
			
		laserLine.SetPosition (1, trail.position);








	}
}

using UnityEngine;
using System.Collections;

public class laserScript : MonoBehaviour {
	public Transform startPoint;
	public Transform endPoint;

	public Transform trail;

	LineRenderer laserLine;

	private float counter;

	public Transform head;

	public RaycastHit[] hits;

	// Use this for initialization
	void Start () {
		laserLine = GetComponentInChildren<LineRenderer> ();
		laserLine.SetWidth (1f, 1f);

		trail.position = startPoint.position;
	}
	
	// Update is called once per frame
	void Update () {
		laserLine.SetPosition (0, startPoint.position);

		counter += Time.deltaTime;

		if (counter >= 1.7f && Vector3.Distance (startPoint.position, trail.position) <= 20) {
			trail.Translate (0, 0, 1000* Time.deltaTime);
		}
		if (counter >= 2.5f) {
		
			trail.position = startPoint.position;
			counter = 0;
		
		}
			
		laserLine.SetPosition (1, trail.position);








	}
}

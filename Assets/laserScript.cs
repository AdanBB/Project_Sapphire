using UnityEngine;
using System.Collections;

public class laserScript : MonoBehaviour {
	public Transform startPoint;
	public Transform endPoint;
	LineRenderer laserLine;



	public Transform head;

	public RaycastHit[] hits;

	// Use this for initialization
	void Start () {
		laserLine = GetComponentInChildren<LineRenderer> ();
		laserLine.SetWidth (0f, 0f);

	}
	
	// Update is called once per frame
	void Update () {
		laserLine.SetPosition (0, startPoint.position);
		laserLine.SetPosition (1, endPoint.position);








	}
}

using UnityEngine;
using System.Collections;

public class followplayer : MonoBehaviour {

	public Transform player;
	// Use this for initialization
	void Awake () {

		gameObject.transform.position = new Vector3 (player.transform.position.x, player.transform.position.y , gameObject.transform.position.z);
	
	}
	
	// Update is called once per frame
	void Update () {

		gameObject.transform.position = new Vector3 (player.transform.position.x, player.transform.position.y, gameObject.transform.position.z);

	}
}

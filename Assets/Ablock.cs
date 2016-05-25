using UnityEngine;
using System.Collections;

public class Ablock : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter( Collider other){
	
	
		if (other.tag == "Enemy") {
		

			if (this.gameObject.name == "A") {
				other.GetComponent<EnemyAi2> ().GotoPosition (2);
			}

			if (this.gameObject.name == "B") {

				other.GetComponent<EnemyAi2> ().GotoPosition (1);

			}

		}

	}



}

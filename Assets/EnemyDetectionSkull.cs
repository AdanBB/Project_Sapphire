using UnityEngine;
using System.Collections;

public class EnemyDetectionSkull : MonoBehaviour {

	public EnemyAI3 enemyAi3;

	void OnTriggerEnter(Collider other)
	{




	}
	void OnTriggerStay(Collider other)
	{
		if (other.tag == "Player") {
			enemyAi3.FollowPlayer ();
			Debug.Log ("dsad");
		}



	}
	void OnTriggerExit(Collider other)
	{

	}
}

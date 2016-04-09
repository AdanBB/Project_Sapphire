using UnityEngine;
using System.Collections;

public class EnemyDetection : MonoBehaviour {

    public EnemyAi2 enemyAi2;

	void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
            Debug.Log("Player Entrando");


    }
    void OnTriggerStay(Collider other)
    {
		if (other.tag == "Player") {
			Debug.Log ("Player Entrando");
			enemyAi2.FollowPlayer ();
		}
            


    }
    void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
            Debug.Log("Player saliendo");
    }
}

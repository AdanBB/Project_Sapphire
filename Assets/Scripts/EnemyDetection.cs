using UnityEngine;
using System.Collections;

public class EnemyDetection : MonoBehaviour {

    public EnemyAi2 enemyAi2;

	void OnTriggerEnter(Collider other)
    {
        
            


    }
    void OnTriggerStay(Collider other)
    {
		if (other.tag == "Player") {
			enemyAi2.FollowPlayer ();
		}
            


    }
    void OnTriggerExit(Collider other)
    {
		if (other.tag == "Player") {
			enemyAi2.GotoPosition (1);
		}
    }
}

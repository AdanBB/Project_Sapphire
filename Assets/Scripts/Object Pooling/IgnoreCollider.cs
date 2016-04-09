using UnityEngine;
using System.Collections;

public class IgnoreCollider : MonoBehaviour {

	// Use this for initialization
    public Transform myCollider;
	void Awake () {
        Transform bullet = Instantiate(myCollider) as Transform;

        Physics.IgnoreCollision(bullet.GetComponent<Collider>(), GetComponent<Collider>());
	}
	
}

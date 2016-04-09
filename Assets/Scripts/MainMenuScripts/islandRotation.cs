using UnityEngine;
using System.Collections;

public class islandRotation : MonoBehaviour {

    public float speed;
    private float counter;

    void Start()
    {
        counter = transform.localRotation.y;

    }
	void FixedUpdate () {

        counter++;

        transform.localRotation = Quaternion.Euler(275.97f, counter*Time.deltaTime*speed, transform.localRotation.z);
	
	}
}

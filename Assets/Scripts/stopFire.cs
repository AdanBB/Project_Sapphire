using UnityEngine;
using System.Collections;

public class stopFire : MonoBehaviour {

    private ParticleSystem myParticles;

    private float count;

	// Use this for initialization
	void Start () {

        myParticles = gameObject.GetComponent<ParticleSystem>();
        count = 0;
	}
	
	// Update is called once per frame
	void Update () {

        count++;

        if (count >= 200)
        {
            myParticles.Stop();
        }
	
	}
}

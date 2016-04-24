using UnityEngine;
using System.Collections;

public class ParticleDestroyer : MonoBehaviour {

    private ParticleSystem footSteps;

	// Use this for initialization
	void Awake () {

        footSteps = gameObject.GetComponent<ParticleSystem>();
	
	}
	
	// Update is called once per frame
	void Update () {

        if (footSteps.IsAlive() == false)
        {
            Destroy(gameObject);
        }
	
	}
}

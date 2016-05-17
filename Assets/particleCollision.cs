using UnityEngine;
using System.Collections;

public class particleCollision : MonoBehaviour {

	public GameObject splash;

	private float counter;
	private float limit;

	void Start()
	{
		counter = 0f;
		limit = 0.5f;
	}

	void Update()
	{
		counter += Time.deltaTime;
	}

	void OnParticleCollision(GameObject other)
	{
		if (counter > limit) {
			ParticleSystem ps = GetComponent<ParticleSystem> ();
			ParticleSystem.Particle[] particleList = new ParticleSystem.Particle[ps.particleCount];
			ps.GetParticles (particleList);
			ParticleCollisionEvent[] collisions = new ParticleCollisionEvent[ps.GetSafeCollisionEventSize ()];
			int noOfCollisions = ps.GetCollisionEvents (other, collisions);

			Debug.Log (noOfCollisions);

			Debug.Log ("Particle Collision");

			for (int i = 0; i < noOfCollisions; i++) {
				Debug.Log ("Recorriendo Particle Collision");
				Instantiate (splash, collisions [i].intersection, Quaternion.Euler (90, 0, 0));
			}
			 
			counter = 0;
		}
	}
}

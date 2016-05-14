using UnityEngine;
using System.Collections;

public class particleCollision : MonoBehaviour {

	public GameObject splash;

	private float counter;
	private float limit;

	void Start()
	{
		counter = 0f;
		limit = 1f;
	}

	void Update()
	{
		counter += Time.deltaTime;
	}

	void OnParticleCollision(GameObject other)
	{
		ParticleSystem ps = other.GetComponent<ParticleSystem>();
		ParticleSystem.Particle[] particleList = new ParticleSystem.Particle[ps.particleCount];
		ps.GetParticles (particleList);
		ParticleCollisionEvent[] collisions = new ParticleCollisionEvent[ps.GetSafeCollisionEventSize()];
		int noOfCollisions = ps.GetCollisionEvents (other, collisions);

		for(int i = 0; i < noOfCollisions; i++)
		{
			Instantiate (splash, collisions[i].intersection, Quaternion.Euler (90, 0, 0));
		}
	}
		
	/*void OnCollisionStay(Collision collision)
	{
		if (counter > limit) 
		{
			foreach (ContactPoint contact in collision.contacts) 
			{
				Instantiate (splash, new Vector3 (contact.point.x, contact.point.y + 0.2f, contact.point.z), Quaternion.Euler (90, 0, 0));
			}
			counter = 0;
		}
	}*/
}

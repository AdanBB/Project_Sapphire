using UnityEngine;

public class particleCollision : MonoBehaviour {

	public GameObject splash;

	private float counter;
	private float limit;

	void Start()
	{
		counter = 0f;
		limit = 0.1f;
	}

	void Update()
	{
		counter += Time.deltaTime;
	}

	void OnParticleCollision(GameObject other)
	{
		if (counter > limit && (other.tag != "Player")) 
		{
			
			ParticleSystem ps = GetComponent<ParticleSystem> ();
			ParticleSystem.Particle[] particleList = new ParticleSystem.Particle[ps.particleCount];
			ps.GetParticles (particleList);
			ParticleCollisionEvent[] collisions = new ParticleCollisionEvent[ps.GetSafeCollisionEventSize ()];
			int noOfCollisions = ps.GetCollisionEvents (other, collisions);

            Instantiate(splash, new Vector3(collisions[0].intersection.x, collisions[0].intersection.y + 0.01f, collisions[0].intersection.z), Quaternion.Euler(90, Random.Range(0,360), 0));

            counter = 0;
		}
	}
}

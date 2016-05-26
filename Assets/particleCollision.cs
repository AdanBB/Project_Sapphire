using UnityEngine;

public class particleCollision : MonoBehaviour {

	public GameObject splashColor1;
    public GameObject splashColor2;

    public GameObject colorManager;

    private Color color1;
    private Color color2;
    private GameObject instantiateObject;

	private float counter;
	private float limit;
    private int privateColor;

	public int damage;
    void Awake()
    {

        colorManager = GameObject.FindGameObjectWithTag("ColorManager");
        color1 = colorManager.GetComponent<ColorManager>().colors[0];
        color2 = colorManager.GetComponent<ColorManager>().colors[1];

    }

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
        if (counter > limit && (other.tag == "Floor"))
        {

            ParticleSystem ps = GetComponent<ParticleSystem>();
            ParticleSystem.Particle[] particleList = new ParticleSystem.Particle[ps.particleCount];
            ps.GetParticles(particleList);
            ParticleCollisionEvent[] collisions = new ParticleCollisionEvent[ps.GetSafeCollisionEventSize()];
            int noOfCollisions = ps.GetCollisionEvents(other, collisions);

            Instantiate(instantiateObject, new Vector3(collisions[0].intersection.x, collisions[0].intersection.y + 0.01f, collisions[0].intersection.z), Quaternion.Euler(90, Random.Range(0,360), 0));

            for (int i = 0; i < collisions.Length; i++)
            {
                Instantiate(instantiateObject, new Vector3(collisions[i].intersection.x, collisions[i].intersection.y + 0.01f, collisions[i].intersection.z), Quaternion.Euler(90, Random.Range(0, 360), 0));
            }

            counter = 0;
        }

        if (counter > limit && (other.tag == "Platform"))
        {
            if (privateColor == 0)
            {
                foreach (Renderer childRenderer in other.transform.GetChild(1).GetComponentsInChildren<Renderer>())
                {
                    childRenderer.material.color = Color.blue;
                }
            }
            if (privateColor == 1)
            {
                foreach (Renderer childRenderer in other.transform.GetChild(1).GetComponentsInChildren<Renderer>())
                {
                    childRenderer.material.color = Color.green;
                }
            }
        }
		if (counter > limit && (other.tag == "Enemy")) {

			other.GetComponent<EnemyAi2> ().AdDamage (damage, 0 );


		}
		if (counter > limit && (other.tag == "EnemySkull")) {

			other.GetComponent<EnemyAI3> ().AdDamage (damage, 0 );


		}
		if (counter > limit && (other.tag == "Boss")) {

			Debug.Log ("dsadsa");

			other.GetComponent<EnemyAiBoos> ().AdDamage (damage);


		}
		if ((other.tag == "Boss2")) {

			Debug.Log ("dsadsa");

			other.GetComponent<EnemyAiBos2> ().AdDamage (damage);


		}
    }

    public void ParticleColor(int color)
    {
        if (color == 0)
        {
            privateColor = 0;

            GetComponent<ParticleSystem>().startColor = color1;

            foreach (ParticleSystem ps in GetComponentsInChildren<ParticleSystem>())
            {
                ps.startColor = color1;
            }
            instantiateObject = splashColor1;
        }
        if (color == 1)
        {
            privateColor = 1;

            GetComponent<ParticleSystem>().startColor = color2;

            foreach (ParticleSystem ps in GetComponentsInChildren<ParticleSystem>())
            {
                ps.startColor = color2;
            }
            instantiateObject = splashColor2;
        }
    }
}

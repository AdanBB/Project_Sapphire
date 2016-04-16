using UnityEngine;
using System.Collections;

public class EnemyAi2 : MonoBehaviour {
	
	public int health;
	private int _health;

	private bool lastHit;
	private float lastHitCounter;

	public Color normal;
	public Color blue;
	public Color green;
	private GameObject treeBody;

	private int random;
    private GameObject player;
	private NavMeshAgent agent;

	public int damage;
	private float counter;
	private float counter2;
	private bool attack;

	public  float range;
	public float detectionRange;
	public float distanceAttack;
	private SphereCollider detectionCollider;
	// Use this for initialization
    void Awake () {

        player = GameObject.FindGameObjectWithTag("Player");
		agent = GetComponent<NavMeshAgent> ();
		random = Random.Range (1, 3);
		detectionCollider = GetComponentInChildren<SphereCollider> ();
		treeBody = transform.GetChild (2).gameObject;

    }

	void Start () {
		_health = health;
		attack = false;
		counter2 = 1.5f;
		counter = counter2;
		detectionCollider.radius = detectionRange;
	}
	
	// Update is called once per frame
	void Update () {
		if (attack) {

			counter -= Time.deltaTime;
			if (counter <= 0) {
			
				attack = false;
				counter = counter2;
			}

		}
		if (lastHit) {

			lastHitCounter += Time.deltaTime;
			if (lastHitCounter >= 3) {
				treeBody.GetComponent<Renderer> ().material.color = normal;
				health = _health;
				lastHitCounter = 0;
				lastHit = !lastHit;
				random = Random.Range (1, 3);

			}

		}
	}


    public void FollowPlayer()
    {
		if (!lastHit) {
			Debug.Log ("now");
			transform.LookAt(new Vector3 (player.transform.position.x, transform.position.y , player.transform.position.z));
			agent.SetDestination (player.transform.position);
		
		
		}

		range = Vector3.Distance (this.transform.position, player.transform.position);

		if ((range <= distanceAttack)&&(!attack) && (!lastHit)) {
		
			Attack ();
		
		}

    }
	public void AdDamage(int Damage, int color){

		if ((!lastHit) && (health >= 10)) {
		
			Debug.Log ("tocado");
			Debug.Log (Damage);
			health = health - Damage;
		
		}

		if ((health <= 10) && (!lastHit)) {

			if (random == 1) {
			
				treeBody.GetComponent<Renderer> ().material.color = green;
			}
			if (random == 2) {

				treeBody.GetComponent<Renderer> ().material.color = blue;
			}
				
			lastHit = !lastHit;


		}else if (lastHit ) {
		
			if (random == color) {
			
				Destroy (this.gameObject);
			
			}

		
		}
	}
	public void Attack(){


		Debug.Log ("te atacoo");
		player.GetComponent<CharacterStats> ().ApplyDamage ((float)damage);
		attack = true;
	
	}
}

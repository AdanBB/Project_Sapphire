using UnityEngine;
using System.Collections;

public class EnemyAI3 : MonoBehaviour {

	public int health;
	private int _health;

	public float damage;
	private SphereCollider detectionCollider;
	public float detectionRange;

	public float velocity;

	public GameObject deathParticles;
	public GameObject explosionParticles;

	private GameObject player;
	private float range;
	private float _ramge;

	private Animator anim;
	private NavMeshAgent agent;

	public AudioClip enemyAttack;
	public AudioClip lastHitSound;
	private AudioSource enemySound;


	void Awake(){


		player = GameObject.FindGameObjectWithTag("Player");
		agent = GetComponent<NavMeshAgent> ();
		detectionCollider = GetComponentInChildren<SphereCollider> ();
		anim = GetComponent<Animator> ();
		enemySound = GetComponent<AudioSource> ();

	}

	// Use this for initialization
	void Start () {
		detectionCollider.radius = detectionRange;

		range = agent.stoppingDistance;
	}
		
	// Update is called once per frame
	void Update () {

		//Debug.Log(Vector2.Distance (transform.position,player.transform.position ));
		Debug.Log(Vector3.Distance (player.transform.position,transform.position ));
	
	}
	public void FollowPlayer()
	{

		transform.LookAt(new Vector3 (player.transform.position.x, transform.position.y , player.transform.position.z));
		agent.SetDestination (player.transform.position);
		anim.SetBool ("IsMoving", true);
		//Debug.Log (agent.stoppingDistance);

		if (Vector3.Distance (transform.position, player.transform.position) < detectionCollider.radius /1.4) {

			if (agent.baseOffset > 0.29) {
				agent.baseOffset -= Time.deltaTime * 2.2f;
			}
		}

		if (Vector3.Distance (transform.position, player.transform.position) < range) {
		
			//Debug.Log(Vector2.Distance (player.transform.position, this.transform.position));
			player.GetComponent<CharacterStats> ().ApplyDamage (damage);
			Destroy (gameObject);
		
		}

	}


	public void AdDamage(int Damage, int color){


		health = health - Damage;


	}
	public void DamagePlayer(){

		player.GetComponent<CharacterStats> ().ApplyDamage ((float)damage);
		enemySound.PlayOneShot (enemyAttack);

	}

}

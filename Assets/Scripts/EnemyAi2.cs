﻿using UnityEngine;
using System.Collections;

public class EnemyAi2 : MonoBehaviour {
	
	public int health;
	private int _health;

	private bool lastHit;
	private float lastHitCounter;
	public float velocity;


	public Color normal;

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

	private bool isAttacking;
	private int AttackNum;
	private float counterAnim;
	private float _counterAnim;

	public GameObject[] deathParticles;

	public ColorManager colorManager;
	private Animator anim;

	public AudioClip enemyAttack;
	public AudioClip lastHitSound;
	private AudioSource enemySound;

	public Transform pointA;
	public Transform pointB;


	// Use this for initialization
    void Awake () {

        player = GameObject.FindGameObjectWithTag("Player");
		agent = GetComponent<NavMeshAgent> ();
		random = Random.Range (1, 3);
		detectionCollider = GetComponentInChildren<SphereCollider> ();
		treeBody = transform.GetChild (2).gameObject;
		anim = GetComponent<Animator> ();
		enemySound = GetComponent<AudioSource> ();

		colorManager = GameObject.FindGameObjectWithTag ("ColorManager").GetComponent<ColorManager> ();
    }

	void Start () {
		_health = health;
		attack = false;
		counter2 = 1.2f;
		counter = counter2;
		detectionCollider.radius = detectionRange;

		isAttacking = false;
		agent.SetDestination (pointA.position);
		anim.SetBool ("IsMoving", true );
	}
	
	// Update is called once per frame
	void Update () {

		if (isAttacking) {

			_counterAnim += Time.deltaTime;

			if (_counterAnim >= counterAnim) {
			
				anim.SetBool ("IsAttack", false);
				isAttacking = false;
				_counterAnim = 0;
			}
		}

		if (attack) {

			counter -= Time.deltaTime;
			if (counter <= 0) {
			
				attack = false;
				counter = counter2;
			}
		}
		if (lastHit) {

			anim.SetBool ("IsLastHit", true);
			lastHitCounter += Time.deltaTime;
			if (lastHitCounter >= 3)
            {
				treeBody.GetComponent<Renderer> ().materials[1].color = normal;
				health = _health;
				lastHitCounter = 0;
				lastHit = !lastHit;
				random = Random.Range (1, 3);
			}

		}
        else anim.SetBool ("IsLastHit", false);

		velocity = agent.velocity.magnitude;
		if (Vector3.Distance (agent.destination, this.transform.position) <= 1.40f) {
		
			anim.SetBool ("IsMoving", false);
		}
	}
	public void GotoPosition(int where){
	
	
		if (where == 1) {
		
			agent.SetDestination (pointA.position);
		
		}
		if (where == 2) {

			agent.SetDestination (pointB.position);

		}
	}

    public void FollowPlayer()
    {
		if (!lastHit) {
	
			transform.LookAt(new Vector3 (player.transform.position.x, transform.position.y , player.transform.position.z));
			agent.SetDestination (player.transform.position);
			anim.SetBool ("IsMoving", true);
		}


		range = Vector3.Distance (this.transform.position, player.transform.position);

		if ((range <= distanceAttack) && (!attack) && (!lastHit)&&(!isAttacking)) {
		
			Attack ();

		}
		if (range >= distanceAttack){
			CancelInvoke ("DamagePlayer");

		}

    }
	public void AdDamage(int Damage, int color){

		if ((health >= 0)) {

			health = health - Damage;
		}

		if ((health <= 10) && (!lastHit)) {

			if (colorManager.colorsUnlock.Count == 0) {

				treeBody.GetComponent<Renderer> ().materials [1].color = normal;

			}

			if (colorManager.colorsUnlock.Count == 1) {

				treeBody.GetComponent<Renderer> ().materials [1].color = colorManager.colors [0];

			}
			if (colorManager.colorsUnlock.Count == 2) {
				if (random == 1) {

					treeBody.GetComponent<Renderer> ().materials[1].color = colorManager.colorsUnlock [0];
				}
				if (random == 2) {

					treeBody.GetComponent<Renderer> ().materials[1].color = colorManager.colorsUnlock [1];
				}

			}

			lastHit = !lastHit;

		}
        else if (lastHit ) {
			
			/*if (colorManager.colorsUnlock.Count == 0) {

				Instantiate (deathParticles[2], new Vector3 (transform.position.x,transform.position.y + 1, transform.position.z), transform.rotation);
				Destroy (this.gameObject);
			}

			if (colorManager.colorsUnlock.Count == 1) {

				if (random == 2)*/
					Instantiate (deathParticles[0], new Vector3 (transform.position.x,transform.position.y + 1, transform.position.z), transform.rotation);
				/*if (random == 1)
					Instantiate (deathParticles[0], new Vector3 (transform.position.x,transform.position.y + 1, transform.position.z), transform.rotation);
				Destroy (this.gameObject);

			}

			if (random == random) {
			
				if (random == 2)
					Instantiate (deathParticles[1], new Vector3 (transform.position.x,transform.position.y + 1, transform.position.z), transform.rotation);
				if (random == 1)
					Instantiate (deathParticles[0], new Vector3 (transform.position.x,transform.position.y + 1, transform.position.z), transform.rotation);*/
				Destroy (this.gameObject);
			
			//}

		}
	}
	public void Attack(){

		Invoke ("DamagePlayer", 0.5f);

		attack = true;
		AttackNum = (int)Random.Range (1, 4);
		anim.SetInteger ("Attack", AttackNum);
		anim.SetBool ("IsAttack", true);
		isAttacking = true;
		counterAnim = 1.3f;

	}
	public void DamagePlayer(){
	
		player.GetComponent<CharacterStats> ().ApplyDamage ((float)damage);
		enemySound.PlayOneShot (enemyAttack);

	}
}

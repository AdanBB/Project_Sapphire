using UnityEngine;
using System.Collections;

public class EnemyAiBoos : MonoBehaviour {

	public int health;
	private int _health;

	public EnemyAiBos2 enemyAi2;

	public GameObject particles;


	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void AdDamage(int Damage){

		health -= Damage;

		if (health <= 0) {
			
			particles.SetActive (true);
			enemyAi2.active = true;
			Destroy (this.gameObject);

		}

	}
}

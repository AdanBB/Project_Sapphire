using UnityEngine;
using System.Collections;

public class EnemyAiBoos : MonoBehaviour {

	public int health;
	private int _health;


	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void AdDamage(int Damage){

		Debug.Log (health);
		health = health - Damage;

		if (health <= 0) {

			Destroy (this.gameObject);

		}

	}
}

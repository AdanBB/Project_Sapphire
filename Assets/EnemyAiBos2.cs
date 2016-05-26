using UnityEngine;
using System.Collections;

public class EnemyAiBos2 : MonoBehaviour {

	public int health;
	private int _health;
	public GameObject particles;
	public GameObject hoguera;
	public bool active;
	// Use this for initialization
	void Start () {
		active = false;
	}

	public void AdDamage(int Damage){
		if (active) {
			health -= Damage;

		}
		if (health <= 0) {
			particles.SetActive (true);

			hoguera.SetActive (true);

			Destroy (this.gameObject);

		}
	}
	public void SetLife(){
	
		Debug.Log ("dsadsa");

		active = true;
	
	}
}

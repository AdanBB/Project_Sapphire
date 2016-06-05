using UnityEngine;
using System.Collections;

public class EnemyAiBos2 : MonoBehaviour {

	public int health;
	private int _health;
	public GameObject particles;
	public GameObject hoguera;
	public bool active;
	private bool damaged;
	private float countedDamaged;
	private float timeDamaged;

	public Color damagedTexture;
	public Color NornalTexture;
	public Renderer rend;


	// Use this for initialization
	void Start () {
		active = false;
		damaged = false;
		countedDamaged = 0;
		timeDamaged = 0.5f;
	
	}
	void Update(){
	
		if (damaged) {
		
			countedDamaged += Time.deltaTime;
			Debug.Log ("dsa");
		
		}
		if(countedDamaged >= timeDamaged){

			rend.material.color = NornalTexture;
			Debug.Log("lel");
			damaged = false;
		}
	
	
	}

	public void AdDamage(int Damage){
		if (active) {
			health -= Damage;
			countedDamaged = timeDamaged;
			rend.material.color = damagedTexture;
				
			damaged = true;

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

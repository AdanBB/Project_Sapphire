using UnityEngine;
using System.Collections;

public class EnemyAi2 : MonoBehaviour {

	public int health;


	public bool lastHit;

	public Material rend;
	public Color blue;
	public Color green;
	public int random;
    private GameObject player;
	private NavMeshAgent agent;

	// Use this for initialization
    void Awake () {

        player = GameObject.FindGameObjectWithTag("Player");
		agent = GetComponent<NavMeshAgent> ();
		random = Random.Range (1, 3);

    }

	void Start () {

        

	}
	
	// Update is called once per frame
	void Update () {
	
	}


    public void FollowPlayer()
    {
		Debug.Log ("now");
		transform.LookAt(new Vector3 (player.transform.position.x, transform.position.y , player.transform.position.z));
		agent.SetDestination (player.transform.position);

    }
	public void AdDamage(int Damage, int color){
	
	


		if ((!lastHit) && (health >= 10)) {
		
			Debug.Log ("tocado");
			Debug.Log (Damage);
			health = health - Damage;
		
		}

		if ((health <= 10) && (!lastHit)) {


			lastHit = !lastHit;


		}if (lastHit) {
		
			if (random == color) {
			
				Destroy (this.gameObject);
			
			}
		
		}


	


	}
}

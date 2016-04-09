using UnityEngine;
using System.Collections;

public class EnemyAi2 : MonoBehaviour {

	public int health;


    private GameObject player;
	private NavMeshAgent agent;

	// Use this for initialization
    void Awake () {

        player = GameObject.FindGameObjectWithTag("Player");
		agent = GetComponent<NavMeshAgent> ();

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
	public void AdDamage(int Damage){
	
	
		health -= Damage;

		if (health <= 0) {


			Destroy (this.gameObject);
		}
	


	}
}

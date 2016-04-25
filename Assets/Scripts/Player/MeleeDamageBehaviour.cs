using UnityEngine;
using System.Collections;

public class MeleeDamageBehaviour : MonoBehaviour {
    public float damage;
    public int weaponColor;
    public PlayerAI playerAI;

	public bool hit;
	private float counter;
    public Animator myAnimator;

    void Awake()
    {
		hit = true;
    }
    // Use this for initialization
    void Start () {
        weaponColor = playerAI.weaponColor;   

    }
	
	// Update is called once per frame
	void Update () {
        weaponColor = playerAI.weaponColor;

		if (!hit) {
		
			counter += Time.deltaTime;
			if (counter >= 1) {
			
				hit = true;
				counter = 0;
			
			}
		
		}

    }
    
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            
            if (myAnimator.GetBool("IsAttacking"))
            {
                /*if (!other.gameObject.GetComponent<EnemyAI>().lastStantBool)
                {
					other.gameObject.GetComponent<EnemyAi2> ().AdDamage (10);

                    Debug.Log("hace daño al enemigo");
                }
                else if (other.gameObject.GetComponent<EnemyAI>().lastStantBool && other.gameObject.GetComponent<EnemyAI>().lastStatStatus == weaponColor)
                {
					other.gameObject.GetComponent<EnemyAi2> ().AdDamage (10);
                }*/
				if (other.gameObject.GetComponent<EnemyAi2> () && hit) {
					
					other.gameObject.GetComponent<EnemyAi2> ().AdDamage ((int)damage, weaponColor);



					hit = false;
				}

            }
        }
    }
    /*
    void OnTriggerStay(Collider other)
    { 
        if (other.gameObject.tag == "Enemy")
        {
            Debug.Log("detecta al enemigo");
            if (myAnimator.GetBool("IsAttacking"))
            {
                if (!other.gameObject.GetComponent<EnemyAI>().lastStantBool)
                {
                    other.gameObject.SendMessage("ApplyDamage", damage);

                    Debug.Log("hace daño al enemigo");
                }
                else if (other.gameObject.GetComponent<EnemyAI>().lastStantBool && other.gameObject.GetComponent<EnemyAI>().lastStatStatus == weaponColor)
                {
                    other.gameObject.SendMessage("ApplyDamage", damage);
                }
            }
        }

        }*/
}

using UnityEngine;
using System.Collections;

public class MeleeDamageBehaviour : MonoBehaviour {
    public float damage;
    public int weaponColor;
    public PlayerAI playerAI;

    public Animator myAnimator;

    void Awake()
    {
    }
    // Use this for initialization
    void Start () {
        weaponColor = playerAI.weaponColor;        
    }
	
	// Update is called once per frame
	void Update () {
        weaponColor = playerAI.weaponColor;

    }
    
    void OnTriggerEnter(Collider other)
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

using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class EnemyStats : MonoBehaviour {
    public float maxHealth;
    public float health;


    Animator myAnimator;
    void Awake()
    {
        myAnimator = GetComponent<Animator>();
    }
	// Use this for initialization
	void Start () {
        health = maxHealth;

	}
	
	// Update is called once per frame
	void Update () {
        

    }
    public void ApplyDamage(float damage)
    {
        if (health > 0)
        {
            myAnimator.SetBool("IsDamaged", true);
            health -= damage;
        }
        if (health <= 0)
        {
            gameObject.SetActive(false);
        }
    }
}

using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class EnemyStats : MonoBehaviour {
    public float maxHealth;
    public float health;
    public Slider healthUI;
    Animator myAnimator;
    void Awake()
    {
        myAnimator = GetComponent<Animator>();
    }
	// Use this for initialization
	void Start () {
        health = maxHealth;
        healthUI.value = maxHealth;

	}
	
	// Update is called once per frame
	void Update () {
        healthUI.value = health;

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

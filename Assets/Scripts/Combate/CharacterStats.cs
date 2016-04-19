using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class CharacterStats : MonoBehaviour
{
    public float maxHealth;
    public float currentHealth;
    Animator myAnimator;
    // Use this for initialization
    void Awake()
    {
        myAnimator = GetComponent<Animator>();
        currentHealth = maxHealth;
    }
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    public void ApplyDamage(float damage)
    {
        if (currentHealth > 0)
        {
            //myAnimator.SetBool("IsDamaged", true);
            currentHealth -= damage;
        }
        if (currentHealth <= 0)
        {

            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
        
    }
    

}


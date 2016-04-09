using UnityEngine;
using System.Collections;

public class EnemyHealth : MonoBehaviour
{
    public float maxHealth = 100;
    public float curHealth = 100;

    public float healthBarLength;
    EnemyStats health;
    // Use this for initialization
    void Start()
    {
        health = GetComponent<EnemyStats>();
        healthBarLength = Screen.width / 6;
    }

    // Update is called once per frame
    void Update()
    {
        AddjustCurrentHealth(0);
        curHealth = health.health;
    }

    void OnGUI()
    {

        Vector2 targetPos;
        targetPos = Camera.main.WorldToScreenPoint(transform.position);

        GUI.Box(new Rect(targetPos.x, Screen.height - targetPos.y, 60, 20), curHealth + "/" + maxHealth);

    }

    public void AddjustCurrentHealth(int adj)
    {
        curHealth += adj;

        if (curHealth < 0)
            curHealth = 0;

        if (curHealth > maxHealth)
            curHealth = maxHealth;

        if (maxHealth < 1)
            maxHealth = 1;

        healthBarLength = (Screen.width / 6) * (curHealth / (float)maxHealth);
    }

}

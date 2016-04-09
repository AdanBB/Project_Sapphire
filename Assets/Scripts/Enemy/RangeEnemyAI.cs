using UnityEngine;
using System.Collections;

public class RangeEnemyAI : MonoBehaviour {

    public enum GameStates { MOVETOTARGET, STAY, ATTACK, LASTSTANT }
    public GameStates state;
    public Transform target;
    public float speed;
    public float attack1Range;
    public float detectionRange;
    public int atackCountdown;
    public Color sphera;
    public int lastStantCountdown;

    public Color lastStantColor;
    public Color enemyColor;
    public Renderer myRenderer;
    public CharacterStats stats;
    public bool lastStantBool;


    public GameObject bulletPrefab;

    void Awake()
    {
        stats = GetComponent<CharacterStats>();
        myRenderer = GetComponent<Renderer>();
    }
    // Use this for initialization
    void Start()
    {
        lastStantBool = false;
        atackCountdown = 120;
        state = GameStates.STAY;
        lastStantCountdown = 0;
    }
    // Update is called once per frame
    void Update()
    {

        switch (state)
        {
            
            case GameStates.MOVETOTARGET:
                MoveToPlayer();
                if (Vector3.Distance(transform.position, target.position) <= attack1Range) state = GameStates.ATTACK;
                if (Vector3.Distance(transform.position, target.position) > detectionRange) state = GameStates.STAY;
                if (stats.currentHealth <= 10) state = GameStates.LASTSTANT;
                break;
            case GameStates.STAY:
                Rest();
                if (Vector3.Distance(transform.position, target.position) < detectionRange) state = GameStates.MOVETOTARGET;
                if (stats.currentHealth <= 10) state = GameStates.LASTSTANT;
                break;
            case GameStates.ATTACK:
                Attack();
                if (Vector3.Distance(transform.position, target.position) > attack1Range) state = GameStates.MOVETOTARGET;
                if (stats.currentHealth <= 10) state = GameStates.LASTSTANT;
                break;
            case GameStates.LASTSTANT:
                LastStant();

                break;
        }
    }


    public void MoveToPlayer()
    {
        lastStantCountdown = 0;
        myRenderer.material.color = enemyColor;
        //rotate to look at player
        transform.LookAt(target.position);
        transform.Rotate(new Vector3(0, -90, 0), Space.Self);

        //move towards player
        if (Vector3.Distance(transform.position, target.position) > attack1Range)
        {
            transform.Translate(new Vector3(speed * Time.deltaTime, 0, 0));
        }
    }

    public void Rest()
    {
        lastStantCountdown = 0;
        myRenderer.material.color = enemyColor;
    }
    public void Attack()
    {
        transform.LookAt(target.position);
        lastStantCountdown = 0;
        myRenderer.material.color = enemyColor;
        atackCountdown--;
        if (atackCountdown <= 0)
        {
            GameObject bullet = Instantiate(bulletPrefab,transform.position,transform.rotation) as GameObject;
            atackCountdown = 120;
        }
    }
    public void LastStant()
    {
        lastStantBool = true;
        myRenderer.material.color = lastStantColor;
        lastStantCountdown++;

        if (lastStantCountdown == 500)
        {
            lastStantBool = false;
            stats.currentHealth = 50;
            state = GameStates.ATTACK;
        }
        //logica de si el player de hace daño para quitar

    }
    void OnDrawGizmosSelected()
    {

        Gizmos.color = sphera;
        Gizmos.DrawSphere(transform.position, detectionRange);

    }
}
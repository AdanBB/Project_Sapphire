using UnityEngine;
using System.Collections;

public class EnemyAI : MonoBehaviour
{
    public enum GameStates { MOVETOTARGET, STAY,ATTACK,LASTSTANT }
    public GameStates state;
    public bool rangeEnemy;
    public Transform target;
    public float speed;
    public float attack1Range;
    public float detectionRange;
    public int damage;
    public float rotationSpeed;
    public CharacterStats player;
    public int atackCountdown;
    public Color sphera;
    public int lastStantCountdown;

    public Color firstLastStantColor;
    public Color SecontLastStantColor;
    public Color enemyColor;
    public Renderer myRenderer;
    public EnemyStats stats;
    public bool lastStantBool;
    public bool playerInvulnerable;
    public playerController characterController;

    public GameObject bulletPrefab;
    public int lastStatStatus;
    public Animator playerAnimator;
    Animator myAnimator;
    void Awake()
    {
        myAnimator = GetComponent<Animator>();
        stats = GetComponent<EnemyStats>();
    }
    // Use this for initialization
    void Start ()
	{
        lastStatStatus = 0;
        lastStantBool = false;
        atackCountdown = 120;
        state = GameStates.STAY;
        lastStantCountdown = 0;
	}
	// Update is called once per frame
	void Update ()
	{
        switch (state)
        {
            case GameStates.MOVETOTARGET:
                MoveToPlayer();
                if (Vector3.Distance(transform.position, target.position) <= attack1Range) state = GameStates.ATTACK;
                if (Vector3.Distance(transform.position, target.position) > detectionRange) state = GameStates.STAY;
                if (stats.health <= 10) state = GameStates.LASTSTANT;
                break;
            case GameStates.STAY:
                Rest();
                if (Vector3.Distance(transform.position, target.position) < detectionRange) state = GameStates.MOVETOTARGET;
                if (stats.health <= 10) state = GameStates.LASTSTANT;
                break;
            case GameStates.ATTACK:
                Attack();
                if (Vector3.Distance(transform.position, target.position) > attack1Range) state = GameStates.MOVETOTARGET;
                
                if (stats.health <= 10)
                {
                    lastStatStatus = Random.Range(1, 3);
                    state = GameStates.LASTSTANT;
                }
                    break;
            case GameStates.LASTSTANT:
                LastStant();

                break;
        }
    }


    public void MoveToPlayer ()
	{
        myAnimator.SetBool("IsAttacking", false);
        Debug.DrawLine(target.position, transform.position, Color.red);
        lastStantCountdown = 0;
        myRenderer.material.color = enemyColor;
        //rotate to look at player
        transform.LookAt(target.position);
        transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(target.position - transform.position), rotationSpeed * Time.deltaTime);

        //move towards player
        if (Vector3.Distance (transform.position, target.position) > attack1Range) 
		{
            myAnimator.SetBool("IsMoving", true);
            transform.position += transform.forward * speed * Time.deltaTime * 2;
        }
        else
        {
            myAnimator.SetBool("IsMoving", false);
        }
        
    }

	public void Rest ()
	{
        lastStantCountdown = 0;
        myRenderer.material.color = enemyColor;
    }
    public void Attack()
    {
        myAnimator.SetBool("IsMoving", false);
        transform.LookAt(target.position);
        lastStantCountdown = 0;
        myRenderer.material.color = enemyColor;
        atackCountdown--;
        playerInvulnerable = characterController.isInvulnerable;
        if (atackCountdown <= 0 && playerInvulnerable == false && rangeEnemy == true)
        {
            myAnimator.SetBool("IsAttacking", true);
            GameObject bullet = Instantiate(bulletPrefab, transform.position, transform.rotation) as GameObject; 
            atackCountdown = 120;
            
        }
        else if(atackCountdown <= 0 && playerInvulnerable == false && rangeEnemy == false)
        {
            myAnimator.SetBool("IsAttacking", true);
            target.gameObject.SendMessage("ApplyDamage", damage);
            //player.currentHealth -= damage;
            atackCountdown = 120;
        }
    }
    public void LastStant()
    {
        lastStantBool = true;
        
        lastStantCountdown++;
        
        if (lastStatStatus == 1)
        {
            myRenderer.material.color = firstLastStantColor;
        }
        else
        {
            myRenderer.material.color = SecontLastStantColor;
        }

        if (lastStantCountdown == 500)
        {
            lastStantBool = false;
            stats.health = 50;
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

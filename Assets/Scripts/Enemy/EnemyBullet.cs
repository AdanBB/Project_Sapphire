using UnityEngine;
using System.Collections;

public class EnemyBullet : MonoBehaviour
{
    public float speed;
    public Transform playerTransform;

    public int damage;
    Animator playerAnimator;
    // Use this for initialization
    void Start()
    {
        playerTransform = GameObject.Find("Player").GetComponent<Transform>();
        playerAnimator= GameObject.Find("Player").GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.forward * Time.deltaTime * speed);

    }
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            other.gameObject.SendMessage("ApplyDamage", damage);
        }
        
        Destroy(this.gameObject);
    }

}
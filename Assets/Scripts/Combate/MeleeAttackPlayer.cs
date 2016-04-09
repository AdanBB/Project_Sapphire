using UnityEngine;
using System.Collections;

public class MeleeAttackPlayer : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame

     float range = 5f;
     float attackInterval = 0.7f;
     float meleeDamage= 30f;
     float nextAttack= 0f;
 
     public void MeleeAttack()
        {
            if (Time.time > nextAttack)
            { // only repeat attack after attackInterval
                nextAttack = Time.time + attackInterval;
                // get all colliders whose bounds touch the sphere
                Collider[] colls = Physics.OverlapSphere(transform.position, range);
                foreach (Collider hit in colls)
                {
                    if (hit && hit.tag == "Enemy")
                    { // if the object is an enemy...
                      // check the actual distance to the melee center
                        float dist = Vector3.Distance(hit.transform.position, transform.position);
                        if (dist <= range)
                        { // if inside the range...
                          // apply damage to the hit object
                            hit.SendMessage("ApplyDamage", meleeDamage);
                        }
                    }
                }
            }
        }

    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            MeleeAttack();
        }
    }
}

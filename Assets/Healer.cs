using UnityEngine;
using System.Collections;

public class Healer : MonoBehaviour {

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            other.GetComponent<CharacterStats>().currentHealth += other.GetComponent<CharacterStats>().maxHealth / 4;
            Destroy(gameObject);
        }
    }
}

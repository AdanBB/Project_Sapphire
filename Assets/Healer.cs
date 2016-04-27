using UnityEngine;
using System.Collections;

public class Healer : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player" && Input.GetKey(KeyCode.E))
        {
            other.GetComponent<CharacterStats>().currentHealth += other.GetComponent<CharacterStats>().maxHealth / 25;
        }
    }
}

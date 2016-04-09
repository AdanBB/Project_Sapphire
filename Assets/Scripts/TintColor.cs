using UnityEngine;
using System.Collections;

public class TintColor : MonoBehaviour {
    public GameObject bullet;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

        if (Input.GetKey(KeyCode.P))
        {
            bullet.GetComponent<Renderer>().sharedMaterial.color = new Color( 255, 255, 255);
        }

    }
    void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Player") && Input.GetKey(KeyCode.E))
        {
            bullet.GetComponent<Renderer>().sharedMaterial.color = this.GetComponent<Renderer>().sharedMaterial.color;
        }
    }
}

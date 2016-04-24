using UnityEngine;
using System.Collections;

public class TintColor : MonoBehaviour {
    public GameObject bullet;

	public AudioClip getColor;
	// Use this for initialization
	void Start () {
	
	}

    void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Player") && Input.GetKey(KeyCode.E))
        {
            bullet.GetComponent<Renderer>().sharedMaterial.color = this.GetComponent<Renderer>().sharedMaterial.GetColor("_Color");

			Invoke ("colorSet", 0.1f);
        }
    }

	void colorSet(){
	
		gameObject.GetComponent<AudioSource> ().PlayOneShot (getColor);
	
	}
}

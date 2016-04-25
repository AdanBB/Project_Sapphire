using UnityEngine;
using System.Collections;

public class TintColor : MonoBehaviour {
    public GameObject bullet;

	public AudioClip getColor;

	public int idColor;
	public ColorManager colorManager;

	public bool isInside;
	// Use this for initialization
	void Start () {
	
		isInside = false;
	}
	void Update(){
	
		if (isInside && Input.GetKeyDown (KeyCode.E)) {
		
			//Invoke ("colorSet", 0.1f);
			gameObject.GetComponent<AudioSource> ().PlayOneShot (getColor);
			colorManager.adColor (idColor);
		

		}
	
	}
    void OnTriggerEnter(Collider other)
    {
		if (other.tag == ("Player") )
        {

			isInside = true;

            //bullet.GetComponent<Renderer>().sharedMaterial.color = this.GetComponent<Renderer>().sharedMaterial.GetColor("_Color");


        }
    }
	void OnTriggerExit(Collider other)
	{
		if (other.tag == ("Player") )
		{
			isInside = false;

			//bullet.GetComponent<Renderer>().sharedMaterial.color = this.GetComponent<Renderer>().sharedMaterial.GetColor("_Color");


		}
	}

	void colorSet(){
	

		gameObject.GetComponent<AudioSource> ().PlayOneShot (getColor);
	}
}

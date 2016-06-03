using UnityEngine;
using System.Collections;

public class TintColor : MonoBehaviour {
    public GameObject bullet;

	public AudioClip getColor;

	public int idColor;
	public ColorManager colorManager;

    internal PlayerAI player;

	public bool isInside;

    void Awake()
    {
        player = GameObject.Find("PlayerAim").GetComponent<PlayerAI>();

    }
	// Use this for initialization
	void Start () {
	
		isInside = false;
	}
	void Update(){
	
		if (isInside && Input.GetKey(KeyCode.E))
        {
			if (!colorManager.boolsColors[idColor]) {

                player.paintCharges += 10f;

                gameObject.GetComponent<AudioSource> ().PlayOneShot (getColor);
				colorManager.adColor (idColor);
			}

            if (player.paintCharges <= 10)
            {
                player.paintCharges += Time.deltaTime * 2;
            }
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

	void colorSet()
    {
		gameObject.GetComponent<AudioSource> ().PlayOneShot (getColor);
	}
}

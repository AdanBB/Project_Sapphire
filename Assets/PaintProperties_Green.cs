using UnityEngine;
using System.Collections.Generic;

public class PaintProperties_Green : MonoBehaviour {

	public float newSpeed;
    public float delay;

    public List<Texture> splashImages;

    private playerController playerCon;
	private GameObject parent;

    private bool activeDelay;
    private float counter;

	void Awake()
	{
        counter = 0;
        activeDelay = false;

        int randomImage = Random.Range(0, splashImages.Count);
        GetComponent<Renderer>().material.SetTexture("_MainTex", splashImages[randomImage]);

        playerCon = GameObject.Find ("Direction").GetComponent<playerController> ();
		parent = GameObject.Find ("SplashParent");
		gameObject.transform.parent = parent.transform;
	}

    void Update()
    {
        if (activeDelay == true)
        {
            counter += Time.deltaTime;

            if (counter > delay)
            {
                playerCon._speed = playerCon.privateSpeed;
                activeDelay = false;
                counter = 0;
            }
            if ((counter > 1) && (playerCon.isJumping == false))
            {
                playerCon._speed = playerCon.privateSpeed;
                activeDelay = false;
                counter = 0;
            }
        }
    }

	void OnTriggerEnter(Collider other)
	{
		if (other.tag == "Player") 
		{
            playerCon._speed = newSpeed;
		}
	}

    void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player")
        {
            playerCon._speed = newSpeed;
        }
    }

    void OnTriggerExit(Collider other)
	{
        activeDelay = true;
	}
}
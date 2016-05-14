using UnityEngine;
using System.Collections;

public class SplashInstantiate : MonoBehaviour {

	public GameObject greenSplash;
	public GameObject blueSplash;

	public GameObject blueStream;
	public GameObject greenStream;

	public GameObject player;


	private int actualColor;
	private int listSize;

	private ColorManager cm;

	private ParticleSystem bluepsStream;
	private ParticleSystem greenpsStream;


	private ParticleSystem paintStream;
	private Vector3 spawnPosition;

	private float spawnCounter;
	public float spawnLimiter;

	private ColorManager colormanager;

	void Awake()
	{
		cm = GameObject.Find ("ColorManager").GetComponent<ColorManager> ();
		listSize = player.GetComponent<ColorWeapon> ().size;
		actualColor = player.GetComponent<ColorWeapon> ().color;
		paintStream = GetComponent<ParticleSystem> ();
		bluepsStream = blueStream.GetComponent<ParticleSystem> ();
		greenpsStream = greenStream.GetComponent<ParticleSystem> ();
	}
	// Use this for initialization
	void Start () 
	{
		spawnCounter = 0;
	}
	
	// Update is called once per frame
	void Update () {

		if(listSize > 0)
		{
			Debug.Log ("");
			if (actualColor == 0)
			{
				Debug.Log ("Color Blue");
				bluepsStream.Play ();
				greenpsStream.Pause ();
			}

			if (actualColor == 1)
			{
				Debug.Log ("Color Green");
				greenpsStream.Play ();
				bluepsStream.Pause ();
			}
		}

		spawnCounter += Time.deltaTime;

		if (spawnCounter > spawnLimiter) 
		{
			if (GetComponent<ParticleSystem> ().subEmitters.collision0.IsAlive ()) {

				if (player.GetComponent<ColorWeapon>().color == 1)
				{
					Debug.Log ("Color Blue");
					Instantiate (blueSplash, GetComponent<ParticleSystem> ().subEmitters.collision0.transform.position, blueSplash.transform.rotation);
				}
				if (player.GetComponent<ColorWeapon>().color == 2)
				{
					Debug.Log ("Color Green");
					Instantiate (greenSplash, GetComponent<ParticleSystem> ().subEmitters.collision0.transform.position, blueSplash.transform.rotation);
				} 
			}

			spawnCounter = 0;
		}
	}
}


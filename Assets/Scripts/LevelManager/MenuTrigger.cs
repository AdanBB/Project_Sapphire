using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuTrigger : MonoBehaviour {

	public string scene;
	public Image black;
	public Image level;
	private float count;
	private bool faderActive;
	private bool endActive;

	void Awake()
	{
		faderActive = false;
		endActive = false;
	}

	void Update()
	{
		if (faderActive == true)
		{
			EndFade(level);
		}
		if (endActive == true) 
		{
			EndFade(black);
		}
	}
	void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.tag == "Player") {
			
			faderActive = true;

			if (Input.GetKey (KeyCode.E)) 
			{
				endActive = true;
			}
		}
	}

	void OnTriggerExit(Collider other)
	{
		if (other.gameObject.tag == "Player") {
			faderActive = false;
			StartFade (level);
		}
	}

	public void EndFade(Image toFade)
	{
		count = count + (1f/120f);
		toFade.color = new Color(toFade.color.r, toFade.color.g, toFade.color.b, count);

		if (toFade.color.a >= 0.95f)
		{
			SceneManager.LoadScene(scene);
		}
	}

	public void StartFade(Image toFade)
	{
		count = count + (1f/120f);
		toFade.color = new Color(toFade.color.r, toFade.color.g, toFade.color.b, count);

		if (toFade.color.a >= 0.95f)
		{
			SceneManager.LoadScene(scene);
		}
	}
}

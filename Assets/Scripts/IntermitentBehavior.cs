using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class IntermitentBehavior : MonoBehaviour {

	private bool fadeIn;
	private bool fadeOut;
	public Image image;

	// Use this for initialization
	void Start () {

		fadeOut = true;
		fadeIn = false;
	}
	
	// Update is called once per frame
	void Update () {

		if (fadeOut == true) 
		{
			FadeOut (image);
		}
		if (fadeIn == true) 
		{
			FadeIn (image);
		}
	}

	public void FadeIn(Image toFade)
	{
		toFade.color = new Color (toFade.color.r, toFade.color.g, toFade.color.b, toFade.color.a + 0.01f);

		if (toFade.color.a > 1) 
		{
			fadeIn = false;
			fadeOut = true;
		}
	}

	public void FadeOut(Image toFade)
	{
		toFade.color = new Color (toFade.color.r, toFade.color.g, toFade.color.b, toFade.color.a - 0.01f);

		if (toFade.color.a < 0) 
		{
			fadeIn = true;
			fadeOut = false;
		}
	}
}

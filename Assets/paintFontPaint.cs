using UnityEngine;
using System.Collections;

public class paintFontPaint : MonoBehaviour {

    public GameObject font;

	private Renderer myRenderer;
	private FontBehavior fontBehavior;
	private ParticleSystem myps;
	private Light myLight;

	void Awake()
	{
		myRenderer = gameObject.GetComponent<Renderer> ();
		fontBehavior = transform.parent.GetComponent<FontBehavior>();
		myps = GetComponent<ParticleSystem> ();
		myLight = gameObject.GetComponent<Light> ();
	}

	// Use this for initialization
	void Start () {

		if (myRenderer != null)
        {
			myRenderer.material.color = fontBehavior._fontColor;
        }
		if (myps != null)
        {
			myps.startColor = fontBehavior._fontColor;
        }
		if (myLight != null)
        {
			myLight.color = fontBehavior._fontColor;
        }
    }
}

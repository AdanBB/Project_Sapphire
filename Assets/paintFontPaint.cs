using UnityEngine;
using System.Collections;

public class paintFontPaint : MonoBehaviour {

    public GameObject font;

	// Use this for initialization
	void Start () {

        if (gameObject.GetComponent<Renderer>() != null)
        {
            if (font.GetComponent<TintColor>().idColor == 1)
            {
                gameObject.GetComponent<Renderer>().material.color = Color.green;
            }

            if (font.GetComponent<TintColor>().idColor == 0)
            {
                gameObject.GetComponent<Renderer>().material.color = Color.blue;
            }
        }
        if (GetComponent<ParticleSystem>() != null)
        {
            if (font.GetComponent<TintColor>().idColor == 1)
            {
                gameObject.GetComponent<ParticleSystem>().startColor = Color.green;
            }

            if (font.GetComponent<TintColor>().idColor == 0)
            {
                gameObject.GetComponent<ParticleSystem>().startColor = Color.blue;
            }
        }
        if (GetComponent<Light>() != null)
        {
            if (font.GetComponent<TintColor>().idColor == 1)
            {
                gameObject.GetComponent<Light>().color = Color.green;
            }

            if (font.GetComponent<TintColor>().idColor == 0)
            {
                gameObject.GetComponent<Light>().color = Color.blue;
            }
        }
    }
	
	// Update is called once per frame
	void Update () {
	
	}
}

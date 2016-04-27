using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuTrigger : MonoBehaviour {

	public string scene;
	public Image black;
	public Image level;
    public Image fondo;
	private float count;
	private float endcount;
	private bool faderActive;
	private bool endActive;
	private bool dissapear;

	void Awake()
	{
		faderActive = false;
		endActive = false;
		dissapear = false;
	}

	void Update()
	{
		if (faderActive == true)
		{
			EndFade(level, fondo);
		}
		if (endActive == true) 
		{
			NextScene(black);
		}
		if (dissapear == true) {
			
			StartFade (level, fondo);
		}
	}
	void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.tag == "Player") {

			dissapear = false;
			faderActive = true;
		}
	}

	void OnTriggerStay(Collider other)
	{
		if (other.gameObject.tag == "Player") {

			if (Input.GetKey (KeyCode.E) && black != null) 
			{
				endActive = true;
			}
		}
	}

	void OnTriggerExit(Collider other)
	{
		if (other.gameObject.tag == "Player") {
			faderActive = false;
			dissapear = true;
		}
	}

    public void EndFade(Image toFade, Image fondo)
    {
        if (count < 1)
        {
            count = count + (1f / 100f);
            toFade.color = new Color(toFade.color.r, toFade.color.g, toFade.color.b, count);

            if (count < 0.75f)
            {
                fondo.color = new Color(fondo.color.r, fondo.color.g, fondo.color.b, count);
            }
        }
    }

	public void NextScene(Image toFade)
	{
		endcount = endcount + (1f/100f);
		toFade.color = new Color(toFade.color.r, toFade.color.g, toFade.color.b, endcount);

		if (toFade.color.a > 0.95f)
		{
			SceneManager.LoadScene(scene);
		}
	}

	public void StartFade(Image toFade, Image fondo)
	{
        if (count > 0)
        {
            count = count - (1f / 100f);
            toFade.color = new Color(toFade.color.r, toFade.color.g, toFade.color.b, count);
            fondo.color = new Color(fondo.color.r, fondo.color.g, fondo.color.b, count);
        }
		
		
	}
}

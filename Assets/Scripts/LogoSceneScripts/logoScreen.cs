using UnityEngine;
using System.Collections;
using UnityEngine.UI;
//using UnityEngine.SceneManagement;

public class logoScreen : MonoBehaviour {

    int counter;
    public Image fader;
    private float endcount;
    public string scene;

    // Use this for initialization
    void Start () {

        counter = 180;
    }
	
	// Update is called once per frame
	void Update () {

        counter--;

        if (counter <= 0)
        {
            NextScene(fader);
        }
    }

    public void NextScene(Image toFade)
    {
        endcount = endcount + (1f / 100f);
        toFade.color = new Color(toFade.color.r, toFade.color.g, toFade.color.b, endcount);

        if (toFade.color.a > 0.99f)
        {
            LevelManager.NextScene("Menu");
        }
    }
}

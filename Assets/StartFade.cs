using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class StartFade : MonoBehaviour {

    public Image fader;
    private float endcount;

    void Awake()
    {
        endcount = 1;
    }
    // Use this for initialization
    void Start () {
	
	}

    void Update()
    {
        NextScene(fader);
    }

    public void NextScene(Image toFade)
    {
        endcount -= (1f / 100f);
        toFade.color = new Color(toFade.color.r, toFade.color.g, toFade.color.b, endcount);
    }
}

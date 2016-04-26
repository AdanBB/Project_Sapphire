using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class StartFade : MonoBehaviour {

    public Image fader;
    private float endcount;

    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

        endcount = endcount - (1f / 80f);
        fader.color = new Color(fader.color.r, fader.color.g, fader.color.b, endcount);

    }
}

using UnityEngine;
using System.Collections;

public class Foto : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
		if(Input.GetKeyDown(KeyCode.F)){


		
			Application.CaptureScreenshot("Screenshot.png",5000);

		}
	}
}

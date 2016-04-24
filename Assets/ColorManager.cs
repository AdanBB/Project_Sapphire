using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ColorManager : MonoBehaviour {
	
	public List<Color> colors;
	public List<Color> colorsUnlock;

	public bool[] boolsColors;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void adColor(int idColor){
	
		if (idColor == 0 && !boolsColors[0]) {
		
		
			colorsUnlock.Add (colors [0]);
			boolsColors [0] = !boolsColors [0];

		
		}
		if (idColor == 1) {


			colorsUnlock.Add (colors [1]);


		}
	
	}
}

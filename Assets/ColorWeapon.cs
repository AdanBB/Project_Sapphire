using UnityEngine;
using System.Collections;

public class ColorWeapon : MonoBehaviour {

	public ColorManager colorManager;

	public static int currentColor;

	public int size;
	// Use this for initialization
	void Start () {
	
		size = colorManager.colorsUnlock.Count;

	}
	
	// Update is called once per frame
	void Update () {
	

		if (size != colorManager.colorsUnlock.Count) {

			size = colorManager.colorsUnlock.Count;
		}

		if (size >= 1) {
		

			if (Input.GetAxis ("Mouse ScrollWheel") != 0f) {
			
				var d = Input.GetAxis ("Mouse ScrollWheel");

				if (d > 0f) {
				
					if (currentColor < colorManager.colorsUnlock.Count - 1) {
						
						currentColor++;
					}
				} else if (d < 0f) {
					if (currentColor > 0) {
						
						currentColor--;
					}
				}

			
			}

		
		
		}






	}
}

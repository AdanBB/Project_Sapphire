using UnityEngine;
using System.Collections;

public class PauseMenu : MonoBehaviour {

	private bool pause;

	public GameObject myCanvas;

	void FixedUpdate()
	{
		Pause ();

		if (Input.GetKeyDown ("space")) 
		{
			pause = true;
			myCanvas.SetActive (true);
		}
	}

	public void ContinueButton()
	{
		pause = false;

		myCanvas.SetActive (false);
	}
	public void MenuButton()
	{
		LevelManager.NextScene("Menu");
	}
	public void RestartButton()
	{
		LevelManager.RestartScene();
	}

	public void Pause()
	{
		if (pause == true) 
		{
			Time.timeScale = 0;
		} 
		if (pause == false) 
		{
			Time.timeScale = 1;
		}
	}
}
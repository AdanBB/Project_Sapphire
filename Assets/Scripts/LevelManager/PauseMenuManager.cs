using UnityEngine;

public class PauseMenuManager : MonoBehaviour {

    public GameObject pauseMenu;
    public PlayerAI playerAI;
    public GameObject player;

	private bool isPaused;

	// Use this for initialization
	void Start () {
	
		isPaused = true;
	}
	
	// Update is called once per frame
	void Update () {

        if (Input.GetKeyDown(KeyCode.Escape))
        {
			if (!isPaused) {
				
				SetPause ();


			} else if (isPaused) {

				SetGame ();

			}
  
        }
		if (Input.GetKeyDown(KeyCode.N))
		{
			if (isPaused) {
				SetGame ();
				if (Application.loadedLevel == 5) {
				
					Application.LoadLevel (8);

				}
				if (Application.loadedLevel == 7) {

					Application.LoadLevel (4);

				}

			} 

		}
		if (Input.GetKeyDown(KeyCode.M))
		{
			if (isPaused) {
				SetGame ();
				Application.LoadLevel (6);



			} 

		}
		if (Input.GetKeyDown(KeyCode.E))
		{
			if (isPaused) {
				SetGame ();

				Application.Quit();


			} 

		}
	}
    public void ResumeBotton()
    {

		SetGame ();

    }
    public void MainMenuBotton()
    {
      
        Time.timeScale = 1;
		Debug.Log ("dsadsa");
        LevelManager.NextScene("menuScreen");
		player.SetActive(true);
		playerAI.enabled = true;
		pauseMenu.SetActive(false);
    }
    public void ExitGameBotton()
    {
        Application.Quit();
    }
	void SetPause(){

		isPaused = true;
		Time.timeScale = 0;
		//pauseMenu.SetActive (true);

	}
	void SetGame(){

		isPaused = false;
		//pauseMenu.SetActive (false);
		Time.timeScale = 1;
	}
}

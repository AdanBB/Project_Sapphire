using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenuManager : MonoBehaviour {

    public PlayerAI playerAI;
    public GameObject player;

    public string nextLevel;
    public string menuLevel;

	private bool isPaused;

	// Use this for initialization
	void Start () {
	
		isPaused = false;
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
    			SceneManager.LoadScene(nextLevel);
			}

		}
		if (Input.GetKeyDown(KeyCode.M))
		{
			if (isPaused) {
				SetGame ();
                SceneManager.LoadScene(menuLevel);
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
        LevelManager.NextScene("menuScreen");
		player.SetActive(true);
		playerAI.enabled = true;
    }
    public void ExitGameBotton()
    {
        Application.Quit();
    }
	void SetPause(){

		isPaused = true;
		Time.timeScale = 0;
	}
	void SetGame(){

		isPaused = false;
		Time.timeScale = 1;
	}
}

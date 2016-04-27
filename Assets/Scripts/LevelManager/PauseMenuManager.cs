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
				
				isPaused = !isPaused;
				pauseMenu.SetActive (false);
			
			} else if (isPaused) {
				
				isPaused = !isPaused;

				pauseMenu.SetActive(true);
			
			
			}


            
            
            
        }
	}
    public void ResumeBotton()
    {
        
        Time.timeScale = 1;
		pauseMenu.SetActive(false);
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
}

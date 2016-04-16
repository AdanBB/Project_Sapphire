using UnityEngine;

public class PauseMenuManager : MonoBehaviour {

    public GameObject pauseMenu;
    public PlayerAI playerAI;
    public GameObject player;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            
            Time.timeScale = 0;
            
            pauseMenu.SetActive(true);
            
        }
	}
    public void ResumeBotton()
    {
       
        pauseMenu.SetActive(false);
        Time.timeScale = 1;
    }
    public void MainMenuBotton()
    {
        player.SetActive(true);
        playerAI.enabled = true;
        pauseMenu.SetActive(false);
        Time.timeScale = 1;
        LevelManager.NextScene("menuScreen");
    }
    public void ExitGameBotton()
    {
        Application.Quit();
    }
}

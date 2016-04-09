using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public static class LevelManager
{
	//Next Scene by Scene Name
	public static void NextScene(string nextScene)
	{
			SceneManager.LoadScene(nextScene);
	}
		
	//Next Scene by Build Scene Number
	public static void NumberScene(int nextScene)
	{
		SceneManager.LoadScene (nextScene);
	}

	//Next Scene by Build Scene Settings
	public static void BUildScene()
	{
		SceneManager.LoadScene (SceneManager.GetActiveScene ().buildIndex + 1);
	}

	//Restart Scene Method
	public static void RestartScene()
	{
			SceneManager.LoadScene (SceneManager.GetActiveScene ().buildIndex);
	}
}
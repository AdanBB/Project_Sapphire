using UnityEngine;
using System.Collections;
//using UnityEngine.SceneManagement;

public class buttonBehaviour : MonoBehaviour {

	public string playScene;
    public string prototypeScene;
    public Canvas menuCanvas;
    public Canvas optionsCanvas;

    public void PlayButton()
    {
		LevelManager.NextScene (playScene);
    }

    public void PrototypeButton()
    {
        LevelManager.NextScene(prototypeScene);
    }

    public void OptionsButton()
    {
        menuCanvas.enabled = false;
        optionsCanvas.enabled = true;
    }

    public void ExitButton()
    {

        Application.Quit();
    }

    public void FBButton()
    {
        Application.OpenURL("https://www.facebook.com/sneakyMonkeys/");
    }

    public void TWButton()
    {
        Application.OpenURL("https://twitter.com/SMonkeysStudio");
    }
}

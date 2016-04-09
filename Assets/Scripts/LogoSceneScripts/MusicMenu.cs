using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class MusicMenu : MonoBehaviour {

	// Use this for initialization
	void Start () {
        DontDestroyOnLoad(this.gameObject);
    }
	
	// Update is called once per frame
	void Update () {

        if (SceneManager.GetActiveScene() == SceneManager.GetSceneByName("Tutorial"))
        {
            Destroy(this.gameObject);
        }
        
	
	}
}

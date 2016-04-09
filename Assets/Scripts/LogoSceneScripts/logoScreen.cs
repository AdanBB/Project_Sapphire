using UnityEngine;
using System.Collections;
//using UnityEngine.SceneManagement;

public class logoScreen : MonoBehaviour {

    int counter;


    // Use this for initialization
    void Start () {

        counter = 180;
    }
	
	// Update is called once per frame
	void Update () {

        counter--;

        if (counter <= 0)
        {
			LevelManager.NextScene ("menuScreen");
            //SceneManager.LoadScene("menuScreen");
        }
    }
}

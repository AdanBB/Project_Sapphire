using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class TutorialMessage : MonoBehaviour {

    public Canvas myCanvas;

    private bool active;

    void Awake()
    {
        active = false;
    }
	// Use this for initialization
	void OnTriggerEnter (Collider other)
    {
        if (other.gameObject.tag == "Player")
            myCanvas.gameObject.SetActive(true);
    }

    // Update is called once per frame
    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            myCanvas.gameObject.SetActive(false);
            Destroy(this.gameObject);
        }
    }
}
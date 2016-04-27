using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class finalPoint : MonoBehaviour {

    public string scene;
    public Image fader;
    private float count;
    private bool faderActive;

    void Awake()
    {
        faderActive = false;
    }

    void Update()
    {
        if (faderActive == true)
        {
            EndFade();
        }
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            faderActive = true;
        }
    }

    public void EndFade()
    {
        count = count + (1f/100f);
        fader.color = new Color(fader.color.r, fader.color.g, fader.color.b, count);

        if (fader.color.a >= 0.98f)
        {
            SceneManager.LoadScene(scene);
        }
    }
}

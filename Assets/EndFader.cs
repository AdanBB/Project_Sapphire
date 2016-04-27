using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class EndFader : MonoBehaviour
{
    public float timeToFade;
    private float contador;
    public string scene;
    public Image fader;
    private float count;

    void Awake()
    {
        contador = 0;
    }

    void Update()
    {
        contador += Time.deltaTime;

        if (contador > timeToFade)
        {
            EndFade();
        }
    }

    public void EndFade()
    {
        count = count + (1f / 120f);
        fader.color = new Color(fader.color.r, fader.color.g, fader.color.b, count);

        if (fader.color.a >= 0.95f)
        {
            SceneManager.LoadScene(scene);
        }
    }
}

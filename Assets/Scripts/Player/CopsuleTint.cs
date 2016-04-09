using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class CopsuleTint : MonoBehaviour {
    public Renderer bulletRenderer;
    public PlayerAI playerAI;
    public Renderer weaponRederer;
    Image myImage;
	// Use this for initialization
	void Start () {
        myImage = GetComponent<Image>();
	}

    void Update()
    {
        if (playerAI.weaponTipe == 0)
        {
            myImage.color = bulletRenderer.sharedMaterial.color;
        }
        else
        {
            myImage.color = weaponRederer.material.color;
        }
        
    }
}

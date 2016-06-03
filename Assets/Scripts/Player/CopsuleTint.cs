using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class CopsuleTint : MonoBehaviour {
    public Renderer bulletRenderer;
    public PlayerAI playerAI;
    public Renderer weaponRederer;
    Image myImage;

	public ColorWeapon colorWeapon;
	public ColorManager colorManager;

    internal PlayerAI player;

    void Awake()
    {
        player = GameObject.Find("PlayerAim").GetComponent<PlayerAI>();
    }
	// Use this for initialization
	void Start () {
        myImage = GetComponent<Image>();
	}

    void Update()
    {
        transform.localScale = new Vector3(player.paintCharges/10, 1, 1);
        
		if (colorManager.colorsUnlock.Count > 0) {
		

			if (ColorWeapon.currentColor == 0) {

				myImage.color = colorManager.colorsUnlock [0]; 

			}
			else if (ColorWeapon.currentColor == 1) {

				myImage.color = colorManager.colorsUnlock [1];

			}
		}
    }
}

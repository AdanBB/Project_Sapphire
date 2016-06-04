using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class CopsuleTint : MonoBehaviour {
   
    private PlayerAI _playerAI;
    private Image _myImage;

    internal PlayerAI player;

    void Awake()
    {
		_playerAI = GameObject.Find("PlayerAim").GetComponent<PlayerAI>();
		_myImage = GetComponent<Image>();
    }

	void Start()
	{
		_myImage.color = new Color (255,255,255, 255);
	}

	void Update()
	{
		if (this.name == "Fill") 
		{
			transform.localScale = new Vector3 (_playerAI.paintCharges / 10, 0.60f , transform.localScale.z);
		}
	}

	public void ChangeColor(Color color)
	{
		_myImage.color = color;
	}
}

using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class HPPLAYERUI : MonoBehaviour {
    public CharacterStats hp;
    public Text text;
    public Slider hpSliderPlayer;
	// Use this for initialization
	void Start () {

        hpSliderPlayer.maxValue = hp.maxHealth;
        hpSliderPlayer.value = hp.maxHealth;
	}
	
	// Update is called once per frame
	void Update () {
        hpSliderPlayer.value = hp.currentHealth;
        //text.text = hp.currentHealth.ToString()+"/"+hp.maxHealth.ToString();
	}

}

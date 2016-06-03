using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class HPBOS : MonoBehaviour {

	public EnemyAiBoos hp1;
	public EnemyAiBos2 hp2;
	public Text text;
	public Slider hpSliderBos;
	// Use this for initialization
	void Start () {

		hpSliderBos.maxValue = hp1.health + hp2.health;
		hpSliderBos.value = hp1.health + hp2.health;
	}

	// Update is called once per frame
	void Update () {
		hpSliderBos.value = hp1.health + hp2.health;
		//text.text = hp.currentHealth.ToString()+"/"+hp.maxHealth.ToString();
	}
}

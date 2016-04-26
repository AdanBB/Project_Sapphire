using UnityEngine;
using System.Collections.Generic;

public class transitionSelection : MonoBehaviour {

    public List<GameObject> transitionList;
    private int selected;


	// Use this for initialization
	void Start () {

        selected = Random.Range(0, transitionList.Count);

        transitionList[selected].SetActive(true);	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}

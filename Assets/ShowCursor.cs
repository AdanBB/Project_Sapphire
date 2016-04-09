using UnityEngine;
using System.Collections;

public class ShowCursor : MonoBehaviour {

	// Use this for initialization
	void Start () {
        
    }
	
	// Update is called once per frame
	void Update () {

        if (this.gameObject.activeInHierarchy)
        {
            Cursor.visible = true;
        }

	}

    void OnDisable()
    {
        Cursor.visible = false;
    }
}

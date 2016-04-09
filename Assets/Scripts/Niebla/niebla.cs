using UnityEngine;
using System.Collections;

public class niebla : MonoBehaviour {

    float scrollspeed;
    float offset;

    // Update is called once per frame
    void Start() {
        scrollspeed = 2;
    }
	void FixedUpdate () {

        offset += ((Time.deltaTime * scrollspeed) / 150f);
        gameObject.GetComponent<Renderer>().material.SetTextureOffset("_MainTex", new Vector2(-offset, 0));

    }
}

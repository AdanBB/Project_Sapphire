using UnityEngine;
using System.Collections;

public class mousePosition : MonoBehaviour {

    float yp;
    public Vector3 mp;
    public Vector3 bulletDirection;
    public float screenHPercent;
    public float screenWPercent;

    void FixedUpdate()
    {
        mp = Input.mousePosition;

        screenHPercent = (mp.y / Screen.height) * 100;
        screenWPercent = (mp.x / Screen.width) * 100;

        bulletDirection.z = 1;
        bulletDirection.y = screenHPercent / 100;

    }
}

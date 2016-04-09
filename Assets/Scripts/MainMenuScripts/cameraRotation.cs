using UnityEngine;
using System.Collections;

public class cameraRotation : MonoBehaviour {

    public Transform centro;
    public float speed;

	void FixedUpdate () {

        transform.LookAt(centro);
        transform.Translate(Vector3.right * Time.deltaTime * speed);

    }
}

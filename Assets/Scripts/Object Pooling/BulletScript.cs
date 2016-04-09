using UnityEngine;
using System.Collections;

public class BulletScript : MonoBehaviour {

    public float speed;
    public GameObject player;

    void FixedUpdate()
    {
        
        transform.Translate(Vector3.forward * Time.deltaTime * speed);

    }
    private void OnDisable()
    {
        transform.position = player.transform.position;
    }
}


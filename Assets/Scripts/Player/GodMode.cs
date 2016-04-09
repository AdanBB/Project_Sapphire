using UnityEngine;
using System.Collections;

public class GodMode : MonoBehaviour {
    public bool isInvulnerable;
    //public playerController pc;
	// Use this for initialization
	void Start () {
        isInvulnerable = false;
	}
	
	// Update is called once per frame
	void FixedUpdate () {
       
		if (Input.GetKeyDown(KeyCode.G))
        {
            isInvulnerable = !isInvulnerable;
        }

        if (isInvulnerable)
        {
            GodCommands();
        }

	}

	public void GodCommands()
	{
		if (Input.GetKey(KeyCode.LeftShift)) {
			transform.position = new Vector3 (transform.position.x, transform.position.y - 1, transform.position.z);
		}
		if (Input.GetKey(KeyCode.Space)) {
			transform.position = new Vector3 (transform.position.x, transform.position.y + 1, transform.position.z);
		}
        if (Input.GetKey(KeyCode.W))
        {
            transform.position += Vector3.forward * Time.deltaTime * 75;
        }
        if (Input.GetKey(KeyCode.A))
        {
            transform.position += Vector3.left * Time.deltaTime * 75;
        }
        if (Input.GetKey(KeyCode.S))
        {
            transform.position += Vector3.back * Time.deltaTime * 75;
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.position += Vector3.right * Time.deltaTime * 75;
        }
    }
}

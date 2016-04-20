using UnityEngine;
using System.Collections;


public class BulletDestroy : MonoBehaviour {

	// Use this for initialization
    private void OnEnable()
    {
        Invoke("Destroy", 3f);
    }

    private void OnDisable()
    {

        CancelInvoke();
    }

    void OnTriggerEnter(Collider other)
    {
		if ((other.gameObject.tag != "Info") || (other.gameObject.tag != "Platform"))
        {
			Invoke("Destroy", 0.1f);
        }
    }

	void Destroy ()
    {
        gameObject.SetActive(false);
	}


}

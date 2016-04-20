using UnityEngine;
using System.Collections;

public class objectTint : MonoBehaviour {

    void OnTriggerEnter(Collider other)
    {
		if (other.gameObject.tag == "Bullet")
        {
            foreach (Renderer childRenderer in this.GetComponentsInChildren<Renderer>())
            {
                childRenderer.material.color = other.gameObject.GetComponent<Renderer>().sharedMaterial.color;
            }   
        }
    }
}

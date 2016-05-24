using UnityEngine;
using System.Collections;

public class splashDelete : MonoBehaviour {

    // Use this for initialization
    void OnTriggerExit(Collider other)
    {
        if (other.tag == "Splash")
        {
            Destroy(other.gameObject);
        }
    }
}

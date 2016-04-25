using UnityEngine;
using System.Collections;


public class BulletDestroy : MonoBehaviour {

	public GameObject bulletExplosion;

	private ParticleSystem bulleExplosionParticle;

	public Gradient gradientBlue;
	public Gradient gradientGreen;	
	void Awake(){
	
		bulleExplosionParticle = GetComponent<ParticleSystem> ();
	
	}

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
		if (other.tag != "Detection") {
		
			if ((other.gameObject.tag != "Info") || (other.gameObject.tag != "Platform"))
			{
				Debug.Log (other.tag);
				Invoke("Destroy", 0.05f);
			}
		
		}

    }

	void Destroy ()
    {
		var col = bulleExplosionParticle.colorOverLifetime;


		col.color = new ParticleSystem.MinMaxGradient (gradientBlue);


		Instantiate (bulletExplosion, transform.position, transform.rotation);
        gameObject.SetActive(false);
	}


}

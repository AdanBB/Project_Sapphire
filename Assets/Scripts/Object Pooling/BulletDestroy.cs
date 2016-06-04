using UnityEngine;
using System.Collections;


public class BulletDestroy : MonoBehaviour {

	public GameObject bulletExplosion;

	private ParticleSystem bulleExplosionParticle;

	public GameObject splashColor1;
	public GameObject splashColor2;

	private PlayerAI _player;
	private ColorController colorController;
	private GameObject instantiateObject;

	public int damage;

	private Color _thisColor;

	private int privateColor;

	void Awake()
	{
		colorController = GameObject.Find ("ColorManager").GetComponent<ColorController> ();
		_thisColor = GetComponent<Renderer> ().material.color;
		_player = GameObject.Find ("PlayerAim").GetComponent<PlayerAI> ();
	}

	// Use this for initialization
    private void OnEnable()
    {
        Invoke("Destroy", 3f);
		_thisColor = _player.selectedColor;
    }

    private void OnDisable()
    {
        CancelInvoke();
    }

    void OnTriggerEnter(Collider other)
    {
		if ((other.tag != "Detection") || (other.gameObject.tag != "Info") || (other.gameObject.tag == "Platform")) 
		{
			if (other.tag == "Boss") {
				other.GetComponent<EnemyAiBoos> ().AdDamage (damage);
			} else if (other.tag == "Enemy") {
				other.GetComponent<EnemyAi2> ().AdDamage (damage, 0);
			} else if (other.tag == "EnemySkull") {
				other.GetComponent<EnemyAI3> ().AdDamage (damage, 0);
			} else if (other.tag == "Floor") {

				for (int i = 0; i < colorController.colorList.Count; i++) 
				{
					if (_thisColor == colorController.colorList [i].color) {

						if (colorController.colorList [i].colorName == "Green") {
						
							RaycastHit hit;

							if (Physics.Raycast (transform.position, other.transform.position, out hit)) {
								//Instantiate (GameObject.Find("paintSplash_Green"), new Vector3(transform.position.x, hit.point.y + 0.01f, transform.position.z), Quaternion.Euler (90, Random.Range (0, 360), 0));
								Instantiate (GameObject.Find("paintSplash_Green"), new Vector3(transform.position.x, transform.position.y, transform.position.z), Quaternion.Euler (90, Random.Range (0, 360), 0));
							}
						}
						else if (colorController.colorList [i].colorName == "Blue") {

							RaycastHit hit;

							if (Physics.Raycast (transform.position, other.transform.position, out hit)) {
								//Instantiate (GameObject.Find("paintSplash_Blue"), new Vector3(transform.position.x, hit.point.y + 0.01f, transform.position.z), Quaternion.Euler (90, Random.Range (0, 360), 0));
								Instantiate (GameObject.Find("paintSplash_Blue"), new Vector3(transform.position.x, transform.position.y, transform.position.z), Quaternion.Euler (90, Random.Range (0, 360), 0));
							}
						}
					}
				}

				Invoke ("Destroy", 0.05f);
			}
		}
    }

	void Destroy ()
    {
		Instantiate (bulletExplosion, transform.position, transform.rotation);
        gameObject.SetActive(false);
	}
}

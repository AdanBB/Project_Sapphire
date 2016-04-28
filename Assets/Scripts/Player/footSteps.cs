using UnityEngine;
using System.Collections;

public class footSteps : MonoBehaviour
{

    public GameObject steps;
	public GameObject splash;
    private float _localCounter;
    private bool moving;
    public Color _stepColor;
	private Color _splashColor;
    private int child;
    private int _stepNumber;
	private GameObject instantiatedPrefab;
	private int random;

	private bool activeSteps;
	public Vector3 rotation;

    void Awake()
    {
    }

    // Use this for initialization
    void Start()
    {
        _localCounter = 0;

    }

    // Update is called once per frame
    void Update()
    {
    }

    void OnTriggerStay(Collider other)
	{
		moving = gameObject.GetComponent<playerController> ()._isMoving;

		if ((other.gameObject.tag == "Floor") && (moving == true) && (activeSteps == true)) {
			_localCounter++;
			if (_localCounter >= 14) {

				rotation = transform.parent.rotation.eulerAngles;
				Instantiate (steps, new Vector3 (gameObject.transform.position.x, gameObject.transform.position.y - 0.85f, gameObject.transform.position.z), Quaternion.Euler (rotation.x + 90, rotation.y, rotation.z));
				

				_localCounter = 0;
				_stepNumber += 1;
			}
			if (_stepNumber >= 4) {

				activeSteps = false;
			}
		}

		if ((other.tag == "Platform")) {

			activeSteps = true;
			_stepColor = other.gameObject.transform.GetChild (1).GetComponentInChildren<Renderer> ().material.color;
			steps.GetComponent<SpriteRenderer> ().color = _stepColor;
			_stepNumber = 0;
		}
	}

	void OnTriggerEnter(Collider other)
	{
		if ((other.gameObject.tag == "Floor") && (activeSteps == true)) {
			rotation = transform.parent.rotation.eulerAngles;
			splash.GetComponent<SpriteRenderer> ().color = _stepColor;
			//Instantiate (splash, new Vector3 (gameObject.transform.position.x, gameObject.transform.position.y - 0.85f, gameObject.transform.position.z), Quaternion.Euler (rotation.x + 90, rotation.y+ Random.Range(0,360), rotation.z));
			instantiatedPrefab = Instantiate(splash, new Vector3 (gameObject.transform.position.x, gameObject.transform.position.y - 0.85f, gameObject.transform.position.z), Quaternion.Euler (rotation.x + 90, rotation.y+ Random.Range(0,360), rotation.z)) as GameObject;
		}
	}
}
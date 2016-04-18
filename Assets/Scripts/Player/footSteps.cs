using UnityEngine;
using System.Collections;

public class footSteps : MonoBehaviour
{

    public GameObject steps;
    private float _localCounter;
    private bool moving;
    private Color _stepColor;
    private int child;
    private int _stepNumber;

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
        moving = gameObject.GetComponent<playerController>()._isMoving;

        if ((other.gameObject.tag == "Floor") && (moving == true) && (_stepNumber <= 4))
        {
            _localCounter++;
            if (_localCounter >= 14)
            {
                Instantiate(steps,
                            new Vector3(gameObject.transform.position.x, gameObject.transform.position.y - 0.85f, gameObject.transform.position.z),
                            Quaternion.Euler(transform.parent.transform.rotation.x + 90, transform.parent.transform.rotation.y, transform.parent.transform.rotation.z));

                _localCounter = 0;
                _stepNumber += 1;
            }
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if ((other.gameObject.tag == "Platform"))
        {
            _stepColor = other.gameObject.GetComponentInChildren<Renderer>().material.color;
            steps.GetComponent<SpriteRenderer>().color = _stepColor;
            _stepNumber = 0;
        }
    }
}
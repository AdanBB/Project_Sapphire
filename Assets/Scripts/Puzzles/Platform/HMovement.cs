using UnityEngine;
using System.Collections;

public class HMovement : MonoBehaviour {

    //public Transform positionA;
    //public Transform positionB;
    private Vector3 targetA;
    private Vector3 targetB;
    private Transform mytransform;

    public float maxDistance;
    public float speed;

    private int caseSwitch;
    private int timeCounter;

    void Awake()
    {
        mytransform = this.transform;
        targetA = mytransform.position + new Vector3(maxDistance, 0, 0);
        targetB = mytransform.position - new Vector3(maxDistance, 0, 0);
        timeCounter = 0;
        caseSwitch = 1;
    }

    void Start()
    {

    }
	// Update is called once per frame
	void Update () {

        switch (caseSwitch)
        {
            case 1:

                Debug.Log("Caso 1");

                timeCounter = 0;

                transform.position = Vector3.MoveTowards(transform.position, targetA, Time.deltaTime * speed);

                if (transform.position == targetA)
                {
                    caseSwitch = 2;
                    
                }
                break;
            case 2:

                Debug.Log("Caso 2");

                timeCounter++;

                if (timeCounter == 120)
                {
                    caseSwitch = 3;
                }
                break;
            case 3:

                Debug.Log("Caso 3");

                timeCounter = 0;

                transform.position = Vector3.MoveTowards(transform.position, targetB, Time.deltaTime * speed);

                if (transform.position == targetB)
                {
                    caseSwitch = 4;
                }
                break;
            case 4:

                Debug.Log("Caso 4");

                timeCounter++;

                if (timeCounter == 120)
                {
                    caseSwitch = 1;
                }
                break;
        }
    }


    
}

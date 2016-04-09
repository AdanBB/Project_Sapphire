using UnityEngine;
using System.Collections;

public class GenericMovement : MonoBehaviour {

    public Transform positionA;
    public Transform positionB;

    public float speed;

    private int caseSwitch;
    private int timeCounter;

    void Awake()
    {
        timeCounter = 0;
        caseSwitch = 1;
    }
	// Update is called once per frame
	void Update () {

        switch (caseSwitch)
        {
            case 1:

                Debug.Log("Caso 1");

                timeCounter = 0;

                transform.position = Vector3.MoveTowards(transform.position, positionA.position, Time.deltaTime * speed);

                if (transform.position == positionA.position)
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

                transform.position = Vector3.MoveTowards(transform.position, positionB.position, Time.deltaTime * speed);

                if (transform.position == positionB.position)
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

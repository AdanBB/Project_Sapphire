using UnityEngine;
using System.Collections;

public class PlatformMovemet : MonoBehaviour
{
    private Renderer myRenderer;

    public Transform parent;

    [Header("Colors")]

    public Color verticalColor;
    public Color hotizontalColor;

    [Header ("Horizontal")]
    public Transform targetHA;
    public Transform targetHB;

    public float maxHDistance;
    public float speedH;

    private int caseSwitchH;
    private int timeCounterH;

    [Header("Vertical")]

    private float targetVA;
    private float targetVB;

    public float maxVDistance;
    public float speedV;

    private int caseSwitchV;
    private int timeCounterV;

    private Transform myTransform;

    // Use this for initialization
    void Awake()
    {
        //General
        myRenderer = this.GetComponent<Renderer>();
        myTransform = parent.GetComponent<Transform>();

        //Horizontal Movement
		//targetHA = myTransform.position.z + maxHDistance;
		//targetHB = myTransform.position.z - maxHDistance;
        timeCounterH = 0;
        caseSwitchH = 1;

        //Vertical Movement
		targetVA = myTransform.position.y - maxVDistance;
		targetVB = myTransform.position.y + maxVDistance;
        timeCounterV = 0;
        caseSwitchV = 1;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        ColorDetection();
    }

    public void ColorDetection()
    {
        if (myRenderer.material.color == verticalColor)
        {
            VMovement();
        }
        if (myRenderer.material.color == hotizontalColor)
        {
            HMovement();
        }
    }

    public void HMovement()
    {
        switch (caseSwitchH)
        {
            case 1:

                timeCounterH = 0;

                myTransform.position = Vector3.MoveTowards(myTransform.position, targetHA.position, Time.deltaTime * speedH);

                if (myTransform.position.z == targetHA.position.z)
                {
                    caseSwitchH = 2;

                }
                break;
            case 2:

                timeCounterH++;

                if (timeCounterH == 120)
                {
                    caseSwitchH = 3;
                }
                break;
            case 3:
			
                timeCounterH = 0;

                myTransform.position = Vector3.MoveTowards(myTransform.position, targetHB.position, Time.deltaTime * speedH);

                if (myTransform.position.z == targetHB.position.z)
                {
                    caseSwitchH = 4;
                }
                break;
            case 4:
			
                timeCounterH++;

                if (timeCounterH == 120)
                {
                    caseSwitchH = 1;
                }
                break;
        }
    }

    public void VMovement()
    {
        switch (caseSwitchV)
        {
            case 1:

                timeCounterV = 0;

                myTransform.position = Vector3.MoveTowards(myTransform.position, new Vector3(transform.position.x, targetVA, transform.position.z), Time.deltaTime * speedH);

			if (myTransform.position.y == targetVA)
                {
                    caseSwitchV = 2;

                }
                break;
            case 2:
			
                timeCounterV++;

                if (timeCounterV == 120)
                {
                    caseSwitchV = 3;
                }
                break;
            case 3:
			
                timeCounterV = 0;

                myTransform.position = Vector3.MoveTowards(myTransform.position, new Vector3(transform.position.x, targetVB, transform.position.z), Time.deltaTime * speedH);

			if (myTransform.position.y == targetVB)
                {
                    caseSwitchV = 4;
                }
                break;
            case 4:
			
                timeCounterV++;

                if (timeCounterV == 120)
                {
                    caseSwitchV = 1;
                }
                break;
        }
    }
}

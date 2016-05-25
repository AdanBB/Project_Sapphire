using UnityEngine;
using System.Collections;

[System.Serializable]
public class HorizontalStructure
{
    public GameObject HAPoint;
    public GameObject HBPoint;
}

[System.Serializable]
public class VerticalStructure
{
    public GameObject VAPoint;
    public GameObject VBPoint;
}

public class PlatformMovemet : MonoBehaviour
{
    #region Variables
    private Renderer myRenderer;

    public Transform parent;

    public float waitingFrames;

    [Header("Colors")]

    private Color verticalColor = Color.blue;
    private Color hotizontalColor = Color.green;

    [Header("Horizontal")]

    public HorizontalStructure horizontalMovement;

    public float horizontalSpeed;

    private int caseSwitchH;
    private int timeCounterH;

    [Header("Vertical")]

    public VerticalStructure verticalMovement;

    public float verticalSpeed;

    private int caseSwitchV;
    private int timeCounterV;

    private Transform myTransform;

    #endregion

    // Use this for initialization
    void Awake()
    {
        //General
        myRenderer = this.GetComponent<Renderer>();
        myTransform = parent.GetComponent<Transform>();

        timeCounterH = 0;
        caseSwitchH = 1;

        timeCounterV = 0;
        caseSwitchV = 1;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        LocalPosition();
        ColorDetection();
    }

    public void ColorDetection()
    {
        if (myRenderer.material.color == Color.blue)
        {
			
            VMovement();
        }
        if (myRenderer.material.color == Color.green)
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

                myTransform.position = Vector3.MoveTowards(myTransform.position, horizontalMovement.HAPoint.transform.position, Time.deltaTime * horizontalSpeed);

                if (myTransform.position == horizontalMovement.HAPoint.transform.position)
                {
                    caseSwitchH = 2;

                }
                break;
            case 2:

                timeCounterH++;

                if (timeCounterH >= waitingFrames)
                {
                    caseSwitchH = 3;
                }
                break;
            case 3:
			
                timeCounterH = 0;

                myTransform.position = Vector3.MoveTowards(myTransform.position, horizontalMovement.HBPoint.transform.position, Time.deltaTime * horizontalSpeed);

                if (myTransform.position == horizontalMovement.HBPoint.transform.position)
                {
                    caseSwitchH = 4;
                }
                break;
            case 4:
			
                timeCounterH++;

                if (timeCounterH >= waitingFrames)
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

                myTransform.position = Vector3.MoveTowards(myTransform.position, verticalMovement.VAPoint.transform.position, Time.deltaTime * verticalSpeed);

			if (myTransform.position.y == verticalMovement.VAPoint.transform.position.y)
                {
                    caseSwitchV = 2;

                }
                break;
            case 2:

                timeCounterV++;

                if (timeCounterV >= waitingFrames)
                {
                    caseSwitchV = 3;
                }
                break;
            case 3:
			
                timeCounterV = 0;
                myTransform.position = Vector3.MoveTowards(myTransform.position, verticalMovement.VBPoint.transform.position, Time.deltaTime * verticalSpeed);

			if (myTransform.position.y == verticalMovement.VBPoint.transform.position.y)
                {
                    caseSwitchV = 4;
                }
                break;
            case 4:
			
                timeCounterV++;

                if (timeCounterV >= waitingFrames)
                {
                    caseSwitchV = 1;
                }
                break;
        }
    }

    public void LocalPosition()
    {
        verticalMovement.VAPoint.transform.position = new Vector3(myTransform.position.x, verticalMovement.VAPoint.transform.position.y, myTransform.position.z);
        verticalMovement.VBPoint.transform.position = new Vector3(myTransform.position.x, verticalMovement.VBPoint.transform.position.y, myTransform.position.z);

        horizontalMovement.HAPoint.transform.position = new Vector3(horizontalMovement.HAPoint.transform.position.x , myTransform.position.y, horizontalMovement.HAPoint.transform.position.z);
        horizontalMovement.HBPoint.transform.position = new Vector3(horizontalMovement.HBPoint.transform.position.x, myTransform.position.y, horizontalMovement.HBPoint.transform.position.z);
    }

}
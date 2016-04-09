using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

public class leverBehaviour : MonoBehaviour {

    public List<GameObject> sincroObjects;
    bool active;
    public string movementType;
    private Color startingColor;

	// Use this for initialization
	void Start () {
        active = false;
        startingColor = this.GetComponent<Renderer>().material.color;
    }

    void Update()
    {
        UpdateColors();
    }

    void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Player") && Input.GetKeyDown(KeyCode.E) && (this.GetComponent<Renderer>().material.color != startingColor))
        {
            active = !active;
            Debug.Log("Palanca Activada");

            if (active == true)
            {
                Debug.Log("Palanca Activada");
                if (movementType == "Vertical")
                {
                    for (int i = 0; i < sincroObjects.Count; i++)
                    {
                        sincroObjects[i].GetComponent<VMovement>().enabled = true;
                    }
                }
                else if (movementType == "Horizontal")
                {
                    for (int i = 0; i < sincroObjects.Count; i++)
                    {
                        sincroObjects[i].GetComponent<HMovement>().enabled = true;
                    }
                }
                else if (movementType == "Diagonal")
                {
                        for (int i = 0; i < sincroObjects.Count; i++)
                        {
                            sincroObjects[i].GetComponent<DMovement>().enabled = true;
                        }
                }  
            }
            else if (active == false)
            {
                Debug.Log("Palanca Desactivada");
                if (movementType == "Vertical")
                {
                    for (int i = 0; i < sincroObjects.Count; i++)
                    {

                        sincroObjects[i].GetComponent<VMovement>().enabled = false;
                    }
                }
                else if (movementType == "Horizontal")
                {
                    for (int i = 0; i < sincroObjects.Count; i++)
                    {

                        sincroObjects[i].GetComponent<HMovement>().enabled = false;
                    }
                }
                else if (movementType == "Diagonal")
                {
                    for (int i = 0; i < sincroObjects.Count; i++)
                    {

                        sincroObjects[i].GetComponent<DMovement>().enabled = false;
                    }
                }
            }            
        }
    }

    public void UpdateColors()
    {
        for (int i = 0; i < sincroObjects.Count; i++)
        {
            if (sincroObjects[i].GetComponent<Renderer>().material.color != this.GetComponent<Renderer>().material.color)
            {
                if (movementType == "Vertical")
                {
                    sincroObjects[i].GetComponent<VMovement>().enabled = false;
                }
                else if (movementType == "Horizontal")
                {
                    Debug.Log("Desactivar Horizontal");
                    sincroObjects[i].GetComponent<HMovement>().enabled = false;
                }
                else if (movementType == "Diagonal")
                {
                    sincroObjects[i].GetComponent<DMovement>().enabled = false;
                }
                sincroObjects.Remove(sincroObjects[i]);
            }
        }
        if (sincroObjects.Count == 0)
        {
            Debug.Log("Palanca Desactivada");
            active = false;
        }
    }
}

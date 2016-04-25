using UnityEngine;
using System.Collections;

public class BulletScript : MonoBehaviour {

    public float speed;
    public GameObject player;
	public GameObject colorManagerGO;

	private Color color1;
	private Color color2;
	void Start(){
	
		colorManagerGO = GameObject.FindGameObjectWithTag ("ColorManager");
		color1 = colorManagerGO.GetComponent<ColorManager> ().colors[0];
		color2 = colorManagerGO.GetComponent<ColorManager> ().colors[1];
		//GetComponent<Renderer> ().sharedMaterial.color = color1;
	}
    void FixedUpdate()
    {
        
        transform.Translate(Vector3.forward * Time.deltaTime * speed);

    }
    private void OnDisable()
    {
        transform.position = player.transform.position;
    }
	public void ColorBullet(int color){
	
		if (color == 0) {
		

			GetComponent<Renderer> ().sharedMaterial.color = color1;
		
		
		}
		if (color == 1) {


			GetComponent<Renderer> ().sharedMaterial.color = color2;

		}

	
	}
}


using UnityEngine;
using System.Collections;

public class BulletScript : MonoBehaviour {

    public float speed;

	private PlayerAI _player;
	private GameObject _colorManager;
	private Color _bulletColor;

	void Awake(){
	
		_player = GameObject.Find ("PlayerAim").GetComponent<PlayerAI> ();

	}

	void OnEnable()
	{
		_bulletColor = _player.selectedColor;

		this.GetComponent<Renderer> ().material.color = _bulletColor;

	}
    void FixedUpdate()
    {
        
        transform.Translate(Vector3.forward * Time.deltaTime * speed);

    }
    private void OnDisable()
    {
        transform.position = _player.transform.position;
    }
}


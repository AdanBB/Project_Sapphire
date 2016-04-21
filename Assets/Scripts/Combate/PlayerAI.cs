using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System;
using System.Collections.Generic;

public class PlayerAI : MonoBehaviour
{
    public enum Weapon { RANGE, MELEE }
    public Weapon weapon;
    public int damage;
    //public Text enemyText;
    public Color weaponColorGreen;
    public Color weaponColorBlue;
    public Renderer myRenderer;
    public int weaponTipe;
    public float fireTime;
    public float _firetime;
	private int attackNum;
	public bool isAttacking;
    public float range;
	public bool isAiming;

    public int weaponColor;
    public Animator myAnimator;
    public Image weaponImage;
    public List<Sprite> weaponTexture;

	private GameObject Pivot;
	private Vector3 pivotTransform;
	private Vector3 _pivotTransform;

	private int currentFrame;
	private int _currentFrame;
	private int framesDuration;

	public ParticleSystem sword;
	public Gradient gradientBlue;
	public Gradient gradientGreen;

	public GameObject swordGO;
	public GameObject pistolGO;

	void Awake(){
	
		Pivot = GameObject.FindGameObjectWithTag ("Camera").transform.GetChild (0).gameObject;

	}

    void Start()
    {
		isAiming = false;
        weaponColor = 0;
        _firetime = fireTime;
		isAttacking = false;
		pivotTransform = new Vector3 (0.17f,2.83f,-5.08f);
		_pivotTransform = new Vector3 (0.79f,2.42f,-2.03f);
		currentFrame = 0;
		_currentFrame = 15;
		framesDuration = 15;
		swordGO.SetActive (false);
		pistolGO.SetActive (true);


    }
    // Update is called once per frame
    void Update()
    {

        switch (weapon)
        {
            case Weapon.RANGE:
                weaponTipe = 0;
                RangeWeapon();
                break;
            case Weapon.MELEE:
                weaponTipe = 1;
                MeleWeapon();
                break;
        }

    }
    public void MeleWeapon()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            weaponImage.sprite = weaponTexture[0]; 
            weapon = Weapon.RANGE;	
			swordGO.SetActive (false);
			pistolGO.SetActive (true);
        }
        if (Input.GetAxis("Mouse ScrollWheel") > 0f)
        {
			var colo = sword.colorOverLifetime;

			colo.color = new ParticleSystem.MinMaxGradient (gradientGreen);
            weaponColor = 1;
            // scroll up
            myRenderer.material.color = weaponColorBlue;
        }
        else if (Input.GetAxis("Mouse ScrollWheel") < 0f)
        {
			var colo = sword.colorOverLifetime;
			colo.color = new ParticleSystem.MinMaxGradient (gradientBlue);
            weaponColor = 2;
            // scroll down
            myRenderer.material.color = weaponColorGreen;
            
        }
		if (Input.GetButtonDown("Fire1")&& (!isAttacking))
        {
			attackNum = (int)UnityEngine.Random.Range (1, 4);

			myAnimator.SetInteger ("Attack", attackNum );
            myAnimator.SetBool("IsAttacking", true);
			isAttacking = true;
			Invoke ("FireRestart", 1f);
        }



    }

    public void RangeWeapon()
    {
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            weaponImage.sprite = weaponTexture[1];
            weapon = Weapon.MELEE;
			swordGO.SetActive (true);
			pistolGO.SetActive (false);
        }
        if (_firetime >= 0)
        {
            _firetime--;

        }
        if (_firetime <= 0 && Input.GetButtonDown("Fire1"))
        {
            myAnimator.SetBool("IsShooting", true);
            Fire();
            _firetime = fireTime;
        }

		if (Input.GetMouseButtonDown (1)) {

			//Pivot.transform.localPosition = _pivotTransform;
			Aim();
			myAnimator.SetBool ("Aim",true);
			_currentFrame = 0;
			isAiming = true;

		}

		if (Input.GetMouseButtonUp (1)) {

			//Pivot.transform.localPosition = pivotTransform;
			myAnimator.SetBool ("Aim",false);
			currentFrame = 0;
			isAiming = false;
			Invoke ("Aim", 0.2f);

		}
		if (isAiming) {

			if(currentFrame <= framesDuration)
			{
				// TODO: calcular easing
				//transform.position = new Vector3(x,y,z);
				//transform.localScale = new Vector3(x,y,z);
				//transform.rotation = Quaternion.Euler(x,y,z);
				//mat.color = new Color(r,g,b,a);

				Pivot.transform.localPosition = new Vector3(Easing.QuartEaseIn(currentFrame, pivotTransform.x, (_pivotTransform.x - pivotTransform.x), framesDuration),
					Easing.QuartEaseIn(currentFrame, pivotTransform.y, (_pivotTransform.y - pivotTransform.y), framesDuration),
					Easing.QuartEaseIn(currentFrame, pivotTransform.z, (_pivotTransform.z - pivotTransform.z), framesDuration));        
				currentFrame++;
			}

		}
		if (!isAiming) {
		
			if(_currentFrame <= framesDuration)
			{
				// TODO: calcular easing
				//transform.position = new Vector3(x,y,z);
				//transform.localScale = new Vector3(x,y,z);
				//transform.rotation = Quaternion.Euler(x,y,z);
				//mat.color = new Color(r,g,b,a);

				Pivot.transform.localPosition = new Vector3(Easing.QuartEaseOut(_currentFrame, _pivotTransform.x, (pivotTransform.x - _pivotTransform.x), framesDuration),
					Easing.QuartEaseOut(_currentFrame, _pivotTransform.y, (pivotTransform.y - _pivotTransform.y), framesDuration),
					Easing.QuartEaseOut(_currentFrame, _pivotTransform.z, (pivotTransform.z - _pivotTransform.z), framesDuration));        
				_currentFrame++;
			}
		
		}




    }
    void Fire()
    {
        GameObject obj = PoolingObjectScript.current.GetPooledObject();

        if (obj == null) return;

        obj.transform.position = transform.position;
        obj.transform.rotation = transform.rotation;
        obj.SetActive(true);

    }
	void FireRestart(){
	
		myAnimator.SetBool ("IsAttacking", false);
		isAttacking = false;
	
	}
	void Aim(){
		



	
	}
}

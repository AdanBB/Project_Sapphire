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

    public GameObject chorro;

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
	public GameObject ShootParticle;

	public GameObject[] ShootParticles;

	public AudioClip swordChangeColor;

	public ColorManager colorManager;
	public AudioSource playerAudio;
	public AudioClip shootSound;

	private int counterWeapon1;
	private int counterWeapon2;

	public playerController PlayerController;


	void Awake(){
	
		Pivot = GameObject.FindGameObjectWithTag ("Camera").transform.GetChild (0).gameObject;

		//playerAudio = GameObject.FindGameObjectWithTag ("Player").GetComponent<AudioSource> ();

	}

    void Start()
    {
		isAiming = false;
        weaponColor = 1;
        _firetime = fireTime;
		isAttacking = false;
		pivotTransform = new Vector3 (0.17f,2.83f,-5.08f);
		_pivotTransform = new Vector3 (0.79f,2.42f,-2.03f);
		currentFrame = 0;
		_currentFrame = 15;
		framesDuration = 15;
		swordGO.SetActive (false);
		pistolGO.SetActive (true);
		counterWeapon1 = 0;
		counterWeapon2 = 0;

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
        #region Change Weapon

        if (Input.GetKeyDown(KeyCode.Q))
        {
            weaponImage.sprite = weaponTexture[0];  
            weapon = Weapon.RANGE;	
			swordGO.SetActive (false);
			pistolGO.SetActive (true);
        }

        #endregion

        #region Color Type

        if (colorManager.colorsUnlock.Count != 0)
        {
			if (ColorWeapon.currentColor == 0)
            {
				if ( counterWeapon1 < 1)
                {
                    ChangeColorAudio();
					counterWeapon2 = 0;
                    if (counterWeapon1 != 1)
                    {
                        counterWeapon1++;
                    }
				}			
					var colo = sword.colorOverLifetime;
					colo.color = new ParticleSystem.MinMaxGradient (gradientBlue);
					weaponColor = 1;
					myRenderer.material.color = colorManager.colorsUnlock [0];
			}

			if (ColorWeapon.currentColor == 1)
            {
				if ( counterWeapon2 < 1)
                {
                    ChangeColorAudio();
					counterWeapon1 = 0;
                    if (counterWeapon2 != 1)
                    {
                        counterWeapon2++;
                    }	
				}

				//GetComponentInParent<AudioSource>().PlayOneShot (swordChangeColor);
				var colo = sword.colorOverLifetime;
				colo.color = new ParticleSystem.MinMaxGradient (gradientGreen);
				weaponColor = 2;
				myRenderer.material.color = colorManager.colorsUnlock [1];
			}
		}

        #endregion

        #region Attack

        if (Input.GetButtonDown("Fire1")&& (!isAttacking) && PlayerController.grounded)
        {
			attackNum = (int)UnityEngine.Random.Range (1, 4);
			myAnimator.SetInteger ("Attack", attackNum );
            myAnimator.SetBool("IsAttacking", true);
			isAttacking = true;
			Invoke ("FireRestart", 0.5f);
        }

        #endregion

    }

    public void RangeWeapon()
    {
        #region Change Weapon 

        if (Input.GetKeyDown(KeyCode.Q))
        {
            weaponImage.sprite = weaponTexture[1];
            weapon = Weapon.MELEE;
			swordGO.SetActive (true);
			pistolGO.SetActive (false);
        }

        #endregion

        #region Shoot Bullet
        /*
        if (_firetime >= 0)
        {
            _firetime--;

        }

		if (_firetime <= 0 && Input.GetButtonDown("Fire1") && isAiming && (colorManager.colorsUnlock.Count != 0))
        {
            myAnimator.SetBool("IsShooting", true);
            if (!chorro.GetComponent<ParticleSystem>().isPlaying)
            {
                chorro.GetComponent<ParticleSystem>().Play();
            }
            Fire();
            _firetime = fireTime;
        }*/

        #endregion

        #region Shoot Chorro

        if (Input.GetButton("Fire1") && isAiming && (colorManager.colorsUnlock.Count != 0))
        {
            if (!chorro.activeInHierarchy)
            {
                chorro.SetActive(true);
                chorro.GetComponent<particleCollision>().ParticleColor(ColorWeapon.currentColor);
                chorro.GetComponent<ParticleSystem>().Play();
            }
            myAnimator.SetBool("IsShooting", true);  
        }

        else
        {
            chorro.gameObject.SetActive(false);
        }

        #endregion

        #region Aim

        if (Input.GetMouseButtonDown (1))
        {
			//Pivot.transform.localPosition = _pivotTransform;
			myAnimator.SetBool ("Aim",true);
			_currentFrame = 0;
			isAiming = true;
		}

		if (Input.GetMouseButtonUp (1))
        {
            //Pivot.transform.localPosition = pivotTransform;
			myAnimator.SetBool ("Aim",false);
			currentFrame = 0;
			isAiming = false;
			Invoke ("Aim", 0.2f);
		}

		if (isAiming)
        {
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

		if (!isAiming)
        {
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

        #endregion
    }

    void Fire()
    {
        GameObject obj = PoolingObjectScript.current.GetPooledObject();


        if (obj == null) return;

        obj.transform.position = transform.position;
        obj.transform.rotation = transform.rotation;
        obj.SetActive(true);

		playerAudio.PlayOneShot (shootSound);

		obj.GetComponent<BulletScript> ().ColorBullet(ColorWeapon.currentColor);

		Instantiate (ShootParticle, transform.position, transform.rotation);
    }

	void FireRestart()
    {
        myAnimator.SetBool ("IsAttacking", false);
		isAttacking = false;
	}

    void ChangeColorAudio()
    {
		GetComponentInParent<AudioSource>().PlayOneShot (swordChangeColor);
	}
}

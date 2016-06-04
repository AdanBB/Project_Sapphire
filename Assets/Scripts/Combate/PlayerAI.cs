using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

public class PlayerAI : MonoBehaviour
{
    public int damage;

    public float fireTime;
    public float _firetime;

	internal bool isAttacking;
    public float range;
	internal bool isAiming;

    public Animator myAnimator;

	internal List<Color> playerColors;
	internal Color selectedColor;

	private GameObject Pivot;
	private Vector3 pivotTransform;
	private Vector3 _pivotTransform;
	private Vector3 _pivotTransformBoos;

	private int currentFrame;
	private int _currentFrame;
	private int framesDuration;

	public ColorManager colorManager;
	public AudioSource playerAudio;
	public AudioClip shootSound;

	public float paintCharges;

	public playerController PlayerController;


	void Awake(){
	
		Pivot = GameObject.FindGameObjectWithTag ("Camera").transform.GetChild (0).gameObject;

	}

    void Start()
    {
		playerColors = new List<Color> ();

        isAiming = false;
        _firetime = fireTime;
		isAttacking = false;

		pivotTransform = new Vector3 (0.17f,2.83f,-5.08f);
		_pivotTransform = new Vector3 (0.79f,2.42f,-2.03f);
		_pivotTransformBoos = new Vector3 (0.36f,2.42f,-3.523f);

		currentFrame = 0;
		_currentFrame = 15;
		framesDuration = 15;
    }
    // Update is called once per frame
    void Update()
    {
		RangeWeapon ();
    }

    public void RangeWeapon()
    {
		#region Shoot Bullet

        if (paintCharges > 0)
        {
            if (_firetime >= 0)
            {
                _firetime--;
            }

            if (_firetime <= 0 && Input.GetButton("Fire1") && isAiming)
            {
                myAnimator.SetBool("IsShooting", true);
                paintCharges -= 1;
                Fire();
                _firetime = fireTime;
            }
        }

        #endregion

        #region Aim

        if (Input.GetMouseButtonDown (1))
        {
			myAnimator.SetBool ("Aim",true);
			_currentFrame = 0;
			isAiming = true;
		}

		else if (Input.GetMouseButtonUp (1))
        {
            myAnimator.SetBool ("Aim",false);
			currentFrame = 0;
			isAiming = false;
		}

		if (isAiming)
        {
			if(currentFrame <= framesDuration)
			{
				if(SceneManager.GetActiveScene().buildIndex == 6){
					Pivot.transform.localPosition = new Vector3(Easing.QuintEaseOut(currentFrame, pivotTransform.x, (_pivotTransformBoos.x - pivotTransform.x), framesDuration),
						Easing.QuintEaseOut(currentFrame, pivotTransform.y, (_pivotTransformBoos.y - pivotTransform.y), framesDuration),
						Easing.QuintEaseOut(currentFrame, pivotTransform.z, (_pivotTransformBoos.z - pivotTransform.z), framesDuration));        
					currentFrame ++;

				}else{
				Pivot.transform.localPosition = new Vector3(Easing.QuartEaseIn(currentFrame, pivotTransform.x, (_pivotTransform.x - pivotTransform.x), framesDuration),
					Easing.QuartEaseIn(currentFrame, pivotTransform.y, (_pivotTransform.y - pivotTransform.y), framesDuration),
					Easing.QuartEaseIn(currentFrame, pivotTransform.z, (_pivotTransform.z - pivotTransform.z), framesDuration));        
				currentFrame++;
				}
			}
		}
		else if  (!isAiming)
        {
			if(_currentFrame <= framesDuration)
			{
				if(SceneManager.GetActiveScene().buildIndex == 6){
					Pivot.transform.localPosition = new Vector3(Easing.QuintEaseOut(_currentFrame, _pivotTransformBoos.x, (pivotTransform.x - _pivotTransformBoos.x), framesDuration),
						Easing.QuintEaseOut(_currentFrame, _pivotTransformBoos.y, (pivotTransform.y - _pivotTransformBoos.y), framesDuration),
						Easing.QuintEaseOut(_currentFrame, _pivotTransformBoos.z, (pivotTransform.z - _pivotTransformBoos.z), framesDuration));        
					_currentFrame++;

				}else {
				Pivot.transform.localPosition = new Vector3(Easing.QuartEaseOut(_currentFrame, _pivotTransform.x, (pivotTransform.x - _pivotTransform.x), framesDuration),
					Easing.QuartEaseOut(_currentFrame, _pivotTransform.y, (pivotTransform.y - _pivotTransform.y), framesDuration),
					Easing.QuartEaseOut(_currentFrame, _pivotTransform.z, (pivotTransform.z - _pivotTransform.z), framesDuration));        
				_currentFrame++;
				}
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
		}
}

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

    public int weaponColor;
    public Animator myAnimator;
    public Image weaponImage;
    public List<Sprite> weaponTexture;


    void Start()
    {
        weaponColor = 0;
        _firetime = fireTime;
		isAttacking = false;
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
        }
        if (Input.GetAxis("Mouse ScrollWheel") > 0f)
        {
            weaponColor = 1;
            // scroll up
            myRenderer.material.color = weaponColorBlue;
        }
        else if (Input.GetAxis("Mouse ScrollWheel") < 0f)
        {
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
        }
        if (_firetime >= 0)
        {
            _firetime--;

        }
        if (_firetime <= 0 && Input.GetButtonDown("Fire1"))
        {
            myAnimator.SetBool("IsShooting", true);
            Debug.Log("disparo");
            Fire();
            _firetime = fireTime;
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
}

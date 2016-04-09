using UnityEngine;
using System.Collections;

public class AnimatorControllerBehaviour : MonoBehaviour {
    Animator myAnimator;
    void Awake()
    {
        myAnimator = GetComponent<Animator>();
    }
    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
    public void OnAttackFinished()
    {
        myAnimator.SetBool("IsAttacking", false);
    }
    public void OnShootFinished()
    {
        myAnimator.SetBool("IsShooting", false);
    }
    public void OnDamagedFinished()
    {
        myAnimator.SetBool("IsDamaged", false);
    }
    

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackManager : MonoBehaviour {

	UserInput inputs;
	CharacterMovement characterMove;

	Animator animator;
	
	public int currAtkState = 0;

	public bool canAtk = true;
	public float animTime = 10f;
	private float animTimer;

	public float comboTime = 0.5f;
	private float comboTimer;

	// Use this for initialization
	void Start () {
		animator = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
		animTimer -= Time.deltaTime;
		comboTimer -= Time.deltaTime;

		if(animTimer > 0) {
			canAtk = false;
		}
		else if (animTimer < 0){
			canAtk = true;
		}

		if(comboTime == 0) {
			animator.SetInteger("AttackState",0);
			currAtkState = 0;
		}
		print ("CanAtk: " + canAtk);
	}

	public void Attack() {
		
		if(canAtk) {
		    animTimer = animTime;
		    comboTimer = comboTime;
		
		    animator.SetBool("attackState1", true);

			if(currAtkState == 3) {
			    currAtkState = 0;
			}
			else {
			    currAtkState++;
			}

			animator.SetInteger("AttackState",currAtkState);
		}
		/*
		switch (currAtkState)
		{
			case 0:
			animator.SetBool("attackState1", true);
			currAtkState++;
			animator.SetInteger("AttackState",currAtkState);
			break;

			case 1:
			animator.SetBool("attackState1", true);
			currAtkState++;
			animator.SetInteger("AttackState",currAtkState);
			break;

			case 2:
			animator.SetBool("attackState1", true);
			currAtkState++;
			animator.SetInteger("AttackState",currAtkState);
			break;

			case 3:
			animator.SetBool("attackState1", true);
			currAtkState++;
			animator.SetInteger("AttackState",currAtkState);
			break;
		}*/


/*
		if(animator.GetInteger("AttackState") == -1) {
			animator.SetBool("attackState1", true);
			animator.SetInteger("AttackState", 1);
		}
		*/
	}
}

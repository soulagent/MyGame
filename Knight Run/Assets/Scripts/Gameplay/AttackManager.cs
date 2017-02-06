using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackManager : MonoBehaviour {

	UserInput inputs;
	CharacterMovement characterMove;

	Animator animator;
    public GameObject wieldWep;
    public GameObject wieldWep2;
    public GameObject backWep;
    public GameObject backWep2;
	
	public int currAtkState = 0;

	public bool canAtk = true;
	public float animTime = 2f;

	public float comboTime = 5f;

	// Use this for initialization
	void Start () {
		animator = GetComponent<Animator>();
        wieldWep.SetActive(false);
        //wieldWep2.SetActive(false);
        backWep.SetActive(true);
        //backWep2.SetActive(true);
	}
	
	// Update is called once per frame
	void Update () {
		animTime -= Time.deltaTime;
		comboTime -= Time.deltaTime;

		if(animTime < 0) {
			canAtk = true;
		}
		else {
			canAtk = false;
		}

		if(comboTime < 0) {
			animator.SetInteger("AttackState",0);
			currAtkState = 0;
            animator.SetBool("attackState1", false);
            animator.SetBool("attackState2", false);
            animator.SetBool("attackState3", false);
            wieldWep.SetActive(false);
            //wieldWep2.SetActive(false);
            backWep.SetActive(true);
            //backWep2.SetActive(true);
        }
		print ("CanAtk: " + canAtk);
        Debug.Log("AnimTime: " + animTime);
        Debug.Log("ComboTime: " + comboTime);
	}

	public void Attack1() {
		if(canAtk) {
		    animTime = 0.57f;
		    comboTime = 0.8f;

            wieldWep.SetActive(true);
            //wieldWep2.SetActive(true);
            backWep.SetActive(false);
            //backWep2.SetActive(false);
            animator.SetBool("attackState1", true);

			if(animator.GetInteger("AttackState") == 3) {
                currAtkState = 0;
                animator.SetInteger("AttackState", 0);
                animator.SetBool("attackState1", false);
                wieldWep.SetActive(false);
                //wieldWep2.SetActive(false);
                backWep.SetActive(true);
                //backWep2.SetActive(true);
            }
			else {
			    currAtkState++;
			}

			animator.SetInteger("AttackState",currAtkState);
		}
	}
    public void Attack2() {
        if (canAtk) {
            animTime = 0.57f;
            comboTime = 0.8f;

            wieldWep.SetActive(true);
            //wieldWep2.SetActive(true);
            backWep.SetActive(false);
            //backWep2.SetActive(false);
            animator.SetBool("attackState2", true);

            if (animator.GetInteger("AttackState") == 3) {
                currAtkState = 0;
                animator.SetInteger("AttackState", 0);
                animator.SetBool("attackState2", false);
                wieldWep.SetActive(false);
                //wieldWep2.SetActive(false);
                backWep.SetActive(true);
                //backWep2.SetActive(true);
            }
            else {
                currAtkState++;
            }

            animator.SetInteger("AttackState", currAtkState);
        }
    }
    public void Attack3() {
        if (canAtk) {
            animTime = 0.57f;
            comboTime = 0.8f;

            wieldWep.SetActive(true);
            //wieldWep2.SetActive(true);
            backWep.SetActive(false);
            //backWep2.SetActive(false);
            animator.SetBool("attackState3", true);

            if (animator.GetInteger("AttackState") == 3) {
                currAtkState = 0;
                animator.SetInteger("AttackState", 0);
                animator.SetBool("attackState3", false);
                wieldWep.SetActive(false);
                //wieldWep2.SetActive(false);
                backWep.SetActive(true);
                //backWep2.SetActive(true);
            }
            else {
                currAtkState++;
            }

            animator.SetInteger("AttackState", currAtkState);
        }
    }
}

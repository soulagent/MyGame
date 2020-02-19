using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackManager : MonoBehaviour {

    Animator animator;
    PlayerInputsRM playerInput;
    CharacterMove characterMove;
    public GameObject weaponOnRightHand;
    public GameObject weaponOnLeftHand;
    public GameObject weaponOnRightHip;
    public GameObject weaponOnLeftHip;

    public int currAtkState = 0;

    public bool canAtk = true;

    public float animTime;
    public float comboTime;

    // Use this for initialization
    void Start() {
        animator = GetComponent<Animator>();
        weaponOnRightHand.SetActive(false);
        weaponOnLeftHand.SetActive(false);
        weaponOnLeftHip.SetActive(true);
        weaponOnRightHip.SetActive(true);
    }
	// Update is called once per frame
	void Update () {
        animTime -= Time.deltaTime; // [ Cooldown timer for buttons to prevent spamming and glitching animations ]
        comboTime -= Time.deltaTime; // [ Time for animation to play out ]

        if (animTime < 0) {
            canAtk = true;
        }
        else {
            canAtk = false;
        }

        if (comboTime < 0) {
            animator.SetInteger("AttackState", 0);
            currAtkState = 0;
            animator.SetBool("AttackA", false);
            weaponOnRightHand.SetActive(false);
            weaponOnLeftHip.SetActive(true);
        }

        if (animator.GetBool("AttackA") == true) {
            weaponOnRightHand.SetActive(true);
            weaponOnLeftHip.SetActive(false);
        }
        else {
            weaponOnRightHand.SetActive(false);
            weaponOnLeftHip.SetActive(true);
        }

        print("Player Can Attack?: " + canAtk);
        //print("Anim time: " + animTime);
        //print("ComboTime: " + comboTime);

	}// [ Update function End ]

    public void AttackA() {
        if(canAtk) {
            // [ If Player can attack, set conditions for AttackA_1 to be called. ]
            // [ Enable weapon visibility ]
            // [ CanAtk is a code-side check for attackability, animator side is by conditions ( AttackA, bool ) and ( AttackState, Int ) ]
            animTime = 0.7f;
            comboTime = 1.5f;

            animator.SetBool("AttackA", true);
            //weaponOnHand.SetActive(true);
            //weaponOnHip.SetActive(false);

            if (animator.GetInteger("AttackState") == 2) {
                // [ When combo reaches state 3, reset everything to base until called again ]
                animTime = 0f;
                comboTime = 0f;
                currAtkState = 0;
                animator.SetInteger("AttackState", 0);
                animator.SetBool("AttackA", false);
                weaponOnRightHand.SetActive(false);
                weaponOnLeftHip.SetActive(true);
            }
            else {
                currAtkState++; // [ Everytime the function is called (i.e. button pressed after animTime runs out), adds 1 to attackState ]
            }

            animator.SetInteger("AttackState", currAtkState); // [ Since it starts from 0, once function is called, it will be 1, so on and so forth ]
        }// [ CanAtk Function End ]
    }// [ Attack A Function End ]
}// [ Class AttackManager End ]

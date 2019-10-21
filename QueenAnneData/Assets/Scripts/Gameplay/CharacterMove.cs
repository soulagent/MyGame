using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(CharacterController))]

public class CharacterMove : MonoBehaviour {

    Animator animator;
    CharacterController characterController;

    [System.Serializable]
    public class AnimationSettings {
        public string verticalVelocityFloat = "Forward";
        public string horizontalVelocityFloat = "strafe";
        public string isRunning = "isRunning";
        public float RunSpeed;
        public float WalkSpeed;
        //public string groundedBool = "isGrounded";
    }
    [SerializeField]
    public AnimationSettings animations;

    public GameObject CharacterPivot;

    //bool isGrounded = true;

	// Use this for initialization
	void Start () {
        animator = GetComponent<Animator>();
        characterController = GetComponent<CharacterController>();
        SetupAnimator();
        animator.SetFloat(animations.isRunning, -1);
	}
	
	// Update is called once per frame
	void Update () {
        //isGrounded = characterController.isGrounded;
        if (Input.GetButton("shiftKey")) {
            animator.SetFloat(animations.isRunning, 1.0f);
        }
        else {
            animator.SetFloat(animations.isRunning, -1);
        }
        ///* // Hardcoding movement
        if(Input.GetButton("upKey")) { //if up is pressed, move character forward with speed of WalkSpeed
            animator.SetFloat(animations.verticalVelocityFloat, 1);

            transform.Translate(Vector3.forward * animations.WalkSpeed * Time.deltaTime);

            /*
            Transform characterPivot = CharacterPivot.transform;
            Transform pivotT = characterPivot.root;
            Vector3 pivotPos = pivotT.position;
            Vector3 lookTarget = pivotPos + (pivotT.forward * 1);
            Vector3 thisPos = transform.position;
            Vector3 lookDir = (lookTarget - thisPos);
            transform.position = Vector3.Lerp(transform.position, lookDir, Time.deltaTime * animations.WalkSpeed);
            */
            /*
            Vector3 newPositionWalk = transform.position;
            newPositionWalk.z += animations.WalkSpeed * Time.deltaTime;
            transform.position = newPositionWalk;
            */

            if (Input.GetButton("shiftKey")) { //if shift is pressed along with up, apply run
                animator.SetFloat(animations.isRunning, 1);
                transform.Translate(Vector3.forward * animations.RunSpeed * Time.deltaTime);
                /*
                Vector3 newPositionRun = transform.position;
                newPositionRun.z += animations.RunSpeed * Time.deltaTime;
                transform.position = newPositionRun;
                */
            }
            else
                animator.SetFloat(animations.isRunning, -1);
        }
        else {
            animator.SetFloat(animations.verticalVelocityFloat, 0);
        }
        //*/
	}

    
    public void Animate(float forward, float strafe) {
        animator.SetFloat(animations.verticalVelocityFloat, forward);
        animator.SetFloat(animations.horizontalVelocityFloat, strafe);
    }
    

    //Setup animator with child avatar
    void SetupAnimator() {
        Animator[] animators = GetComponentsInChildren<Animator>();

        if(animators.Length > 0) {
            for(int i=0; i <animators.Length; i++) {
                Animator anim = animators[i];
                Avatar av = anim.avatar;

                if(anim != animator) {
                    animator.avatar = av;
                    Destroy(anim);
                }
            }
        }
    }
}

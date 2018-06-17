using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(CharacterController))]
public class CharacterMovement : MonoBehaviour {

    Animator animator;
    CharacterController characterController;
    UserInput userInput;

    [System.Serializable]
    public class AnimationSettings {
        public string verticalVelocityFloat = "Forward";
        public string horizontalVelocityFloat = "Strafe";
        public string groundedBool = "isGrounded";
		public string attackBool1 = "attackState1";
		public string attackBool2 = "attackState2";
        public string isRunning = "isRunning";
        //public string jumpBool = "isJumping";
    }
    [SerializeField]
    public AnimationSettings animations;

    //private float gravity = -9.81f;
    private float velocityY;

	bool isGrounded = true;

    // Use this for initialization
    void Start () {
        animator = GetComponent<Animator>();
        characterController = GetComponent<CharacterController>();
        SetupAnimator();
        animator.SetFloat(animations.isRunning, -1);
	}
	
	// Update is called once per frame
	void Update () {
		isGrounded = characterController.isGrounded;
        if (Input.GetButton("LeftShift")) {
            animator.SetFloat(animations.isRunning, 1);
        }
        else {
            animator.SetFloat(animations.isRunning, -1);
        }
    }

    //Animate Character and root motion handles the movement
    public void Animate(float forward, float strafe) {
        animator.SetFloat(animations.verticalVelocityFloat, forward);
        animator.SetFloat(animations.horizontalVelocityFloat, strafe);
        animator.SetBool(animations.groundedBool, isGrounded);
        //animator.SetBool(animations.jumpBool, jumping);
    }

    //Setup animator with child avatar
    void SetupAnimator() {
        Animator[] animators = GetComponentsInChildren<Animator>();

        if(animators.Length > 0) {
            for(int i =0; i < animators.Length; i++) {
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

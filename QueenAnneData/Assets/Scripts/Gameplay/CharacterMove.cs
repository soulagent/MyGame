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
        public string horizontalVelocityFloat = "Strafe";
        public string isRunning = "isRunning";
        //public float RunSpeed;
        //public float WalkSpeed;
    }
    [SerializeField]
    public AnimationSettings animations;

    //public GameObject CharacterPivot;

	// Use this for initialization
	void Start () {
        animator = GetComponent<Animator>();
        characterController = GetComponent<CharacterController>();
        SetupAnimator();
        animator.SetFloat(animations.isRunning, -1);
	}
	
	// Update is called once per frame
	void Update () {
        //CharacterMovementVertical();
        //CharacterMovementHorizontal();
        if (Input.GetButton("shiftKey")) {
            animator.SetFloat(animations.isRunning, 1);
        }
        else {
            animator.SetFloat(animations.isRunning, -1);
        }
	}

    public void Animate(float forward, float strafe) {
        animator.SetFloat(animations.verticalVelocityFloat, forward);
        animator.SetFloat(animations.horizontalVelocityFloat, strafe);
    }
    /*
    void CharacterMovementVertical() {
        #region Up Key
        if (Input.GetButton("upKey")) { //if up is pressed, move character forward with speed of WalkSpeed
            animator.SetFloat(animations.verticalVelocityFloat, 1);
            transform.Translate(Vector3.forward * animations.WalkSpeed * Time.deltaTime);

            if (Input.GetButton("shiftKey")) { //if shift is pressed along with up, apply run
                animator.SetFloat(animations.isRunning, 1);
                transform.Translate(Vector3.forward * animations.RunSpeed * Time.deltaTime);
            }
            else
                animator.SetFloat(animations.isRunning, -1);
        }
        else if (Input.GetButton("downKey")) {
            animator.SetFloat(animations.verticalVelocityFloat, -1);
            transform.Translate(Vector3.forward * animations.WalkSpeed * Time.deltaTime);

            if (Input.GetButton("shiftKey")) {
                animator.SetFloat(animations.isRunning, 1);
                transform.Translate(Vector3.forward * animations.RunSpeed * Time.deltaTime);
            }
        }
        else {
            animator.SetFloat(animations.verticalVelocityFloat, 0);
        } //if up key
        #endregion
    } // vertical movement

    void CharacterMovementHorizontal() { 
        #region Left Key
        if (Input.GetButton("leftKey")) {
            animator.SetFloat(animations.horizontalVelocityFloat, -1);
            transform.Translate(Vector3.forward * animations.WalkSpeed * Time.deltaTime);

            if (Input.GetButton("shiftKey")) { //if shift is pressed along with up, apply run
                animator.SetFloat(animations.isRunning, 1);
                transform.Translate(Vector3.forward * animations.RunSpeed * Time.deltaTime);
            }
            else
                animator.SetFloat(animations.isRunning, -1);
        } //if left key
        #endregion
        #region Right Key
        else if (Input.GetButton("rightKey")) {
            animator.SetFloat(animations.horizontalVelocityFloat, 1);
            transform.Translate(Vector3.forward * animations.WalkSpeed * Time.deltaTime);

            if (Input.GetButton("shiftKey")) { //if shift is pressed along with up, apply run
                animator.SetFloat(animations.isRunning, 1);
                transform.Translate(Vector3.forward * animations.RunSpeed * Time.deltaTime);
            }
            else
                animator.SetFloat(animations.isRunning, -1);
        } //if right key
        #endregion
        else {
            animator.SetFloat(animations.horizontalVelocityFloat, 0);
        }
    } // void horizontal movement
    */
    //Setup animator with child avatar
    void SetupAnimator() {
        Animator[] animators = GetComponentsInChildren<Animator>();

        if(animators.Length > 0) {
            for(int i=0; i < animators.Length; i++) {
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

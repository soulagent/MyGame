using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(CharacterController))]

public class CharacterMove : MonoBehaviour {

    Animator animator;
    public bool canRun = true;
    //CharacterController characterController;

    [System.Serializable]
    public class AnimationSettings {
        public string verticalVelocityFloat = "Forward";
        public string horizontalVelocityFloat = "Strafe";
        public string isRunning = "isRunning";
    }
    [SerializeField]
    public AnimationSettings animations;

	// Use this for initialization
	void Start () {
        animator = GetComponent<Animator>();
        //characterController = GetComponent<CharacterController>();
        SetupAnimator();
        animator.SetFloat(animations.isRunning, -1);
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetButton("shiftKey")) {
            if (canRun) {
                animator.SetFloat(animations.isRunning, 1);
            }
        }
        else {
            animator.SetFloat(animations.isRunning, -1);
        }
	}

    public void Animate(float forward, float strafe) {
        animator.SetFloat(animations.verticalVelocityFloat, forward);
        animator.SetFloat(animations.horizontalVelocityFloat, strafe);
    }

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

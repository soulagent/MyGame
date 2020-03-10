using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInputsRM : MonoBehaviour {

    CharacterMove characterMove;
    AttackManager attackManager;

    [System.Serializable]
    public class InputSettings {
        public string verticalAxis = "Vertical";
        public string horizontalAxis = "Horizontal";
    }
    [SerializeField]
    public InputSettings input;

    [System.Serializable]
    public class OtherSettings {
        public float lookSpeed = 10.0f;
        public float lookDistance = 10.0f;
        public bool requireInputForTurn = true;
    }
    [SerializeField]
    public OtherSettings other;

    Camera mainCam;

	// Use this for initialization
	void Start () {
        attackManager = GetComponent<AttackManager>();
        characterMove = GetComponent<CharacterMove>();
        mainCam = Camera.main;
	}
	
	// Update is called once per frame
	void Update () {
        if (characterMove) {
            characterMove.Animate (Input.GetAxis ("Vertical"), Input.GetAxis ("Horizontal"));
        }

		if (mainCam) {
            if (other.requireInputForTurn) {
                if(Input.GetAxis(input.horizontalAxis) != 0 || Input.GetAxis(input.verticalAxis) != 0) {
                    CharacterLook();
                } 
                
            }// if (requireInputForTurn)
        } // if (mainCam)

        if(Input.GetButtonDown ("AttackA")) {
            attackManager.AttackA();
        }
        /*
        if(Input.GetButtonDown("dodgeKey")) {
            attackManager.Dodge();
        }
        */
	} // update

    //make the character look at a forward point from camera when moving
    void CharacterLook() {
        Transform mainCamT = mainCam.transform;
        Transform pivotT = mainCamT.parent;
        Vector3 pivotPos = pivotT.position;
        Vector3 lookTarget = pivotPos + (pivotT.forward * other.lookDistance);
        Vector3 thisPos = transform.position;
        Vector3 lookDir = (lookTarget - thisPos);
        Quaternion lookRot = Quaternion.LookRotation(lookDir);
        lookRot.x = 0;
        lookRot.z = 0;

        Quaternion newRotation = Quaternion.Lerp(transform.rotation, lookRot, Time.deltaTime * other.lookSpeed);
        transform.rotation = newRotation;
    }
}

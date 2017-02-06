﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UserInput : MonoBehaviour {

	CharacterMovement characterMove;
	AttackManager attackManager;

	[System.Serializable]
	public class InputSettings {
		public string verticalAxis = "Vertical";
		public string horizontalAxis = "Horizontal";
		public string jumpButton = "Jump";
		public string attackButton1 = "Attack1";
		public string attackButton2 = "Attack2";
	}
	[SerializeField]
	public InputSettings input;

	[System.Serializable]
	public class OtherSettings {
		public float lookSpeed = 5.0f;
		public float lookDistance = 10.0f;
		public bool requireInputForTurn = true;
	}
	[SerializeField]
	public OtherSettings other;

	Camera mainCam;
	// Use this for initialization
	void Start () {
		attackManager = GetComponent<AttackManager> ();
		characterMove = GetComponent<CharacterMovement> ();
		mainCam = Camera.main;
	}

	// Update is called once per frame
	void Update () {
		if (characterMove) {
			characterMove.Animate (Input.GetAxis ("Vertical"), Input.GetAxis ("Horizontal"));

			if (Input.GetButtonDown ("Jump")) {
				//characterMove.Jump();
			}
			if (Input.GetButtonDown ("Attack1")) {
				attackManager.Attack();
			}
			if (Input.GetButtonDown ("Attack2")) {
				//characterMove.Attack2();
			}
		}
		if (mainCam) {
			if (other.requireInputForTurn) {
				if (Input.GetAxis (input.horizontalAxis) != 0 || Input.GetAxis (input.verticalAxis) != 0) {
					CharacterLook ();
				} else {
					CharacterLook ();
				}
			}
		}

	}
	//make the character look at a forward point from the camera
	void CharacterLook() {
		Transform mainCamT = mainCam.transform;
		Transform pivotT = mainCamT.parent;
		Vector3 pivotPos = pivotT.position;
		Vector3 lookTarget = pivotPos + (pivotT.forward * other.lookDistance);
		Vector3 thisPos = transform.position;
		Vector3 lookDir = (lookTarget - thisPos);
		Quaternion lookRot = Quaternion.LookRotation (lookDir);
		lookRot.x = 0;
		lookRot.z = 0;

		Quaternion newRotation = Quaternion.Lerp (transform.rotation, lookRot, Time.deltaTime * other.lookSpeed);
		transform.rotation = newRotation;
	}
}

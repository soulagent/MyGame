using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamSwitch : MonoBehaviour {

    CameraRig cameraRig;
    CharacterMove characterMove;
    
	// Use this for initialization
	void Start () {
        // [ For getting components from other gameobjects, remember to Find the Gameobject FIRST before GetComponent!! ]
        cameraRig = GameObject.Find("CamRig").GetComponent<CameraRig>();
        characterMove = GameObject.Find("Player").GetComponent<CharacterMove>();
	}

    void OnTriggerEnter(Collider other) {
        if(other.tag == "Indoor") {
            cameraRig.locCheck = CameraRig.LocCheck.Indoor;
            characterMove.canRun = false;
        }
    }

    private void OnTriggerExit(Collider other) {
        if(other.tag == "Indoor") {
            cameraRig.locCheck = CameraRig.LocCheck.Outdoor;
            characterMove.canRun = true;
        }
    }
}

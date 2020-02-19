using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamSwitch : MonoBehaviour {

    CameraRig cameraRig;
    
	// Use this for initialization
	void Start () {
        // [ For getting components from other gameobjects, remember to Find the Gameobject FIRST before GetComponent!! ]
        cameraRig = GameObject.Find("CamRig").GetComponent<CameraRig>();
	}

    void OnTriggerEnter(Collider other) {
        if(other.tag == "Indoor") {
            cameraRig.locCheck = CameraRig.LocCheck.Indoor;
        }
    }

    private void OnTriggerExit(Collider other) {
        if(other.tag == "Indoor") {
            cameraRig.locCheck = CameraRig.LocCheck.Outdoor;
        }
    }
}

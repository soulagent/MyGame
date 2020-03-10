using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAt : MonoBehaviour {

    public Transform CanvasUI;

	// Update is called once per frame
	void Update () {
        CanvasUI.LookAt(Camera.main.transform);
	}
}

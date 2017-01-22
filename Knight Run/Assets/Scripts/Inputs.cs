using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inputs : MonoBehaviour {
    #region Keyboard Inputs
    public bool LMB;
    public bool keyW;
    public bool keyS;
    public bool keyArrowUp;
    public bool keyArrowDown;
    public bool keyEnter;
    public bool escKey;
    public bool keySpace;
    #endregion
    #region Keyboard Inputs Initialization
    public string selectK;
    public string selectJ;
    public string wKey;
    public string sKey;
    public string arrowKeyDown;
    public string arrowKeyUp;
    public string enterKey;
    public string escKeyK;
    public string spaceKey;
    #endregion

    private void Awake() {

    }
    // Use this for initialization
    void Start () {
        selectK = "SelectK";
        selectJ = "SelectJ";
        wKey = "wKey";
        sKey = "sKey";
        arrowKeyDown = "downArrow";
        arrowKeyUp = "upArrow";
        enterKey = "enterKey";
        escKeyK = "escKeyK";
        spaceKey = "spaceKey";
    }
	
	// Update is called once per frame
	void Update () {
        HandleKeyboardInput();
        MenuLogic();
	}

    private void HandleKeyboardInput() {
        LMB = Input.GetButtonDown(selectK);
        keyW = Input.GetButtonDown(wKey);
        keyS = Input.GetButtonDown(sKey);
        keyArrowDown = Input.GetButtonDown(arrowKeyDown);
        keyArrowUp = Input.GetButtonDown(arrowKeyUp);
        keyEnter = Input.GetButtonDown(enterKey);
        escKey = Input.GetButtonDown(escKeyK);
        keySpace = Input.GetButtonDown(spaceKey);
    }

    public void MenuLogic() {

    }
}

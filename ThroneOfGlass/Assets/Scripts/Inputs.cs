using UnityEngine;
using System.Collections.Generic;

public class Inputs : MonoBehaviour {

    #region Keyboard and Mouse Inputs
    public bool keyW;
    public bool keyS;
    public bool keyA;
    public bool keyD;
    public bool mouseL;
    public bool mouseR;
    public bool shiftL;
    #endregion

    #region Keyboard and Mouse Initialization
    public string Key_W;
    public string Key_S;
    public string Key_A;
    public string Key_D;
    public string Mouse_L;
    public string Mouse_R;
    public string Shift_L;
    #endregion


    void Awake() {
        Key_W = "Key_W";
        Key_S = "Key_S";
        Key_A = "Key_A";
        Key_D = "Key_D";
        Mouse_L = "Mouse_L";
        Mouse_R = "Mouse_R";
        Shift_L = "Shift_L";
    }
    // Use this for initialization
    void Start () {

	}
	
	// Update is called once per frame
	void Update () {
        HandleKeyboardInput();
	}

    private void HandleKeyboardInput() {
        keyW = Input.GetButton(Key_W);
        keyS = Input.GetButton(Key_S);
        keyA = Input.GetButton(Key_A);
        keyD = Input.GetButton(Key_D);
        mouseL = Input.GetButton(Mouse_L);
        mouseR = Input.GetButton(Mouse_R);
        shiftL = Input.GetButton(Shift_L);
    }
}

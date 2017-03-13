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

    public Menu menu;

    void Awake() {
        menu.GetComponent<Menu>();
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
    // Use this for initialization
    void Start () {
        
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
        #region anykey
        if((Input.anyKeyDown)&&(menu.currentState == "anykey")) {
            menu.pressToStart();
        }
        #endregion
        #region Up
        if ((keyW)||(keyArrowUp)) {
            #region Menu
            if(menu.currentState == "training") {
                menu.MOStory();
            }
            else if (menu.currentState == "settings") {
                menu.MOTraining();
            }
            else if (menu.currentState == "quit") {
                menu.MOSettings();
            }
            #endregion
            #region Settings
            if(menu.currentState == "video") {
                menu.MOGame();
            }
            else if (menu.currentState == "audio") {
                menu.MOVideo();
            }
            else if (menu.currentState == "settingsback") {
                menu.MOAudio();
            }
            #endregion
        }
        #endregion
        #region Down
        else if((keyS)||(keyArrowDown)) {
            #region Menu
            if(menu.currentState == "story") {
                menu.MOTraining();
            }
            else if(menu.currentState == "training") {
                menu.MOSettings();
            }
            else if(menu.currentState == "settings") {
                menu.MOQuit();
            }
            #endregion
            #region Settings
            if(menu.currentState == "game") {
                menu.MOVideo();
            }
            else if(menu.currentState == "video") {
                menu.MOAudio();
            }
            else if(menu.currentState == "audio") {
                menu.MOSettingsBack();
            }
            #endregion
        }
        #endregion
        #region Enter
        else if (keyEnter) {
            #region Menu
            if(menu.currentState == "story") {
                menu.SelectStory();
            }
            else if (menu.currentState == "training") {
                menu.SelectTraining();
            }
            else if (menu.currentState == "settings") {
                menu.SelectSettings();
            }
            else if (menu.currentState == "quit") {
                menu.SelectQuit();
            }
            #endregion
            #region Settings
            if(menu.currentState == "settingsback") {
                menu.SelectSettingsBack();
            }
            #endregion
        }
        #endregion
    }
}

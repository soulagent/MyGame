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
    public string wKey;
    public string sKey;
    public string arrowKeyDown;
    public string arrowKeyUp;
    public string enterKey;
    public string escKeyK;
    public string spaceKey;
    #endregion

    #region Joystick Inputs
    public bool AButton;
    public bool JoystickUp;
    public bool JoystickDown;
    public bool JoypadUp;
    public bool JoypadDown;
    public bool BButton;
    #endregion
    #region Joystick Inputs Initialization
    public string aButton;
    public string joystickUpDown;
    public string joypadUpDown;
    public string bButton;
    #endregion

    public Menu menu;

    void Awake() {
        menu.GetComponent<Menu>();
        selectK = "SelectK";
        wKey = "wKey";
        sKey = "sKey";
        arrowKeyDown = "downArrow";
        arrowKeyUp = "upArrow";
        enterKey = "enterKey";
        escKeyK = "escKeyK";
        spaceKey = "spaceKey";

        aButton = "aButton";
        joystickUpDown = "JoyUpDown";
        joypadUpDown = "JoyButtonUpDown";
        bButton = "bButton";

    }
    // Use this for initialization
    void Start () {
        
    }
	
	// Update is called once per frame
	void Update () {
        HandleControllerInput();
        HandleKeyboardInput();
        MenuLogic();

        print(Input.GetAxis(joypadUpDown));
        print(Input.GetAxis(joystickUpDown));
        print(Input.GetButton(aButton));
        print(Input.GetButton(bButton));
        print(Input.GetButton(arrowKeyDown));
        print(Input.GetButton(arrowKeyUp));
    }
    public void HandleControllerInput() {
        AButton = Input.GetButtonDown(aButton);
        JoystickUp = Input.GetAxis(joystickUpDown) > 0;
        JoystickDown = Input.GetAxis(joystickUpDown) < 0;
        JoypadUp = Input.GetAxis(joypadUpDown) > 0;
        JoypadDown = Input.GetAxis(joypadUpDown) < 0;
        BButton = Input.GetButtonDown(bButton);
    }

    public void HandleKeyboardInput() {
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
        if(menu.currentMenuState == "TitleScreen") {
            if ((Input.anyKeyDown) && (menu.currentState == "anykey")) {
                menu.pressToStart();
            }
        }
        #endregion
        #region Up
		if ((keyW) || (keyArrowUp) || (JoystickUp) || (JoypadUp)) {
            #region Menu
            if (menu.currentMenuState == "MenuScreen") {
                if (menu.currentState == "training") {
                    menu.MOStory();
                }
                else if (menu.currentState == "settings") {
                    menu.MOTraining();
                }
                else if (menu.currentState == "quit") {
                    menu.MOSettings();
                }
            }
			#endregion
			#region Settings
            if(menu.currentMenuState == "SettingsScreen") {
                if (menu.currentState == "video") {
                    menu.MOGame();
                }
                else if (menu.currentState == "audio") {
                    menu.MOVideo();
                }
                else if (menu.currentState == "settingsback") {
                    menu.MOAudio();
                }
            }
            #endregion
            #region Video Resolution
            if(menu.currentMenuState == "SettingsVideoScreen") {
                if (menu.currentState == "1920") {
                    menu.MO1280();
                }
                else if (menu.currentState == "videoback") {
                    menu.MO1920();
                }
            }
            #endregion
            #region Quit
            if(menu.currentMenuState == "QuitScreen") {
                if(menu.currentState == "yes") {
                    menu.MOQuitNo();
                }
            }
            #endregion
        }
        #endregion
        #region Down
        else if ((keyS) || (keyArrowDown) || (JoystickDown) || (JoypadDown)) {
			#region Menu
            if (menu.currentMenuState == "MenuScreen") {
                if (menu.currentState == "story") {
                    menu.MOTraining();
                }
                else if (menu.currentState == "training") {
                    menu.MOSettings();
                }
                else if (menu.currentState == "settings") {
                    menu.MOQuit();
                }
            }
			#endregion
			#region Settings
            if(menu.currentMenuState == "SettingsScreen") {
                if (menu.currentState == "game") {
                    menu.MOVideo();
                }
                else if (menu.currentState == "video") {
                    menu.MOAudio();
                }
                else if (menu.currentState == "audio") {
                    menu.MOSettingsBack();
                }
            }
            #endregion
            #region Video Resolution
            if(menu.currentMenuState == "SettingsVideoScreen") {
                if (menu.currentState == "1280") {
                    menu.MO1920();
                }
                else if (menu.currentState == "1920") {
                    menu.MOVideoBack();
                }
            }
            #endregion
            #region Quit
            if(menu.currentMenuState == "QuitScreen") {
                if(menu.currentState == "no") {
                    menu.MOQuitYes();
                }
            }
            #endregion
        }
        #endregion
        #region Enter
        else if (keyEnter) {
            #region Menu
            if (menu.currentMenuState == "MenuScreen") {
                if (menu.currentState == "story") {
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
            }
			#endregion
			#region Settings
            if (menu.currentMenuState == "SettingsScreen") {
                if (menu.currentState == "settingsback") {
                    menu.SelectSettingsBack();
                }
                else if (menu.currentState == "video") {
                    menu.SelectVideo();
                }
            }
            #endregion
            #region Video Resolution
            if (menu.currentMenuState == "SettingsVideoScreen") {
                if (menu.currentState == "1920") {
                    menu.Select1920();
                }
                else if (menu.currentState == "1280") {
                    menu.Select1280();
                }
                else if (menu.currentState == "videoback") {
                    menu.SelectVideoBack();
                }
            }
            #endregion
            #region Quit
            if(menu.currentMenuState == "QuitScreen") {
                if(menu.currentState == "no") {
                    menu.SelectNo();
                }
                else if (menu.currentState == "yes") {
                    menu.SelectYes();
                }
            }
            #endregion
        }
        #endregion
        #region Esc Key
        else if (escKey) {
            if(menu.currentMenuState == "SettingsScreen") {
                if (menu.currentState == "game") {
                    menu.SelectSettingsBack();
                }
                else if (menu.currentState == "video") {
                    menu.SelectSettingsBack();
                }
                else if (menu.currentState == "audio") {
                    menu.SelectSettingsBack();
                }
                else if (menu.currentState == "settingsback") {
                    menu.SelectSettingsBack();
                }
            }
            if(menu.currentMenuState == "SettingsVideoScreen") {
                if (menu.currentState == "1920") {
                    menu.SelectVideoBack();
                }
                else if (menu.currentState == "1280") {
                    menu.SelectVideoBack();
                }
                else if (menu.currentState == "videoback") {
                    menu.SelectVideoBack();
                }
            }
            if(menu.currentMenuState == "QuitScreen") {
                if(menu.currentState == "no") {
                    menu.SelectQuitBack();
                }
                else if (menu.currentState == "yes") {
                    menu.SelectQuitBack();
                }
            }
		}
		#endregion
    }
}

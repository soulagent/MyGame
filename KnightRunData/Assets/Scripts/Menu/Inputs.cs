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
    public bool JoypadUp;
    public bool JoypadDown;
    public bool BButton;
    #endregion
    #region Joystick Inputs Initialization
    public string aButton;
    public string joypadUpDown;
    public string bButton;
    #endregion

    private bool joypadUpDownInUse;
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
        print(joypadUpDownInUse);
    }
    public void HandleControllerInput() {
        AButton = Input.GetButtonDown(aButton);
        JoypadUp = Input.GetAxis(joypadUpDown) == 1;
        JoypadDown = Input.GetAxis(joypadUpDown) == -1;
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
        #region Up Keyboard
		if ((keyW) || (keyArrowUp)) {
            #region Menu
            if (menu.currentMenuState == "MenuScreen") {
                if (menu.currentState == "training") {
                    menu.MOStory();
                    return;
                }
                else if (menu.currentState == "settings") {
                    menu.MOTraining();
                    return;
                }
                else if (menu.currentState == "quit") {
                    menu.MOSettings();
                    return;
                }
            }
			#endregion
			#region Settings
            if(menu.currentMenuState == "SettingsScreen") {
                if (menu.currentState == "video") {
                    menu.MOGame();
                    return;
                }
                else if (menu.currentState == "audio") {
                    menu.MOVideo();
                    return;
                }
                else if (menu.currentState == "settingsback") {
                    menu.MOAudio();
                    return;
                }
            }
            #endregion
            #region Video Resolution
            if(menu.currentMenuState == "SettingsVideoScreen") {
                if (menu.currentState == "1920") {
                    menu.MO1280();
                    return;
                }
                else if (menu.currentState == "videoback") {
                    menu.MO1920();
                    return;
                }
            }
            #endregion
            #region Quit
            if(menu.currentMenuState == "QuitScreen") {
                if(menu.currentState == "yes") {
                    menu.MOQuitNo();
                    return;
                }
            }
            #endregion
        }
        #endregion
        #region Down
        else if ((keyS) || (keyArrowDown)) {
			#region Menu
            if (menu.currentMenuState == "MenuScreen") {
                if (menu.currentState == "story") {
                    menu.MOTraining();
                    return;
                }
                else if (menu.currentState == "training") {
                    menu.MOSettings();
                    return;
                }
                else if (menu.currentState == "settings") {
                    menu.MOQuit();
                    return;
                }
            }
			#endregion
			#region Settings
            if(menu.currentMenuState == "SettingsScreen") {
                if (menu.currentState == "game") {
                    menu.MOVideo();
                    return;
                }
                else if (menu.currentState == "video") {
                    menu.MOAudio();
                    return;
                }
                else if (menu.currentState == "audio") {
                    menu.MOSettingsBack();
                    return;
                }
            }
            #endregion
            #region Video Resolution
            if(menu.currentMenuState == "SettingsVideoScreen") {
                if (menu.currentState == "1280") {
                    menu.MO1920();
                    return;
                }
                else if (menu.currentState == "1920") {
                    menu.MOVideoBack();
                    return;
                }
            }
            #endregion
            #region Quit
            if(menu.currentMenuState == "QuitScreen") {
                if(menu.currentState == "no") {
                    menu.MOQuitYes();
                    return;
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
        //*
        #region Up Controller
        if ((Input.GetAxisRaw(joypadUpDown) >= 0)) {
            if(joypadUpDownInUse == false) {
                joypadUpDownInUse = true;
                #region Menu
                if ((menu.currentMenuState == "MenuScreen") && (joypadUpDownInUse == true)) {
                    if (menu.currentState == "training") {
                        menu.MOStory();
                        joypadUpDownInUse = false;
                    }
                    else if (menu.currentState == "settings") {
                        menu.MOTraining();
                        joypadUpDownInUse = false;
                    }
                    else if (menu.currentState == "quit") {
                        menu.MOSettings();
                        joypadUpDownInUse = false;
                    }
                }
                #endregion
                #region Settings
                if (menu.currentMenuState == "SettingsScreen") {
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
                if (menu.currentMenuState == "SettingsVideoScreen") {
                    if (menu.currentState == "1920") {
                        menu.MO1280();
                    }
                    else if (menu.currentState == "videoback") {
                        menu.MO1920();
                    }
                }
                #endregion
                #region Quit
                if (menu.currentMenuState == "QuitScreen") {
                    if (menu.currentState == "yes") {
                        menu.MOQuitNo();
                    }
                }
                #endregion
            }
        }
        if ((Input.GetAxisRaw(joypadUpDown) == 0)) {
            joypadUpDownInUse = false;
        }
        #endregion
        #region Down
        if ((Input.GetAxisRaw(joypadUpDown) <= 0)) {
            if (joypadUpDownInUse == false) {
                joypadUpDownInUse = true;
                #region Menu
                if ((menu.currentMenuState == "MenuScreen") && (joypadUpDownInUse == true)) {
                    if (menu.currentState == "story") {
                        menu.MOTraining();
                        joypadUpDownInUse = false;
                    }
                    else if (menu.currentState == "training") {
                        menu.MOSettings();
                        joypadUpDownInUse = false;
                    }
                    else if (menu.currentState == "settings") {
                        menu.MOQuit();
                        joypadUpDownInUse = false;
                    }
                }
                #endregion
                #region Settings
                if (menu.currentMenuState == "SettingsScreen") {
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
                if (menu.currentMenuState == "SettingsVideoScreen") {
                    if (menu.currentState == "1280") {
                        menu.MO1920();
                    }
                    else if (menu.currentState == "1920") {
                        menu.MOVideoBack();
                    }
                }
                #endregion
                #region Quit
                if (menu.currentMenuState == "QuitScreen") {
                    if (menu.currentState == "no") {
                        menu.MOQuitYes();
                    }
                }
                #endregion
            }
        }
        if ((Input.GetAxisRaw(joypadUpDown) == 0)) {
            joypadUpDownInUse = false;
        }
        #endregion
        //*/
    }
}

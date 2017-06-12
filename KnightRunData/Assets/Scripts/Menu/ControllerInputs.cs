using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControllerInputs : MonoBehaviour {
    #region Controller Inputs Initialization
    private string aButton;
    private string bButton;
    private string dpadUpDown;
    private string joystickUpDown;
    #endregion

    public Menu menu;
    private bool dpadAxisInUse;
    private bool joystickAxisInUse;

    private void Awake() {
        menu.GetComponent<Menu>();
        aButton = "aButton";
        bButton = "bButton";
        dpadUpDown = "JoyButtonUpDown";
        joystickUpDown = "JoyUpDown";
    } 

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        MenuLogic();
    }

    public void MenuLogic () {
        #region anykey
        if (menu.currentMenuState == "TitleScreen") {
            if ((Input.anyKeyDown) && (menu.currentState == "anykey")) {
                menu.pressToStart();
            }
        }
        #endregion
        #region aButton
        if (Input.GetButtonDown(aButton)) {
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
            if (menu.currentMenuState == "QuitScreen") {
                if (menu.currentState == "no") {
                    menu.SelectNo();
                }
                else if (menu.currentState == "yes") {
                    menu.SelectYes();
                }
            }
            #endregion
        }
        #endregion
        #region bButton
        if (Input.GetButtonDown(bButton)) {
            if (menu.currentMenuState == "SettingsScreen") {
                if ((menu.currentState == "game") || (menu.currentState == "video") || (menu.currentState == "audio") || (menu.currentState == "settingsback")) {
                    menu.SelectSettingsBack();
                }
            }
            if (menu.currentMenuState == "SettingsVideoScreen") {
                if ((menu.currentState == "1920") || (menu.currentState == "1280") || (menu.currentState == "videoback")) {
                    menu.SelectVideoBack();
                }
            }
            if (menu.currentMenuState == "QuitScreen") {
                if ((menu.currentState == "no") || (menu.currentState == "yes")) {
                    menu.SelectQuitBack();
                }
            }
        }
        #endregion
        if (Input.GetAxisRaw(dpadUpDown) != 0) {
            if (dpadAxisInUse == false) {
                #region Up 
                if ((Input.GetAxisRaw(dpadUpDown) > 0)) {
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
                #endregion
                #region Down
                if ((Input.GetAxisRaw(dpadUpDown) < 0)) {
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
                #endregion
                dpadAxisInUse = true;
            }
        }
        if(Input.GetAxisRaw(dpadUpDown) == 0) {
            dpadAxisInUse = false;
        }

        if(Input.GetAxisRaw(joystickUpDown) != 0) {
            if(joystickAxisInUse == false) {
                #region Up 
                if ((Input.GetAxisRaw(joystickUpDown) < 0)) {
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
                #endregion
                #region Down
                if ((Input.GetAxisRaw(joystickUpDown) > 0)) {
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
                #endregion
                joystickAxisInUse = true;
            }
        }
        if(Input.GetAxisRaw(joystickUpDown) == 0) {
            joystickAxisInUse = false;
        }
    }
}

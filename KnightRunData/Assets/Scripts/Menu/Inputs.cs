using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inputs : MonoBehaviour {
    #region Keyboard Inputs Initialization
    private string wKey;
    private string sKey;
    private string arrowKeyDown;
    private string arrowKeyUp;
    private string enterKey;
    private string escKeyK;
    #endregion

    public Menu menu;

    void Awake() {
        menu.GetComponent<Menu>();
        wKey = "wKey";
        sKey = "sKey";
        arrowKeyDown = "downArrow";
        arrowKeyUp = "upArrow";
        enterKey = "enterKey";
        escKeyK = "escKeyK";
    }

	void Update () {
        MenuLogic();
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
		if (Input.GetButtonDown(wKey) || Input.GetButtonDown(arrowKeyUp)) {
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
            if (menu.currentMenuState == "QuitScreen") {
                if (menu.currentState == "yes") {
                    menu.MOQuitNo();
                }
            }
            #endregion
        }
        #endregion
        #region Down
        else if (Input.GetButtonDown(sKey) || Input.GetButtonDown(arrowKeyDown)) {
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
        #region Enter
        else if (Input.GetButtonDown(enterKey)) {
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
        else if (Input.GetButtonDown(escKeyK)) {
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
    }
}

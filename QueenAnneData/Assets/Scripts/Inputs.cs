using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inputs : MonoBehaviour {

    public Menu menuScript;

    #region KB Input
    private bool up;
    private bool down;
    private bool enter;
    #endregion
    #region KB Initialization
    private string upKey;
    private string downKey;
    private string enterKey;
    #endregion

    void Awake() {
        menuScript = GetComponent<Menu>();
        upKey = "upKey";
        downKey = "downKey";
        enterKey = "enterKey";
    }

    void Update() {
        HandleKBInput();
        MenuLogic();
    }

    private void HandleKBInput() {
        up = Input.GetButtonDown(upKey);
        down = Input.GetButtonDown(downKey);
        enter = Input.GetButton(enterKey);
    }

    public void MenuLogic() {
        #region up handler
        if (up) {
            #region MenuScreen
            if(menuScript.currentMenuState == ("MenuScreen")) {
                if (menuScript.currentState == ("options")) {
                    menuScript.MOPlay();
                }
                else if (menuScript.currentState == ("credits")) {
                    menuScript.MOOptions();
                }
                else if (menuScript.currentState == ("quit")) {
                    menuScript.MOCredits();
                }
            }
            #endregion
            #region QuitScreen
            if (menuScript.currentMenuState == ("QuitScreen")) {
                if(menuScript.currentState == ("yes")) {
                    menuScript.MONo();
                }
            }
            #endregion
        }
        #endregion
        #region down handler
        if (down) {
            #region MenuScreen
            if(menuScript.currentMenuState == ("MenuScreen")) {
                if (menuScript.currentState == ("play")) {
                    menuScript.MOOptions();
                }
                else if (menuScript.currentState == ("options")) {
                    menuScript.MOCredits();
                }
                else if (menuScript.currentState == ("credits")) {
                    menuScript.MOQuit();
                }
            }
            #endregion
            #region QuitScreen
            if (menuScript.currentMenuState == ("QuitScreen")) {
                if (menuScript.currentState == ("no")) {
                    menuScript.MOYes();
                }
            }
            #endregion
        }
        #endregion
        #region enter handler
        if(enter) {
            #region MenuScreen
            if (menuScript.currentMenuState == ("MenuScreen")) {
                if(menuScript.currentState == ("options")) {
                    menuScript.SelectQuit();
                }
                if(menuScript.currentState == ("credits")) {
                    menuScript.SelectQuit();
                }
                else if(menuScript.currentState == ("quit")) {
                    menuScript.SelectQuit();
                }
            }
            #endregion
            #region QuitScreen
            if(menuScript.currentMenuState == ("QuitScreen")) {
                if(menuScript.currentState == ("no")) {
                    menuScript.SelectQuitNo();
                }
                else if(menuScript.currentState == ("yes")) {
                    menuScript.SelectQuitYes();
                }
            }
            #endregion
        }
        #endregion
        #region misc handler
        if ((Input.anyKeyDown) && (menuScript.currentState == "anykey")) {
            menuScript.pressToStart();
            menuScript.descriptionText.text = "Play the game";
        }
        #endregion
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inputs : MonoBehaviour {

    public Menu menuScript;

    #region KB Input
    public bool up;
    public bool down;
    public bool enter;
    #endregion
    #region KB Initialization
    public string upKey;
    public string downKey;
    public string enterKey;
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
        enter = Input.GetButtonDown(enterKey);
    }

    public void MenuLogic() {
        #region up handler
        if (up) {
            #region MenuScreen
            if (menuScript.currentState == ("menu:options")) {
                menuScript.MOPlay();
            }
            else if (menuScript.currentState == ("menu:credits")) {
                menuScript.MOOptions();
            }
            else if (menuScript.currentState == ("menu:quit")) {
                menuScript.MOCredits();
            }
            #endregion
            #region QuitScreen
            if (menuScript.currentState == ("quit:yes")) {
                menuScript.MONo();
            }
            #endregion
        }
        #endregion
        #region down handler
        if (down) {
            #region MenuScreen
            if (menuScript.currentState == ("menu:play")) {
                menuScript.MOOptions();
            }
            else if (menuScript.currentState == ("menu:options")) {
                menuScript.MOCredits();
            }
            else if (menuScript.currentState == ("menu:credits")) {
                menuScript.MOQuit();
            }
            #endregion
            #region QuitScreen
            if (menuScript.currentState == ("quit:no")) {
                menuScript.MOYes();
            }
            #endregion
        }
        #endregion
        #region enter handler
        if(enter)  {
            #region MenuScreen
            if (menuScript.currentState == ("menu:quit")) {
                menuScript.SelectQuit();
            }
            #endregion
            #region QuitScreen
            if (menuScript.currentState == ("quit:no")) {
                menuScript.SelectQuitNo();
            }
            else if (menuScript.currentState == ("quit:yes")) {
                menuScript.SelectQuitYes();
            }
            #endregion
        }
        #endregion
        #region misc handler
        if ((menuScript.currentState == "anykey")&& (Input.anyKeyDown)) {
            menuScript.PressToStart();
            menuScript.descriptionText.text = "Play the game";
        }
        #endregion
    }
}

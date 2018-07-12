using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour {
    #region Keyboard Input Initialization
    private string wKey;
    private string sKey;
    private string arrowKeyUp;
    private string arrowKeyDown;
    private string enterKey;
    private string escKey;
    #endregion

    public string currentState, currentMenuState;

    [System.Serializable]
    public class StartScreen {
        public GameObject StartCanvas;
        public GameObject PressToStart;
    }
    public StartScreen startScreen;

    [System.Serializable]
    public class MenuScreen {
        public GameObject MenuCanvas;
        public GameObject PlayBtn, OptionsBtn, ExitBtn;
        public GameObject SelectPlay, SelectOptions, SelectExit;
    }
    public MenuScreen menuScreen;

    void Awake() {
        wKey = "wKey";
        sKey = "sKey";
        arrowKeyUp = "arrowKeyUp";
        arrowKeyDown = "arrowKeyDown";
        enterKey = "enterKey";
        escKey = "escKey";
    }

    void Start() {
        currentState = "anykey";
        currentMenuState = "StartScreen";

        #region StartScreen
        startScreen.StartCanvas.SetActive(true);
        startScreen.PressToStart.SetActive(true);
        #endregion

        menuScreen.MenuCanvas.SetActive(false);
    }

    public void pressToStart() {
        startScreen.StartCanvas.SetActive(false);
        menuScreen.MenuCanvas.SetActive(true);
        menuScreen.SelectPlay.SetActive(true);

        currentState = "play";
        currentMenuState = "MenuScreen";
    }

    public void MenuLogic() {
        #region StartScreen
        if (currentMenuState == "StartScreen") {
            if((Input.anyKeyDown) && (currentState == "anykey")) {
                pressToStart();
            }
        }
        #endregion
        #region Up
        if ((Input.GetButtonDown(wKey)) || (Input.GetButtonDown(arrowKeyUp))) {
            if (currentMenuState == "MenuScreen") {
                if(currentState == "options") {
                    MOPlay();
                }
                if (currentState == "exit") {
                    MOOptions();
                }
            }
        }
        #endregion
        #region Down
        if ((Input.GetButtonDown(sKey)) || ((Input.GetButtonDown(arrowKeyDown)))) {
            if(currentMenuState == "MenuScreen") {
                if(currentState == "play") {
                    MOOptions();
                }
                if(currentState == "options") {
                    MOExit();
                }
            }
        }
        #endregion
    }

    public void MOPlay() {
        menuScreen.SelectPlay.SetActive(true);
        if (currentState == "options") {
            menuScreen.SelectOptions.SetActive(false);
            currentState = "play";
        }
    }
    public void MOOptions() {
        menuScreen.SelectOptions.SetActive(true);
        if (currentState == "play") {
            menuScreen.SelectPlay.SetActive(false);
            currentState = "options";
        }
        if (currentState == "exit") {
            menuScreen.SelectExit.SetActive(false);
            currentState = "options";
        }
    }
    public void MOExit() {
        menuScreen.SelectExit.SetActive(true);
        if (currentState == "options") {
            menuScreen.SelectOptions.SetActive(false);
            currentState = "exit";
        }
        if (currentState == "play") {
            menuScreen.SelectPlay.SetActive(false);
            currentState = "exit";
        }
    }
}

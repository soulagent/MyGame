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
    //private string enterKey;
    //private string escKey;
    #endregion

    public string currentState, currentMenuState;
    public Text descriptionText;

    [System.Serializable]
    public class StartScreen {
        public GameObject StartCanvas;
        public GameObject PressToStart;
    }
    public StartScreen startScreen;

    [System.Serializable]
    public class MenuScreen {
        public GameObject MenuCanvas;
        public GameObject PlayBtn, OptionsBtn, CreditsBtn, ExitBtn;
        public GameObject SelectPlay, SelectOptions, SelectCredits, SelectExit;
    }
    public MenuScreen menuScreen;

    void Awake() {
        wKey = "wKey";
        sKey = "sKey";
        arrowKeyUp = "arrowKeyUp";
        arrowKeyDown = "arrowKeyDown";
        //enterKey = "enterKey";
        //escKey = "escKey";

        descriptionText.text = "Play the game";
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
                if (currentState == "credits") {
                    MOOptions();
                }
                if (currentState == "exit") {
                    MOCredits();
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
                    MOCredits();
                }
                if(currentState == "credits") {
                    MOExit();
                }
            }
        }
        #endregion
    }

    public void MOPlay() {
        menuScreen.SelectPlay.SetActive(true);
        menuScreen.PlayBtn.SetActive(false);
        if (currentState == "options") {
            menuScreen.SelectOptions.SetActive(false);
            menuScreen.OptionsBtn.SetActive(true);
        }
        if(currentState == "credits") {
            menuScreen.SelectCredits.SetActive(false);
            menuScreen.CreditsBtn.SetActive(true);
        }
        if(currentState == "exit") {
            menuScreen.SelectExit.SetActive(false);
            menuScreen.ExitBtn.SetActive(true);
        }
        currentState = "play";
        descriptionText.text = "Play the game";
    }
    public void MOOptions() {
        menuScreen.SelectOptions.SetActive(true);
        menuScreen.OptionsBtn.SetActive(false);
        if (currentState == "play") {
            menuScreen.SelectPlay.SetActive(false);
            menuScreen.PlayBtn.SetActive(true);
        }
        if(currentState == "credits") {
            menuScreen.SelectCredits.SetActive(false);
            menuScreen.CreditsBtn.SetActive(true);
        }
        if (currentState == "exit") {
            menuScreen.SelectExit.SetActive(false);
            menuScreen.ExitBtn.SetActive(true);
        }
        currentState = "options";
        descriptionText.text = "Adjust the gameplay, video and audio settings";
    }
    public void MOCredits() {
        menuScreen.SelectCredits.SetActive(true);
        menuScreen.CreditsBtn.SetActive(false);
        if (currentState == "play") {
            menuScreen.SelectPlay.SetActive(false);
            menuScreen.PlayBtn.SetActive(true);
        }
        if (currentState == "options") {
            menuScreen.SelectOptions.SetActive(false);
            menuScreen.OptionsBtn.SetActive(true);
        }
        if (currentState == "exit") {
            menuScreen.SelectExit.SetActive(false);
            menuScreen.ExitBtn.SetActive(true);
        }
        currentState = "credits";
        descriptionText.text = "Shows the credits";
    }
    public void MOExit() {
        menuScreen.SelectExit.SetActive(true);
        menuScreen.ExitBtn.SetActive(false);
        if (currentState == "play") {
            menuScreen.SelectPlay.SetActive(false);
            menuScreen.PlayBtn.SetActive(true);
        }
        if (currentState == "options") {
            menuScreen.SelectOptions.SetActive(false);
            menuScreen.OptionsBtn.SetActive(true);
        }
        if(currentState == "credits") {
            menuScreen.SelectCredits.SetActive(false);
            menuScreen.CreditsBtn.SetActive(true);
        }
        currentState = "exit";
        descriptionText.text = "Exit the game";
    }
}

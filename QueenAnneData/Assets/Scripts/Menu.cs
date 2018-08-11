using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour {

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

    [System.Serializable]
    public class QuitScreen {
        public GameObject QuitCanvas;
        public GameObject NoBtn, YesBtn;
        public GameObject SelectNo, SelectYes;
    }
    public QuitScreen quitScreen;

    [System.Serializable]
    public class InputManager {
        public bool up, down, enter;
        public string upKey, downKey, enterKey;
    }
    [HideInInspector]
    public InputManager inputs;

    void Awake() {
        descriptionText.text = "";
        inputs.upKey = "upKey";
        inputs.downKey = "downKey";
        inputs.enterKey = "enterKey";
    }

    void Start() {
        currentState = "anykey";
        currentMenuState = "anyKeyScreen";

        #region StartScreen
        startScreen.StartCanvas.SetActive(true);
        startScreen.PressToStart.SetActive(true);
        #endregion

        menuScreen.MenuCanvas.SetActive(false);
        quitScreen.QuitCanvas.SetActive(false);
    }

    void Update() {
        HandleKBInput();
        MenuLogic();
        print(currentState);
    }

    private void HandleKBInput() {
        inputs.up = Input.GetButtonDown(inputs.upKey);
        inputs.down = Input.GetButtonDown(inputs.downKey);
        inputs.enter = Input.GetButtonDown(inputs.enterKey);
    }

    public void MenuLogic() {
        #region misc handler
        if ((currentState == "anykey") && (Input.anyKeyDown)) {
            PressToStart();
            currentMenuState = "MenuScreen";
            descriptionText.text = "Play the game";
        }
        #endregion
        #region Up Handler
        if (inputs.up) {
            #region MenuScreen
            if (currentMenuState == ("MenuScreen")) {
                if (currentState == ("menu:options")) {
                    MOPlay();
                }
                else if (currentState == ("menu:credits")) {
                    MOOptions();
                }
                else if (currentState == ("menu:quit")) {
                    MOCredits();
                }
            }
            #endregion
            #region QuitScreen
            if (currentMenuState == ("QuitScreen")) {
                if (currentState == ("quit:yes")) {
                    MONo();
                }
            }
            #endregion
        }
        #endregion
        #region Down Handler
        if (inputs.down) {
            #region MenuScreen
            if (currentMenuState == ("MenuScreen")) {
                if (currentState == ("menu:play")) {
                    MOOptions();
                }
                else if (currentState == ("menu:options")) {
                    MOCredits();
                }
                else if (currentState == ("menu:credits")) {
                    MOQuit();
                }
            } 
            #endregion
            #region QuitScreen
            if (currentMenuState == ("QuitScreen")) {
                if (currentState == ("quit:no")) {
                    MOYes();
                }
            }
            #endregion
        }
        #endregion
        #region Enter Handler
        if (inputs.enter) {
            #region MenuScreen
            if (currentMenuState == ("MenuScreen")) {
                if (currentState == ("menu:quit")) {
                    SelectQuit();
                }
            }
            #endregion
            #region QuitScreen
            if (currentMenuState == ("QuitScreen")) {
                if (currentState == ("quit:no")) {
                    SelectQuitNo();
                }
                else if ((currentState == ("quit:yes"))) {
                    SelectQuitYes();
                }
            }
            #endregion
        }
        #endregion
    }

    public void PressToStart() {
        startScreen.StartCanvas.SetActive(false);
        menuScreen.MenuCanvas.SetActive(true);
        menuScreen.SelectPlay.SetActive(true);

        currentState = "menu:play";
        descriptionText.text = "Play the game";
    }

    #region Menu MouseOvers
    public void MOPlay() {
        menuScreen.SelectPlay.SetActive(true);
        menuScreen.PlayBtn.SetActive(false);
        if (currentState == "menu:options") {
            menuScreen.SelectOptions.SetActive(false);
            menuScreen.OptionsBtn.SetActive(true);
        }
        if(currentState == "menu:credits") {
            menuScreen.SelectCredits.SetActive(false);
            menuScreen.CreditsBtn.SetActive(true);
        }
        if(currentState == "menu:quit") {
            menuScreen.SelectExit.SetActive(false);
            menuScreen.ExitBtn.SetActive(true);
        }
        currentState = "menu:play";
        descriptionText.text = "Play the game";
    }
    public void MOOptions() {
        menuScreen.SelectOptions.SetActive(true);
        menuScreen.OptionsBtn.SetActive(false);
        if (currentState == "menu:play") {
            menuScreen.SelectPlay.SetActive(false);
            menuScreen.PlayBtn.SetActive(true);
        }
        if(currentState == "menu:credits") {
            menuScreen.SelectCredits.SetActive(false);
            menuScreen.CreditsBtn.SetActive(true);
        }
        if (currentState == "menu:quit") {
            menuScreen.SelectExit.SetActive(false);
            menuScreen.ExitBtn.SetActive(true);
        }
        currentState = "menu:options";
        descriptionText.text = "Adjust the gameplay, video and audio settings";
    }
    public void MOCredits() {
        menuScreen.SelectCredits.SetActive(true);
        menuScreen.CreditsBtn.SetActive(false);
        if (currentState == "menu:play") {
            menuScreen.SelectPlay.SetActive(false);
            menuScreen.PlayBtn.SetActive(true);
        }
        if (currentState == "menu:options") {
            menuScreen.SelectOptions.SetActive(false);
            menuScreen.OptionsBtn.SetActive(true);
        }
        if (currentState == "menu:quit") {
            menuScreen.SelectExit.SetActive(false);
            menuScreen.ExitBtn.SetActive(true);
        }
        currentState = "menu:credits";
        descriptionText.text = "Shows the credits";
    }
    public void MOQuit() {
        menuScreen.SelectExit.SetActive(true);
        menuScreen.ExitBtn.SetActive(false);
        if (currentState == "menu:play") {
            menuScreen.SelectPlay.SetActive(false);
            menuScreen.PlayBtn.SetActive(true);
        }
        if (currentState == "menu:options") {
            menuScreen.SelectOptions.SetActive(false);
            menuScreen.OptionsBtn.SetActive(true);
        }
        if(currentState == "menu:credits") {
            menuScreen.SelectCredits.SetActive(false);
            menuScreen.CreditsBtn.SetActive(true);
        }
        currentState = "menu:quit";
        descriptionText.text = "Exit the game";
    }
    #endregion

    #region Quit MouseOvers
    public void MONo() {
        quitScreen.SelectNo.SetActive(true);
        quitScreen.NoBtn.SetActive(false);
        if (currentState == "quit:yes") {
            quitScreen.SelectYes.SetActive(false);
            quitScreen.YesBtn.SetActive(true);
        }
        currentState = "quit:no";
    }
    public void MOYes() {
        quitScreen.SelectYes.SetActive(true);
        quitScreen.YesBtn.SetActive(false);
        if (currentState == "quit:no") {
            quitScreen.SelectNo.SetActive(false);
            quitScreen.NoBtn.SetActive(true);
        }
        currentState = "quit:yes";
    }
    #endregion

    #region Menu Selects
    public void SelectQuit() {
        menuScreen.MenuCanvas.SetActive(false);
        quitScreen.QuitCanvas.SetActive(true);

        //*
        quitScreen.SelectNo.SetActive(true);
        quitScreen.SelectYes.SetActive(false);
        quitScreen.YesBtn.SetActive(true);
        quitScreen.NoBtn.SetActive(false);

        StartCoroutine(BufferTime());
        //*/
        /*
        quitScreen.SelectNo.SetActive(false);
        quitScreen.SelectYes.SetActive(true);
        quitScreen.YesBtn.SetActive(false);
        quitScreen.NoBtn.SetActive(true); 
        //*/
        //currentMenuState = "QuitScreen";
        //currentState = "quit:no";
        descriptionText.text = "";
    }
    #endregion

    void SetQuit() {
        currentMenuState = "QuitScreen";
        currentState = "quit:no";
    }

    #region Quit Selects
    public void SelectQuitNo() {
        menuScreen.MenuCanvas.SetActive(true);
        quitScreen.QuitCanvas.SetActive(false);

        currentState = "menu:quit";
        currentMenuState = "MenuScreen";
        descriptionText.text = "Exit the game";
    }

    public void SelectQuitYes() {
        Application.Quit();
        print("game quited");
    }
    #endregion

    IEnumerator BufferTime() {
        yield return new WaitForSeconds(0.1f);
        if(currentMenuState == ("MenuScreen")) {
            SetQuit();
        }
    }
}
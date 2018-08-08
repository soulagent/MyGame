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

    void Awake() {
        descriptionText.text = "";
    }

    void Start() {
        currentState = "anykey";
        currentMenuState = "StartScreen";

        #region StartScreen
        startScreen.StartCanvas.SetActive(true);
        startScreen.PressToStart.SetActive(true);
        #endregion

        menuScreen.MenuCanvas.SetActive(false);
        quitScreen.QuitCanvas.SetActive(false);
    }

    public void pressToStart() {
        startScreen.StartCanvas.SetActive(false);
        menuScreen.MenuCanvas.SetActive(true);
        menuScreen.SelectPlay.SetActive(true);

        currentState = "play";
        currentMenuState = "MenuScreen";
        descriptionText.text = "Play the game";
    }

    #region Menu MouseOvers
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
        if(currentState == "quit") {
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
        if (currentState == "quit") {
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
        if (currentState == "quit") {
            menuScreen.SelectExit.SetActive(false);
            menuScreen.ExitBtn.SetActive(true);
        }
        currentState = "credits";
        descriptionText.text = "Shows the credits";
    }
    public void MOQuit() {
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
        currentState = "quit";
        descriptionText.text = "Exit the game";
    }
    #endregion

    #region Quit MouseOvers
    public void MONo() {
        if(currentMenuState == "QuitScreen") {
            quitScreen.SelectNo.SetActive(true);
            quitScreen.NoBtn.SetActive(false);
            if (currentState == "yes") {
                quitScreen.SelectYes.SetActive(false);
                quitScreen.YesBtn.SetActive(true);
            }
            currentState = "no";
        }
    }
    public void MOYes() {
        if(currentMenuState == "QuitScreen") {
            quitScreen.SelectYes.SetActive(true);
            quitScreen.YesBtn.SetActive(false);
            if (currentState == "no") {
                quitScreen.SelectNo.SetActive(false);
                quitScreen.NoBtn.SetActive(true);
            }
            currentState = "yes";
        }
    }
    #endregion

    #region Menu Selects
    public void SelectQuit() {
        menuScreen.MenuCanvas.SetActive(false);
        quitScreen.QuitCanvas.SetActive(true);
        
        quitScreen.SelectNo.SetActive(true);
        quitScreen.SelectYes.SetActive(false);
        quitScreen.YesBtn.SetActive(true);
        quitScreen.NoBtn.SetActive(false);

        currentMenuState = "QuitScreen";
        currentState = "no";

        descriptionText.text = "";
    }
    #endregion

    #region Quit Selects
    public void SelectQuitNo() {
        currentMenuState = "MenuScreen";
        currentState = "quit";
        menuScreen.MenuCanvas.SetActive(true);
        quitScreen.QuitCanvas.SetActive(false);

        descriptionText.text = "Exit the game";
    }

    public void SelectQuitYes() {
        Application.Quit();
    }
    #endregion
}
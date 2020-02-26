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
        public GameObject ParticleSystem;
        public GameObject PressToStart;
        public GameObject MenuBackground;
        public GameObject StartBackground;
        public GameObject ButtonBorder;
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
    public class OptionsScreen {
        public GameObject OptionsCanvas;
        public GameObject GameplayBtn, AudioBtn, VideoBtn, OptionsBackBtn;
        public GameObject SelectGameplay, SelectAudio, SelectVideo, SelectOptionsBack;
    }
    public OptionsScreen optionsScreen;

    [System.Serializable]
    public class InputManager {
        public bool up, down, enter;
        public string upKey, downKey, enterKey;
    }
    [HideInInspector]
    public InputManager inputs;

    void Awake() {
        descriptionText.text = "[ QueenAnne_v.1.1.6 Test Version ]";
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
        startScreen.MenuBackground.SetActive(false);
        startScreen.ButtonBorder.SetActive(true);
        startScreen.StartBackground.SetActive(true);
        startScreen.ParticleSystem.SetActive(true);
        #endregion

        menuScreen.MenuCanvas.SetActive(false);
        quitScreen.QuitCanvas.SetActive(false);
        optionsScreen.OptionsCanvas.SetActive(false);
    }

    void Update() {
        HandleKBInput();
        MenuLogic();
        print("CurrentState: " + currentState);
        print("CurrentMenuState: " + currentMenuState);
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
            #region OptionScreen
            if (currentMenuState == ("OptionsScreen")) {
                if (currentState == ("options:video")) {
                    MOGameplay();
                }
                else if (currentState == ("options:audio")) {
                    MOVideo();
                }
                else if (currentState == ("options:back")) {
                    MOAudio();
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
            #region OptionsScreen
            if (currentMenuState == ("OptionsScreen")) {
                if (currentState == ("options:gameplay")) {
                    MOVideo();
                }
                else if (currentState == ("options:video")) {
                    MOAudio();
                }
                else if (currentState == ("options:audio")) {
                    MOOptionsBack();
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
                else if (currentState == ("menu:options")) {
                    SelectOptions();
                }
                else if (currentState == ("menu:play")) {
                    SelectPlay();
                }
            } // currentMenuState == "MenuScreen"
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
            #region OptionsScreen
            if (currentMenuState == ("OptionsScreen")) {
                if(currentState == ("options:back")) {
                    SelectOptionsBack();
                }
            }
            #endregion
        } // if (inputs.enter)
        #endregion
    } // MenuLogic()

    public void PressToStart() {
        startScreen.StartCanvas.SetActive(false);
        startScreen.ButtonBorder.SetActive(false);
        startScreen.StartBackground.SetActive(false);
        startScreen.MenuBackground.SetActive(true);
        startScreen.ParticleSystem.SetActive(false);
        menuScreen.MenuCanvas.SetActive(true);
        menuScreen.SelectPlay.SetActive(true);

        StartCoroutine(BufferTimeStart());

        //currentMenuState = "MenuScreen";
        //currentState = "menu:play";
        descriptionText.text = "Play the game";
    }

    #region MouseOver Handlers
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
    #region Options MouseOvers
    public void MOGameplay() {
        optionsScreen.SelectGameplay.SetActive(true);
        optionsScreen.GameplayBtn.SetActive(false);
        if (currentState == "options:video") {
            optionsScreen.SelectVideo.SetActive(false);
            optionsScreen.VideoBtn.SetActive(true);
        }
        if (currentState == "options:audio") {
            optionsScreen.SelectAudio.SetActive(false);
            optionsScreen.AudioBtn.SetActive(true);
        }
        if (currentState == "options:back") {
            optionsScreen.SelectOptionsBack.SetActive(false);
            optionsScreen.OptionsBackBtn.SetActive(true);
        }
        currentState = "options:gameplay";
        descriptionText.text = "Adjusts the Gameplay settings";
    }
    public void MOVideo() {
        optionsScreen.SelectVideo.SetActive(true);
        optionsScreen.VideoBtn.SetActive(false);
        if (currentState == "options:gameplay") {
            optionsScreen.SelectGameplay.SetActive(false);
            optionsScreen.GameplayBtn.SetActive(true);
        }
        if (currentState == "options:audio") {
            optionsScreen.SelectAudio.SetActive(false);
            optionsScreen.AudioBtn.SetActive(true);
        }
        if (currentState == "options:back") {
            optionsScreen.SelectOptionsBack.SetActive(false);
            optionsScreen.OptionsBackBtn.SetActive(true);
        }
        currentState = "options:video";
        descriptionText.text = "Adjusts the Video Settings";
    }
    public void MOAudio() {
        optionsScreen.SelectAudio.SetActive(true);
        optionsScreen.AudioBtn.SetActive(false);
        if (currentState == "options:gameplay") {
            optionsScreen.SelectGameplay.SetActive(false);
            optionsScreen.GameplayBtn.SetActive(true);
        }
        if (currentState == "options:video") {
            optionsScreen.SelectVideo.SetActive(false);
            optionsScreen.VideoBtn.SetActive(true);
        }
        if (currentState == "options:back") {
            optionsScreen.SelectOptionsBack.SetActive(false);
            optionsScreen.OptionsBackBtn.SetActive(true);
        }
        currentState = "options:audio";
        descriptionText.text = "Adjusts the Audio Settings";
    }
    public void MOOptionsBack() {
        optionsScreen.SelectOptionsBack.SetActive(true);
        optionsScreen.OptionsBackBtn.SetActive(false);
        if (currentState == "options:gameplay") {
            optionsScreen.SelectGameplay.SetActive(false);
            optionsScreen.GameplayBtn.SetActive(true);
        }
        if (currentState == "options:video") {
            optionsScreen.SelectVideo.SetActive(false);
            optionsScreen.VideoBtn.SetActive(true);
        }
        if (currentState == "options:audio") {
            optionsScreen.SelectAudio.SetActive(false);
            optionsScreen.AudioBtn.SetActive(true);
        }
        currentState = "options:back";
        descriptionText.text = "Return to Main Menu";
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
    #endregion

    #region Select Handlers
    #region Menu Selects
    public void SelectPlay() {
        SceneManager.LoadScene("QueenChambers");
    }
    public void SelectQuit() {
        menuScreen.MenuCanvas.SetActive(false);
        quitScreen.QuitCanvas.SetActive(true);

        //*
        quitScreen.SelectNo.SetActive(true);
        quitScreen.SelectYes.SetActive(false);
        quitScreen.YesBtn.SetActive(true);
        quitScreen.NoBtn.SetActive(false);

        StartCoroutine(BufferTimeQuit());
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
    } //void SelectQuit
    public void SelectOptions() {
        menuScreen.MenuCanvas.SetActive(false);
        optionsScreen.OptionsCanvas.SetActive(true);

        optionsScreen.GameplayBtn.SetActive(false);
        optionsScreen.AudioBtn.SetActive(true);
        optionsScreen.VideoBtn.SetActive(true);
        optionsScreen.OptionsBackBtn.SetActive(true);

        optionsScreen.SelectGameplay.SetActive(true);
        optionsScreen.SelectAudio.SetActive(false);
        optionsScreen.SelectVideo.SetActive(false);
        optionsScreen.SelectOptionsBack.SetActive(false);

        currentMenuState = "OptionsScreen";
        currentState = "options:gameplay";
        descriptionText.text = "Adjusts the Gameplay settings";
    } // void SelectOptions
    #endregion
    #region Options Selects
    public void SelectOptionsBack() {
        optionsScreen.OptionsCanvas.SetActive(false);
        menuScreen.MenuCanvas.SetActive(true);

        currentMenuState = "MenuScreen";
        currentState = "menu:options";
        descriptionText.text = "Adjust the gameplay, video and audio settings";
    }
    #endregion
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
    #endregion

    #region Quit Buffer
    IEnumerator BufferTimeQuit() {
        yield return new WaitForSeconds(0.1f);
        if(currentMenuState == ("MenuScreen")) {
            SetQuit();
        }
    }
    void SetQuit() {
        currentMenuState = "QuitScreen";
        currentState = "quit:no";
    }
    #endregion
    //*
    #region Start Buffer
    IEnumerator BufferTimeStart() {
        yield return new WaitForSeconds(0.1f);
        if(currentMenuState == "anyKeyScreen") {
            SetStart();
        }
    }
    void SetStart() {
        currentMenuState = "MenuScreen";
        currentState = "menu:play";
    }
    #endregion
    //*/
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour {

    #region Keyboard Inputs Initialization
    private string wKey;
    private string sKey;
    private string arrowKeyDown;
    private string arrowKeyUp;
    private string enterKey;
    private string escKeyK;
    #endregion

    #region Controller Inputs Initialization
    private string aButton;
    private string bButton;
    private string dpadUpDown;
    private string joystickUpDown;
    #endregion

    public string currentState, currentMenuState;
    private bool dpadAxisInUse;
    private bool joystickAxisInUse;

    #region System.Serializables for Screen Handlers
    [System.Serializable]
    public class StartScreen {
        public GameObject StartCanvas;
        public GameObject PressToStart;
    }
    public StartScreen startScreen;

    [System.Serializable]
    public class MenuScreen {
        public GameObject MenuCanvas;
        public GameObject SelectStory, SelectTraining, SelectSettings, SelectQuit;
    }
    public MenuScreen menuScreen;

    [System.Serializable]
    public class SettingsScreen {
        public GameObject SettingsCanvas;
        public GameObject SelectGame, SelectVideo, SelectAudio, SelectSettingsBack;
    }
    public SettingsScreen settingsScreen;

    [System.Serializable]
    public class QuitScreen {
        public GameObject QuitCanvas;
        public GameObject SelectQuitNo, SelectQuitYes;
    }
    public QuitScreen quitScreen;

    [System.Serializable]
    public class VideoScreen {
        public GameObject VideoCanvas;
        public GameObject Select1920, Select1280, SelectVideoBack;
    }
    public VideoScreen videoScreen;
    #endregion

    void Awake() {
        wKey = "wKey";
        sKey = "sKey";
        arrowKeyDown = "downArrow";
        arrowKeyUp = "upArrow";
        enterKey = "enterKey";
        escKeyK = "escKeyK";

        aButton = "aButton";
        bButton = "bButton";
        dpadUpDown = "JoyButtonUpDown";
        joystickUpDown = "JoyUpDown";
    }

    void Start () {
        currentState = "anykey";
        currentMenuState = "TitleScreen";

        #region StartScreen
        startScreen.StartCanvas.SetActive(true);
        startScreen.PressToStart.SetActive(true);
        #endregion
        #region MenuScreen
        menuScreen.MenuCanvas.SetActive(false);
        menuScreen.SelectStory.SetActive(true);
        menuScreen.SelectTraining.SetActive(false);
        menuScreen.SelectSettings.SetActive(false);
        menuScreen.SelectQuit.SetActive(false);
        #endregion
        #region QuitScreen
        quitScreen.QuitCanvas.SetActive(false);
        quitScreen.SelectQuitNo.SetActive(true);
        quitScreen.SelectQuitYes.SetActive(false);
        #endregion
        #region SettingsScreen
        settingsScreen.SettingsCanvas.SetActive(false);
        settingsScreen.SelectGame.SetActive(true);
        settingsScreen.SelectVideo.SetActive(false);
        settingsScreen.SelectAudio.SetActive(false);
        settingsScreen.SelectSettingsBack.SetActive(false);
        #endregion
        #region VideoScreen
        videoScreen.VideoCanvas.SetActive(false);
        videoScreen.Select1920.SetActive(true);
        videoScreen.Select1280.SetActive(false);
        videoScreen.SelectVideoBack.SetActive(false);
        #endregion

    }

    void Update() {
        MenuLogic();
    }

    public void MenuLogic() {

        #region anykey
        if (currentMenuState == "TitleScreen") {
            if ((Input.anyKeyDown) && (currentState == "anykey")) {
                pressToStart();
            }
        }
        #endregion
        #region Up
        if (Input.GetButtonDown(wKey) || Input.GetButtonDown(arrowKeyUp)) {
            #region Menu
            if (currentMenuState == "MenuScreen") {
                if (currentState == "training") {
                    MOStory();
                }
                else if (currentState == "settings") {
                    MOTraining();
                }
                else if (currentState == "quit") {
                    MOSettings();
                }
            }
            #endregion
            #region Settings
            if (currentMenuState == "SettingsScreen") {
                if (currentState == "video") {
                    MOGame();
                }
                else if (currentState == "audio") {
                    MOVideo();
                }
                else if (currentState == "settingsback") {
                    MOAudio();
                }
            }
            #endregion
            #region Video Resolution
            if (currentMenuState == "SettingsVideoScreen") {
                if (currentState == "1920") {
                    MO1280();
                }
                else if (currentState == "videoback") {
                    MO1920();
                }
            }
            #endregion
            #region Quit
            if (currentMenuState == "QuitScreen") {
                if (currentState == "yes") {
                    MOQuitNo();
                }
            }
            #endregion
        }
        #endregion
        #region Down
        else if (Input.GetButtonDown(sKey) || Input.GetButtonDown(arrowKeyDown)) {
            #region Menu
            if (currentMenuState == "MenuScreen") {
                if (currentState == "story") {
                    MOTraining();
                }
                else if (currentState == "training") {
                    MOSettings();
                }
                else if (currentState == "settings") {
                    MOQuit();
                }
            }
            #endregion
            #region Settings
            if (currentMenuState == "SettingsScreen") {
                if (currentState == "game") {
                    MOVideo();
                }
                else if (currentState == "video") {
                    MOAudio();
                }
                else if (currentState == "audio") {
                    MOSettingsBack();
                }
            }
            #endregion
            #region Video Resolution
            if (currentMenuState == "SettingsVideoScreen") {
                if (currentState == "1280") {
                    MO1920();
                }
                else if (currentState == "1920") {
                    MOVideoBack();
                }
            }
            #endregion
            #region Quit
            if (currentMenuState == "QuitScreen") {
                if (currentState == "no") {
                    MOQuitYes();
                }
            }
            #endregion
        }
        #endregion
        #region Enter & A Button
        else if (Input.GetButtonDown(enterKey) || Input.GetButtonDown(aButton)) {
            #region Menu
            if (currentMenuState == "MenuScreen") {
                if (currentState == "story") {
                    SelectStory();
                }
                else if (currentState == "training") {
                    SelectTraining();
                }
                else if (currentState == "settings") {
                    SelectSettings();
                }
                else if (currentState == "quit") {
                    SelectQuit();
                }
            }
            #endregion
            #region Settings
            if (currentMenuState == "SettingsScreen") {
                if (currentState == "settingsback") {
                    SelectSettingsBack();
                }
                else if (currentState == "video") {
                    SelectVideo();
                }
            }
            #endregion
            #region Video Resolution
            if (currentMenuState == "SettingsVideoScreen") {
                if (currentState == "1920") {
                    Select1920();
                }
                else if (currentState == "1280") {
                    Select1280();
                }
                else if (currentState == "videoback") {
                    SelectVideoBack();
                }
            }
            #endregion
            #region Quit
            if (currentMenuState == "QuitScreen") {
                if (currentState == "no") {
                    SelectNo();
                }
                else if (currentState == "yes") {
                    SelectYes();
                }
            }
            #endregion
        }
        #endregion
        #region Esc Key
        else if (Input.GetButtonDown(escKeyK) || Input.GetButtonDown(bButton)) {
            if (currentMenuState == "SettingsScreen") {
                if ((currentState == "game") || (currentState == "video") || (currentState == "audio") || (currentState == "settingsback")) {
                    SelectSettingsBack();
                }
            }
            if (currentMenuState == "SettingsVideoScreen") {
                if ((currentState == "1920") || (currentState == "1280") || (currentState == "videoback")) {
                    SelectVideoBack();
                }
            }
            if (currentMenuState == "QuitScreen") {
                if ((currentState == "no") || (currentState == "yes")) {
                    SelectQuitBack();
                }
            }
        }
        #endregion
        #region Dpad Up and Down
        if (Input.GetAxisRaw(dpadUpDown) != 0) {
            if (dpadAxisInUse == false) {
                #region Up 
                if ((Input.GetAxisRaw(dpadUpDown) > 0)) {
                    #region Menu
                    if (currentMenuState == "MenuScreen") {
                        if (currentState == "training") {
                            MOStory();
                        }
                        else if (currentState == "settings") {
                            MOTraining();
                        }
                        else if (currentState == "quit") {
                            MOSettings();
                        }
                    }
                    #endregion
                    #region Settings
                    if (currentMenuState == "SettingsScreen") {
                        if (currentState == "video") {
                            MOGame();
                        }
                        else if (currentState == "audio") {
                            MOVideo();
                        }
                        else if (currentState == "settingsback") {
                            MOAudio();
                        }
                    }
                    #endregion
                    #region Video Resolution
                    if (currentMenuState == "SettingsVideoScreen") {
                        if (currentState == "1920") {
                            MO1280();
                        }
                        else if (currentState == "videoback") {
                            MO1920();
                        }
                    }
                    #endregion
                    #region Quit
                    if (currentMenuState == "QuitScreen") {
                        if (currentState == "yes") {
                            MOQuitNo();
                        }
                    }
                    #endregion
                }
                #endregion
                #region Down
                if ((Input.GetAxisRaw(dpadUpDown) < 0)) {
                    #region Menu
                    if (currentMenuState == "MenuScreen") {
                        if (currentState == "story") {
                            MOTraining();
                        }
                        else if (currentState == "training") {
                            MOSettings();
                        }
                        else if (currentState == "settings") {
                            MOQuit();
                        }
                    }
                    #endregion
                    #region Settings
                    if (currentMenuState == "SettingsScreen") {
                        if (currentState == "game") {
                            MOVideo();
                        }
                        else if (currentState == "video") {
                            MOAudio();
                        }
                        else if (currentState == "audio") {
                            MOSettingsBack();
                        }
                    }
                    #endregion
                    #region Video Resolution
                    if (currentMenuState == "SettingsVideoScreen") {
                        if (currentState == "1280") {
                            MO1920();
                        }
                        else if (currentState == "1920") {
                            MOVideoBack();
                        }
                    }
                    #endregion
                    #region Quit
                    if (currentMenuState == "QuitScreen") {
                        if (currentState == "no") {
                            MOQuitYes();
                        }
                    }
                    #endregion
                }
                #endregion
                dpadAxisInUse = true;
            }
        }
        if (Input.GetAxisRaw(dpadUpDown) == 0) {
            dpadAxisInUse = false;
        }
        #endregion
        #region JoyStick Up and Down
        if (Input.GetAxisRaw(joystickUpDown) != 0) {
            if (joystickAxisInUse == false) {
                #region Up 
                if ((Input.GetAxisRaw(joystickUpDown) < 0)) {
                    #region Menu
                    if (currentMenuState == "MenuScreen") {
                        if (currentState == "training") {
                            MOStory();
                        }
                        else if (currentState == "settings") {
                            MOTraining();
                        }
                        else if (currentState == "quit") {
                            MOSettings();
                        }
                    }
                    #endregion
                    #region Settings
                    if (currentMenuState == "SettingsScreen") {
                        if (currentState == "video") {
                            MOGame();
                        }
                        else if (currentState == "audio") {
                            MOVideo();
                        }
                        else if (currentState == "settingsback") {
                            MOAudio();
                        }
                    }
                    #endregion
                    #region Video Resolution
                    if (currentMenuState == "SettingsVideoScreen") {
                        if (currentState == "1920") {
                            MO1280();
                        }
                        else if (currentState == "videoback") {
                            MO1920();
                        }
                    }
                    #endregion
                    #region Quit
                    if (currentMenuState == "QuitScreen") {
                        if (currentState == "yes") {
                            MOQuitNo();
                        }
                    }
                    #endregion
                }
                #endregion
                #region Down
                if ((Input.GetAxisRaw(joystickUpDown) > 0)) {
                    #region Menu
                    if (currentMenuState == "MenuScreen") {
                        if (currentState == "story") {
                            MOTraining();
                        }
                        else if (currentState == "training") {
                            MOSettings();
                        }
                        else if (currentState == "settings") {
                            MOQuit();
                        }
                    }
                    #endregion
                    #region Settings
                    if (currentMenuState == "SettingsScreen") {
                        if (currentState == "game") {
                            MOVideo();
                        }
                        else if (currentState == "video") {
                            MOAudio();
                        }
                        else if (currentState == "audio") {
                            MOSettingsBack();
                        }
                    }
                    #endregion
                    #region Video Resolution
                    if (currentMenuState == "SettingsVideoScreen") {
                        if (currentState == "1280") {
                            MO1920();
                        }
                        else if (currentState == "1920") {
                            MOVideoBack();
                        }
                    }
                    #endregion
                    #region Quit
                    if (currentMenuState == "QuitScreen") {
                        if (currentState == "no") {
                            MOQuitYes();
                        }
                    }
                    #endregion
                }
                #endregion
                joystickAxisInUse = true;
            }
        }
        if (Input.GetAxisRaw(joystickUpDown) == 0) {
            joystickAxisInUse = false;
        }
        #endregion

    }

    public void pressToStart() {
        startScreen.StartCanvas.SetActive(false);
        startScreen.PressToStart.SetActive(false);
        menuScreen.MenuCanvas.SetActive(true);
        menuScreen.SelectStory.SetActive(true);
        menuScreen.SelectTraining.SetActive(false);
        menuScreen.SelectSettings.SetActive(false);
        menuScreen.SelectQuit.SetActive(false);
        currentState = "story";
        StartCoroutine(menuSelect());
    }

    #region Menu MouseOver
    public void MOStory() {
        menuScreen.SelectStory.SetActive(true);
        menuScreen.SelectTraining.SetActive(false);
        menuScreen.SelectSettings.SetActive(false);
        menuScreen.SelectQuit.SetActive(false);
        currentState = "story";
    }
    public void MOTraining() {
        menuScreen.SelectStory.SetActive(false);
        menuScreen.SelectTraining.SetActive(true);
        menuScreen.SelectSettings.SetActive(false);
        menuScreen.SelectQuit.SetActive(false);
        currentState = "training";
    }
    public void MOSettings() {
        menuScreen.SelectStory.SetActive(false);
        menuScreen.SelectTraining.SetActive(false);
        menuScreen.SelectSettings.SetActive(true);
        menuScreen.SelectQuit.SetActive(false);
        currentState = "settings";
    }
    public void MOQuit() {
        menuScreen.SelectStory.SetActive(false);
        menuScreen.SelectTraining.SetActive(false);
        menuScreen.SelectSettings.SetActive(false);
        menuScreen.SelectQuit.SetActive(true);
        currentState = "quit";
    }
    #endregion
    #region Settings MouseOver
    public void MOGame() {
        settingsScreen.SelectGame.SetActive(true);
        settingsScreen.SelectVideo.SetActive(false);
        settingsScreen.SelectAudio.SetActive(false);
        settingsScreen.SelectSettingsBack.SetActive(false);
        currentState = "game";
    }
    public void MOVideo() {
        settingsScreen.SelectGame.SetActive(false);
        settingsScreen.SelectVideo.SetActive(true);
        settingsScreen.SelectAudio.SetActive(false);
        settingsScreen.SelectSettingsBack.SetActive(false);
        currentState = "video";
    }
    public void MOAudio() {
        settingsScreen.SelectGame.SetActive(false);
        settingsScreen.SelectVideo.SetActive(false);
        settingsScreen.SelectAudio.SetActive(true);
        settingsScreen.SelectSettingsBack.SetActive(false);
        currentState = "audio";
    }
    public void MOSettingsBack() {
        settingsScreen.SelectGame.SetActive(false);
        settingsScreen.SelectVideo.SetActive(false);
        settingsScreen.SelectAudio.SetActive(false);
        settingsScreen.SelectSettingsBack.SetActive(true);
        currentState = "settingsback";
    }
    #endregion
    #region Quit MouseOver
    public void MOQuitNo() {
        quitScreen.SelectQuitNo.SetActive(true);
        quitScreen.SelectQuitYes.SetActive(false);
        currentState = "no";
    }
    public void MOQuitYes() {
        quitScreen.SelectQuitNo.SetActive(false);
        quitScreen.SelectQuitYes.SetActive(true);
        currentState = "yes";
    }
    #endregion 
    #region Video MouseOver
    public void MO1920() {
        videoScreen.Select1920.SetActive(true);
        videoScreen.Select1280.SetActive(false);
        videoScreen.SelectVideoBack.SetActive(false);
        currentState = "1920";
    }
    public void MO1280() {
        videoScreen.Select1920.SetActive(false);
        videoScreen.Select1280.SetActive(true);
        videoScreen.SelectVideoBack.SetActive(false);
        currentState = "1280";
    }
    public void MOVideoBack() {
        videoScreen.Select1920.SetActive(false);
        videoScreen.Select1280.SetActive(false);
        videoScreen.SelectVideoBack.SetActive(true);
        currentState = "videoback";
    }
    #endregion
    #region Menu Select
    public void SelectStory() {
        //SceneManager.LoadScene("Story");
    }
    public void SelectTraining() {
        SceneManager.LoadScene("KnightTrainingRoom");
    }
    public void SelectSettings() {
        menuScreen.MenuCanvas.SetActive(false);
        settingsScreen.SettingsCanvas.SetActive(true);
        settingsScreen.SelectGame.SetActive(true);
        settingsScreen.SelectVideo.SetActive(false);
        settingsScreen.SelectAudio.SetActive(false);
        settingsScreen.SelectSettingsBack.SetActive(false);
        currentState = "game";

        StartCoroutine(settingsSelect());
    }
    public void SelectQuit() {
        menuScreen.MenuCanvas.SetActive(false);
        quitScreen.QuitCanvas.SetActive(true);
        quitScreen.SelectQuitNo.SetActive(true);
        quitScreen.SelectQuitYes.SetActive(false);
        currentState = "no";

        StartCoroutine(quitSelect());
    }
    #endregion
    #region Settings Select
    public void SelectGame() {

    }
    public void SelectVideo() {
        settingsScreen.SettingsCanvas.SetActive(false);
        videoScreen.VideoCanvas.SetActive(true);
        videoScreen.Select1920.SetActive(false);
        videoScreen.Select1280.SetActive(true);
        videoScreen.SelectVideoBack.SetActive(false);
        currentState = "1280";

        StartCoroutine(settingsVideoSelect());
    }
    public void SelectAudio() {

    }
    public void SelectSettingsBack() {
        menuScreen.MenuCanvas.SetActive(true);
        settingsScreen.SettingsCanvas.SetActive(false);
        menuScreen.MenuCanvas.SetActive(true);
        menuScreen.SelectStory.SetActive(true);
        menuScreen.SelectTraining.SetActive(false);
        menuScreen.SelectSettings.SetActive(false);
        menuScreen.SelectQuit.SetActive(false);
        currentState = "story";

        StartCoroutine(menuSelect());
    }
    #endregion
    #region Quit Select
    public void SelectNo() {
        menuScreen.MenuCanvas.SetActive(true);
        quitScreen.QuitCanvas.SetActive(false);
        menuScreen.MenuCanvas.SetActive(true);
        menuScreen.SelectStory.SetActive(true);
        menuScreen.SelectTraining.SetActive(false);
        menuScreen.SelectSettings.SetActive(false);
        menuScreen.SelectQuit.SetActive(false);
        currentState = "story";

        StartCoroutine(menuSelect());
    }
    public void SelectYes() {
        Application.Quit();
    }
    public void SelectQuitBack() {
        menuScreen.MenuCanvas.SetActive(true);
        quitScreen.QuitCanvas.SetActive(false);
        menuScreen.MenuCanvas.SetActive(true);
        menuScreen.SelectStory.SetActive(true);
        menuScreen.SelectTraining.SetActive(false);
        menuScreen.SelectSettings.SetActive(false);
        menuScreen.SelectQuit.SetActive(false);
        currentState = "story";

        StartCoroutine(menuSelect());
    }
    #endregion
    #region Video Select
    public void Select1920() {
        Screen.SetResolution(1920, 1080, true);
    }
    public void Select1280() {
        Screen.SetResolution(1280, 720, true);
    }
    public void SelectVideoBack() {
        videoScreen.VideoCanvas.SetActive(false);
        settingsScreen.SettingsCanvas.SetActive(true);
        settingsScreen.SelectGame.SetActive(true);
        settingsScreen.SelectVideo.SetActive(false);
        settingsScreen.SelectAudio.SetActive(false);
        settingsScreen.SelectSettingsBack.SetActive(false);
        currentState = "game";

        StartCoroutine(settingsSelect());
    }
    #endregion
    #region iEnumerators
    IEnumerator menuSelect() {
        yield return new WaitForSeconds(0.1f);
        currentMenuState = "MenuScreen";
    }
    IEnumerator settingsSelect() {
        yield return new WaitForSeconds(0.1f);
        currentMenuState = "SettingsScreen";
    }
    IEnumerator quitSelect() {
        yield return new WaitForSeconds(0.1f);
        currentMenuState = "QuitScreen";
    }
    IEnumerator settingsVideoSelect() {
        yield return new WaitForSeconds(0.1f);
        currentMenuState = "SettingsVideoScreen";
    }
    #endregion

}

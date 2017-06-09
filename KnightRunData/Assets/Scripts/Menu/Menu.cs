using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour {

    // Things to note for tagged States that I've assigned.
    // In currentState, it referes to the buttons that are being selected.
    // In currentMenuState, it refers to the Menu Screen that it is currently on. ( TitleScreen, MenuScreen, SettingsScreen, SettingsVideoScreen )
    // Switching of the menu will trigger a short time delay to prevent immediate switching.
    // Checking for button presses will require pressing the button to activate it again.

    public string currentState, currentMenuState;
    public Inputs inputs;

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

	// Use this for initialization
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

    public void Update() {
        print(currentState);
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

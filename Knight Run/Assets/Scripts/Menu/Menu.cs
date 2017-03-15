using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour {

    public string currentState;
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
        public GameObject MOStory, MOTraining, MOSettings, MOQuit;
        public GameObject SelectStory, SelectTraining, SelectSettings, SelectQuit;
    }
    public MenuScreen menuScreen;

    [System.Serializable]
    public class SettingsScreen {
        public GameObject SettingsCanvas;
        public GameObject MOGame, MOVideo, MOAudio, MOSettingsBack;
        public GameObject SelectGame, SelectVideo, SelectAudio, SelectSettingsBack;
    }
    public SettingsScreen settingsScreen;

    [System.Serializable]
    public class VideoScreen {
        public GameObject VideoCanvas;
        public GameObject MO1920, MO1280, MOVideoBack;
        public GameObject Select1920, Select1280, SelectVideoBack;
    }
    public VideoScreen videoScreen;

	// Use this for initialization
	void Start () {
        currentState = "anykey";

        #region StartScreen
        startScreen.StartCanvas.SetActive(true);
        startScreen.PressToStart.SetActive(true);
        #endregion

        #region MenuScreen
        menuScreen.MenuCanvas.SetActive(false);
        //menuScreen.MOStory.SetActive(false);
        //menuScreen.MOTraining.SetActive(true);
        //menuScreen.MOSettings.SetActive(true);
        //menuScreen.MOQuit.SetActive(true);
        menuScreen.SelectStory.SetActive(true);
        menuScreen.SelectTraining.SetActive(false);
        menuScreen.SelectSettings.SetActive(false);
        menuScreen.SelectQuit.SetActive(false);
        #endregion

        #region SettingsScreen
        settingsScreen.SettingsCanvas.SetActive(false);
        //settingsScreen.MOGame.SetActive(false);
        //settingsScreen.MOVideo.SetActive(true);
        //settingsScreen.MOAudio.SetActive(true);
        //settingsScreen.MOSettingsBack.SetActive(true);
        settingsScreen.SelectGame.SetActive(true);
        settingsScreen.SelectVideo.SetActive(false);
        settingsScreen.SelectAudio.SetActive(false);
        settingsScreen.SelectSettingsBack.SetActive(false);
        #endregion

        #region VideoScreen
        videoScreen.VideoCanvas.SetActive(false);
        //videoScreen.MO1920.SetActive(false);
        //videoScreen.MO1280.SetActive(true);
        //videoScreen.MOVideoBack.SetActive(true);
        videoScreen.Select1920.SetActive(true);
        videoScreen.Select1280.SetActive(false);
        videoScreen.SelectVideoBack.SetActive(false);
        #endregion
    }

    public void pressToStart() {
        startScreen.StartCanvas.SetActive(false);
        startScreen.PressToStart.SetActive(false);
        menuScreen.MenuCanvas.SetActive(true);
        //menuScreen.MOStory.SetActive(false);
        //menuScreen.MOTraining.SetActive(true);
        //menuScreen.MOSettings.SetActive(true);
        //menuScreen.MOQuit.SetActive(true);
        menuScreen.SelectStory.SetActive(true);
        menuScreen.SelectTraining.SetActive(false);
        menuScreen.SelectSettings.SetActive(false);
        menuScreen.SelectQuit.SetActive(false);
        currentState = "story";
    }

    #region Menu MouseOver
    public void MOStory() {
        //menuScreen.MOStory.SetActive(false);
        //menuScreen.MOTraining.SetActive(true);
        //menuScreen.MOSettings.SetActive(true);
        //menuScreen.MOQuit.SetActive(true);
        menuScreen.SelectStory.SetActive(true);
        menuScreen.SelectTraining.SetActive(false);
        menuScreen.SelectSettings.SetActive(false);
        menuScreen.SelectQuit.SetActive(false);
        currentState = "story";
    }
    public void MOTraining() {
        //menuScreen.MOStory.SetActive(true);
        //menuScreen.MOTraining.SetActive(false);
        //menuScreen.MOSettings.SetActive(true);
        //menuScreen.MOQuit.SetActive(true);
        menuScreen.SelectStory.SetActive(false);
        menuScreen.SelectTraining.SetActive(true);
        menuScreen.SelectSettings.SetActive(false);
        menuScreen.SelectQuit.SetActive(false);
        currentState = "training";
    }
    public void MOSettings() {
        //menuScreen.MOStory.SetActive(true);
        //menuScreen.MOTraining.SetActive(true);
        //menuScreen.MOSettings.SetActive(false);
        //menuScreen.MOQuit.SetActive(true);
        menuScreen.SelectStory.SetActive(false);
        menuScreen.SelectTraining.SetActive(false);
        menuScreen.SelectSettings.SetActive(true);
        menuScreen.SelectQuit.SetActive(false);
        currentState = "settings";
    }
    public void MOQuit() {
        //menuScreen.MOStory.SetActive(true);
        //menuScreen.MOTraining.SetActive(true);
        //menuScreen.MOSettings.SetActive(true);
        //menuScreen.MOQuit.SetActive(false);
        menuScreen.SelectStory.SetActive(false);
        menuScreen.SelectTraining.SetActive(false);
        menuScreen.SelectSettings.SetActive(false);
        menuScreen.SelectQuit.SetActive(true);
        currentState = "quit";
    }
    #endregion

    #region Settings MouseOver
    public void MOGame() {
        //settingsScreen.MOGame.SetActive(false);
        //settingsScreen.MOVideo.SetActive(true);
        //settingsScreen.MOAudio.SetActive(true);
        //settingsScreen.MOSettingsBack.SetActive(true);
        settingsScreen.SelectGame.SetActive(true);
        settingsScreen.SelectVideo.SetActive(false);
        settingsScreen.SelectAudio.SetActive(false);
        settingsScreen.SelectSettingsBack.SetActive(false);
        currentState = "game";
    }
    public void MOVideo() {
        //settingsScreen.MOGame.SetActive(true);
        //settingsScreen.MOVideo.SetActive(false);
        //settingsScreen.MOAudio.SetActive(true);
        //settingsScreen.MOSettingsBack.SetActive(true);
        settingsScreen.SelectGame.SetActive(false);
        settingsScreen.SelectVideo.SetActive(true);
        settingsScreen.SelectAudio.SetActive(false);
        settingsScreen.SelectSettingsBack.SetActive(false);
        currentState = "video";
    }
    public void MOAudio() {
        //settingsScreen.MOGame.SetActive(true);
        //settingsScreen.MOVideo.SetActive(true);
        //settingsScreen.MOAudio.SetActive(false);
        //settingsScreen.MOSettingsBack.SetActive(true);
        settingsScreen.SelectGame.SetActive(false);
        settingsScreen.SelectVideo.SetActive(false);
        settingsScreen.SelectAudio.SetActive(true);
        settingsScreen.SelectSettingsBack.SetActive(false);
        currentState = "audio";
    }
    public void MOSettingsBack() {
        //settingsScreen.MOGame.SetActive(true);
        //settingsScreen.MOVideo.SetActive(true);
        //settingsScreen.MOAudio.SetActive(true);
        //settingsScreen.MOSettingsBack.SetActive(false);
        settingsScreen.SelectGame.SetActive(false);
        settingsScreen.SelectVideo.SetActive(false);
        settingsScreen.SelectAudio.SetActive(false);
        settingsScreen.SelectSettingsBack.SetActive(true);
        currentState = "settingsback";
    }
    #endregion

    #region Video MouseOver
    public void MO1920() {
        //videoScreen.MO1920.SetActive(false);
        //videoScreen.MO1280.SetActive(true);
        //videoScreen.MOVideoBack.SetActive(true);
        videoScreen.Select1920.SetActive(true);
        videoScreen.Select1280.SetActive(false);
        videoScreen.SelectVideoBack.SetActive(false);
        currentState = "1920";
    }
    public void MO1280() {
        //videoScreen.MO1920.SetActive(true);
        //videoScreen.MO1280.SetActive(false);
        //.MOVideoBack.SetActive(true);
        videoScreen.Select1920.SetActive(false);
        videoScreen.Select1280.SetActive(true);
        videoScreen.SelectVideoBack.SetActive(false);
        currentState = "1280";
    }
    public void MOVideoBack() {
        //videoScreen.MO1920.SetActive(true);
        //videoScreen.MO1280.SetActive(true);
        //videoScreen.MOVideoBack.SetActive(false);
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
        //settingsScreen.MOGame.SetActive(false);
        //settingsScreen.MOVideo.SetActive(true);
        //settingsScreen.MOAudio.SetActive(true);
        //settingsScreen.MOSettingsBack.SetActive(true);
        settingsScreen.SelectGame.SetActive(true);
        settingsScreen.SelectVideo.SetActive(false);
        settingsScreen.SelectAudio.SetActive(false);
        settingsScreen.SelectSettingsBack.SetActive(false);
        currentState = "game";
    }
    public void SelectQuit() {
        Application.Quit();
    }
    #endregion

    #region Settings Select
    public void SelectGame() {

    }
    public void SelectVideo() {
        settingsScreen.SettingsCanvas.SetActive(false);
        videoScreen.VideoCanvas.SetActive(true);
        //videoScreen.MO1920.SetActive(true);
        //videoScreen.MO1280.SetActive(false);
        //videoScreen.MOVideoBack.SetActive(true);
        videoScreen.Select1920.SetActive(false);
        videoScreen.Select1280.SetActive(true);
        videoScreen.SelectVideoBack.SetActive(false);
        currentState = "1280";
    }
    public void SelectAudio() {

    }
    public void SelectSettingsBack() {
        menuScreen.MenuCanvas.SetActive(true);
        settingsScreen.SettingsCanvas.SetActive(false);
        menuScreen.MenuCanvas.SetActive(true);
        //menuScreen.MOStory.SetActive(false);
        //menuScreen.MOTraining.SetActive(true);
        //menuScreen.MOSettings.SetActive(true);
        //menuScreen.MOQuit.SetActive(true);
        menuScreen.SelectStory.SetActive(true);
        menuScreen.SelectTraining.SetActive(false);
        menuScreen.SelectSettings.SetActive(false);
        menuScreen.SelectQuit.SetActive(false);
        currentState = "story";
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
        //settingsScreen.MOGame.SetActive(false);
        //settingsScreen.MOVideo.SetActive(true);
        //settingsScreen.MOAudio.SetActive(true);
        //settingsScreen.MOSettingsBack.SetActive(true);
        settingsScreen.SelectGame.SetActive(true);
        settingsScreen.SelectVideo.SetActive(false);
        settingsScreen.SelectAudio.SetActive(false);
        settingsScreen.SelectSettingsBack.SetActive(false);
        currentState = "game";
    }
    #endregion
}

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

	// Use this for initialization
	void Start () {
        #region StartScreen
        startScreen.StartCanvas.SetActive(true);
        startScreen.PressToStart.SetActive(true);
        #endregion
        #region MenuScreen
        menuScreen.MenuCanvas.SetActive(false);
        menuScreen.MOStory.SetActive(false);
        menuScreen.MOTraining.SetActive(false);
        menuScreen.MOSettings.SetActive(false);
        menuScreen.MOQuit.SetActive(false);
        menuScreen.SelectStory.SetActive(false);
        menuScreen.SelectTraining.SetActive(false);
        menuScreen.SelectSettings.SetActive(false);
        menuScreen.SelectQuit.SetActive(false);
        #endregion
    }
	
    public void pressToStart() {
        startScreen.StartCanvas.SetActive(false);
        startScreen.PressToStart.SetActive(false);
        menuScreen.MenuCanvas.SetActive(true);
        menuScreen.MOStory.SetActive(false);
        menuScreen.MOTraining.SetActive(true);
        menuScreen.MOSettings.SetActive(true);
        menuScreen.MOQuit.SetActive(true);
        menuScreen.SelectStory.SetActive(true);
        menuScreen.SelectTraining.SetActive(false);
        menuScreen.SelectSettings.SetActive(false);
        menuScreen.SelectQuit.SetActive(false);
    }

    public void MOStory() {
        menuScreen.MOStory.SetActive(false);
        menuScreen.MOTraining.SetActive(true);
        menuScreen.MOSettings.SetActive(true);
        menuScreen.MOQuit.SetActive(true);
        menuScreen.SelectStory.SetActive(true);
        menuScreen.SelectTraining.SetActive(false);
        menuScreen.SelectSettings.SetActive(false);
        menuScreen.SelectQuit.SetActive(false);
    }
    public void MOTraining() {
        menuScreen.MOStory.SetActive(true);
        menuScreen.MOTraining.SetActive(false);
        menuScreen.MOSettings.SetActive(true);
        menuScreen.MOQuit.SetActive(true);
        menuScreen.SelectStory.SetActive(false);
        menuScreen.SelectTraining.SetActive(true);
        menuScreen.SelectSettings.SetActive(false);
        menuScreen.SelectQuit.SetActive(false);
    }
    public void MOSettings() {
        menuScreen.MOStory.SetActive(true);
        menuScreen.MOTraining.SetActive(true);
        menuScreen.MOSettings.SetActive(false);
        menuScreen.MOQuit.SetActive(true);
        menuScreen.SelectStory.SetActive(false);
        menuScreen.SelectTraining.SetActive(false);
        menuScreen.SelectSettings.SetActive(true);
        menuScreen.SelectQuit.SetActive(false);
    }
    public void MOQuit() {
        menuScreen.MOStory.SetActive(true);
        menuScreen.MOTraining.SetActive(true);
        menuScreen.MOSettings.SetActive(true);
        menuScreen.MOQuit.SetActive(false);
        menuScreen.SelectStory.SetActive(false);
        menuScreen.SelectTraining.SetActive(false);
        menuScreen.SelectSettings.SetActive(false);
        menuScreen.SelectQuit.SetActive(true);
    }
}

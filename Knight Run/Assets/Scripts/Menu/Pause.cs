using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class Pause : MonoBehaviour {

    public string currentState;
    public GameObject PauseTrigger;
    public CursorLockMode cursorLocked = CursorLockMode.Locked;
    public CursorLockMode cursorUnlocked = CursorLockMode.None;

    [System.Serializable]
    public class PauseCanvas {
        public GameObject pauseCanvas;
        public GameObject resume,MOresume;
        public GameObject quitTitle,MOquitTitle;
        public GameObject quitGame,MOquitGame;
        public GameObject PausePrefab;
    }
    [SerializeField]
    public PauseCanvas pauseCanvas;

    [System.Serializable]
    public class Inputs {
        public bool LMB;
        public bool escKey;
        public bool keyW;
        public bool keyS;
        public bool keyEnter;
        public bool keyArrowUp;
        public bool keyArrowDown;
    }
    [SerializeField]
    public Inputs inputs;

    [System.Serializable]
    public class InputStrings {
        public string selectK;
        public string escKey;
        public string wKey;
        public string sKey;
        public string enterKey;
        public string arrowKeyDown;
        public string arrowKeyUp;
    }
    [SerializeField]
    public InputStrings inputStrings;

    void Awake() {
        #region input
        inputStrings.selectK = "SelectK";
        inputStrings.escKey = "escKeyK";
        inputStrings.wKey = "wKey";
        inputStrings.sKey = "sKey";
        inputStrings.enterKey = "enterKey";
        inputStrings.arrowKeyDown = "downArrow";
        inputStrings.arrowKeyUp = "upArrow";
        #endregion
    }
    // Use this for initialization
    void Start () {
        PauseTrigger.SetActive(true);
        Cursor.lockState = cursorUnlocked;
        #region Pause Canvas
        pauseCanvas.pauseCanvas.SetActive(true);

        pauseCanvas.resume.SetActive(false);
        pauseCanvas.quitTitle.SetActive(true);
        pauseCanvas.quitGame.SetActive(true);
        pauseCanvas.MOresume.SetActive(true);
        pauseCanvas.MOquitTitle.SetActive(false);
        pauseCanvas.MOquitGame.SetActive(false);
        #endregion
        currentState = "MOResume";
    }

    // Update is called once per frame
    void Update () {
        PauseMenuLogic();
        HandleInput();
	}
    #region MO Handlers
    public void MOResume() {
        currentState = "MOResume";
        pauseCanvas.resume.SetActive(false);
        pauseCanvas.quitTitle.SetActive(true);
        pauseCanvas.quitGame.SetActive(true);
        pauseCanvas.MOresume.SetActive(true);
        pauseCanvas.MOquitTitle.SetActive(false);
        pauseCanvas.MOquitGame.SetActive(false);
    }
    public void MOQuitTitle() {
        currentState = "MOQuitTitle";
        pauseCanvas.resume.SetActive(true);
        pauseCanvas.quitTitle.SetActive(false);
        pauseCanvas.quitGame.SetActive(true);
        pauseCanvas.MOresume.SetActive(false);
        pauseCanvas.MOquitTitle.SetActive(true);
        pauseCanvas.MOquitGame.SetActive(false);
    }
    public void MOQuitGame() {
        currentState = "MOQuitGame";
        pauseCanvas.resume.SetActive(true);
        pauseCanvas.quitTitle.SetActive(true);
        pauseCanvas.quitGame.SetActive(false);
        pauseCanvas.MOresume.SetActive(false);
        pauseCanvas.MOquitTitle.SetActive(false);
        pauseCanvas.MOquitGame.SetActive(true);
    }
    #endregion
    #region Select Button handler
    public void SelectResume() {
        Time.timeScale = 1;
        pauseCanvas.pauseCanvas.SetActive(true);
        pauseCanvas.PausePrefab.SetActive(false);
        PauseTrigger.SetActive(true);
        Cursor.lockState = cursorLocked;
    }
    public void SelectQuitTitle() {
        SceneManager.LoadScene("Menu");
    }
    public void SelectQuitGame() {
        Application.Quit();
    }
    #endregion
    private void PauseMenuLogic() {
        #region W Key Handler
        if((inputs.keyW)||(inputs.keyArrowUp)) {
            if(currentState == "MOQuitTitle") {
                MOResume();
            }
            else if (currentState == "MOQuitGame") {
                MOQuitTitle();
            }
        }
        #endregion
        #region S Key Handler
        if((inputs.keyS)||(inputs.keyArrowDown)) {
            if(currentState == "MOResume") {
                MOQuitTitle();
            }
            else if(currentState == "MOQuitTitle") {
                MOQuitGame();
            }
        }
        #endregion
        #region Enter Key Handler
        if(inputs.keyEnter) {
            if(currentState == "MOResume") {
                SelectResume();
            }
            else if(currentState == "MOQuitTitle") {
                SelectQuitTitle();
            }
            else if (currentState == "MOQuitGame") {
                SelectQuitGame();
            }
        }
        #endregion
    }
    private void HandleInput() {
        inputs.LMB = Input.GetButtonDown(inputStrings.selectK);
        inputs.keyW = Input.GetButtonDown(inputStrings.wKey);
        inputs.keyS = Input.GetButtonDown(inputStrings.sKey);
        inputs.keyEnter = Input.GetButtonDown(inputStrings.enterKey);
        inputs.keyArrowDown = Input.GetButtonDown(inputStrings.arrowKeyDown);
        inputs.keyArrowUp = Input.GetButtonDown(inputStrings.arrowKeyUp);
        inputs.escKey = Input.GetButtonDown(inputStrings.escKey);
    }
}

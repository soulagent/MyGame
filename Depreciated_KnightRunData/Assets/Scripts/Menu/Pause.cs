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
        public GameObject selectResume, selectReload, selectQuitGame;
        public GameObject PausePrefab;
    }
    [SerializeField]
    public PauseCanvas pauseCanvas;

    #region Keyboard Inputs Initialization
    private string wKey;
    private string sKey;
    private string enterKey;
    private string downArrow;
    private string upArrow;
    private string escKeyK;
    #endregion

    #region Controller Inputs Initialization
    private string aButton;
    private string bButton;
    private string dpadUpDown;
    private string joystickUpDown;
    private string startButton;
    #endregion

    private bool dpadAxisInUse;
    private bool joystickAxisInUse;

    void Awake() {

        wKey = "wKey";
        sKey = "sKey";
        enterKey = "enterKey";
        downArrow = "downArrow";
        upArrow = "upArrow";
        escKeyK = "escKeyK";

        aButton = "aButton";
        bButton = "bButton";
        dpadUpDown = "JoyButtonUpDown";
        joystickUpDown = "JoyUpDown";
        startButton = "startButton";

    }

    void Start () {
        PauseTrigger.SetActive(true);
        Cursor.lockState = cursorUnlocked;
        #region Pause Canvas
        pauseCanvas.pauseCanvas.SetActive(true);

        pauseCanvas.selectResume.SetActive(true);
        pauseCanvas.selectReload.SetActive(false);
        pauseCanvas.selectQuitGame.SetActive(false);
        #endregion
        currentState = "resume";
    }

    void Update () {
        PauseMenuLogic();
	}
    #region MO Handlers
    public void MOResume() {
        currentState = "resume";
        pauseCanvas.selectResume.SetActive(true);
        pauseCanvas.selectReload.SetActive(false);
        pauseCanvas.selectQuitGame.SetActive(false);
    }
    public void MOReload() {
        currentState = "reload";
        pauseCanvas.selectResume.SetActive(false);
        pauseCanvas.selectReload.SetActive(true);
        pauseCanvas.selectQuitGame.SetActive(false);
    }
    public void MOQuitGame() {
        currentState = "quit";
        pauseCanvas.selectResume.SetActive(false);
        pauseCanvas.selectReload.SetActive(false);
        pauseCanvas.selectQuitGame.SetActive(true);
    }
    #endregion
    #region Select Button handler
    public void SelectResume() {
        Time.timeScale = 1;

        pauseCanvas.selectResume.SetActive(true);
        pauseCanvas.selectReload.SetActive(false);
        pauseCanvas.selectQuitGame.SetActive(false);

        currentState = "resume";

        pauseCanvas.pauseCanvas.SetActive(true);
        pauseCanvas.PausePrefab.SetActive(false);
        PauseTrigger.SetActive(true);
        Cursor.lockState = cursorLocked;
    }
    public void SelectReload() {
        Time.timeScale = 1;
        SceneManager.LoadScene("KnightTrainingRoom");
    }
    public void SelectQuitGame() {
        Time.timeScale = 1;
        SceneManager.LoadScene("Menu");
    }
    #endregion

    private void PauseMenuLogic() {
        #region W Key Handler
        if ( (Input.GetButtonDown(wKey)) || (Input.GetButtonDown(upArrow)) ) {
            if(currentState == "reload") {
                MOResume();
            }
            else if (currentState == "quit") {
                MOReload();
            }
        }
        #endregion
        #region S Key Handler
        if ( (Input.GetButtonDown(sKey)) || (Input.GetButtonDown(downArrow)) ) {
            if(currentState == "resume") {
                MOReload();
            }
            else if(currentState == "reload") {
                MOQuitGame();
            }
        }
        #endregion
        #region Enter Key Handler
        if ( Input.GetButtonDown(enterKey) || Input.GetButtonDown(aButton) ) {
            if(currentState == "resume") {
                SelectResume();
            }
            else if(currentState == "reload") {
                SelectReload();
            }
            else if (currentState == "quit") {
                SelectQuitGame();
            }
        }
        #endregion
        #region Dpad Up and Down
        if (Input.GetAxisRaw(dpadUpDown) != 0) {
            if (dpadAxisInUse == false) {
                #region Up 
                if ((Input.GetAxisRaw(dpadUpDown) > 0)) {
                    if (currentState == "reload") {
                        MOResume();
                    }
                    else if (currentState == "quit") {
                        MOReload();
                    }
                }
                #endregion
                #region Down
                if ((Input.GetAxisRaw(dpadUpDown) < 0)) {
                    if (currentState == "resume") {
                        MOReload();
                    }
                    else if (currentState == "reload") {
                        MOQuitGame();
                    }
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
                    if (currentState == "reload") {
                        MOResume();
                    }
                    else if (currentState == "quit") {
                        MOReload();
                    }
                }
                #endregion
                #region Down
                if ((Input.GetAxisRaw(joystickUpDown) > 0)) {
                    if (currentState == "resume") {
                        MOReload();
                    }
                    else if (currentState == "reload") {
                        MOQuitGame();
                    }
                }
                #endregion
                joystickAxisInUse = true;
            }
        }
        if (Input.GetAxisRaw(joystickUpDown) == 0) {
            joystickAxisInUse = false;
        }
        #endregion
        #region Esc Key Handler
        if ( Input.GetButtonDown(escKeyK) || Input.GetButtonDown(bButton) || Input.GetButtonDown(startButton) ) {
            if ( currentState == "resume" || currentState == "reload" ||  currentState == "quit") {
                SelectResume();
            }
        }
        #endregion
    }
}

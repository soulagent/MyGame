using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseInputs : MonoBehaviour {
    private string escKeyK;
    private string startButton;

    public GameObject PausePrefab;
    public GameObject PauseTrigger;


    void Awake() {
        escKeyK = "escKeyK";
        startButton = "startButton";
    }
    // Use this for initialization
    void Start() {
        PausePrefab.SetActive(false);
        PauseTrigger.SetActive(true);
    }

    // Update is called once per frame
    void Update() {
        PauseMenuTrigger();
    }

    private void PauseMenuTrigger() {
        if ( (Input.GetButtonDown(escKeyK)) || (Input.GetButtonDown(startButton)) ) {
            Time.timeScale = 0;
            PausePrefab.SetActive(true);
            PauseTrigger.SetActive(false);
        }
    }
}

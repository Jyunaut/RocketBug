using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Global : MonoBehaviour
{
    // Title
    public Image titleCardImg;

    // Countdown UI
    public Text timerTxt;
    public GameObject timerObj;
    public float timer = 60;
    public bool isCounting = true;

    // Start game UI
    public Button startGameBtn;
    public bool startGame = false;

    // Turn indicators UI
    public Image leftIndicatorUI;
    public Image rightIndicatorUI;

    // Rocket Controls
    public float leftSteer = 0;

    //Set endgame
    public int gameState;
    public Image goodEndingImg;
    public Image badEndingImg;

    // Background
    public GameObject groundImg;
    public GameObject pondImg;
    public GameObject backgroundObj;

    // Start is called before the first frame update
    void Start() {
        startGameBtn.onClick.AddListener(StartGameBtnUI);

        leftIndicatorUI.gameObject.SetActive(false);
        rightIndicatorUI.gameObject.SetActive(false);
        titleCardImg.gameObject.SetActive(true);
        startGameBtn.gameObject.SetActive(true);
    }

    // Update is called once per frame
    void Update() {
        if (startGame) {
            GameState();
        }
    }

    void GameState() {
        switch(gameState) {
            // Player is currently playing
            case 1:
                StartTimerTxt();
                RocketControls();
                IndicatorsUI();
                pondImg.gameObject.SetActive(true);

                // Check if player has landed on the pond
                if(timer <= 0) {
                    if(leftSteer < 10 && leftSteer > -10f) { // Checks is player has aimed onto the pond
                        gameState = 2; // Good ending
                    }
                    else {
                        gameState = 3; // Bad ending
                    }
                }
            break;

            // Player has saved the bug!
            case 2:
                // Show the good ending card
                // Disable indicators and other UIs
                goodEndingImg.gameObject.SetActive(true);
                badEndingImg.gameObject.SetActive(false);
                leftIndicatorUI.gameObject.SetActive(false);
                rightIndicatorUI.gameObject.SetActive(false);
                pondImg.gameObject.SetActive(false);
                backgroundObj.SetActive(false);
            break;

            // Player has destroyed the rocket
            case 3:
                // Show the bad ending card
                // Disable indicators and other UIs
                goodEndingImg.gameObject.SetActive(false);
                badEndingImg.gameObject.SetActive(true);
                leftIndicatorUI.gameObject.SetActive(false);
                rightIndicatorUI.gameObject.SetActive(false);
                pondImg.gameObject.SetActive(false);
                backgroundObj.SetActive(false);
            break;
            default:
                Debug.Log("Missing ending\n");
            break;
        }
    }

    void RocketControls() {
        if (Input.GetAxisRaw("Horizontal") < 0) {
            leftSteer += 0.1f;
            pondImg.transform.position += new Vector3(1f,0,0);
        }

        if (Input.GetAxisRaw("Horizontal") > 0) {
            leftSteer -= 0.1f;
            pondImg.transform.position -= new Vector3(1f,0,0);
        }
    }

    // Start counting down and scaling the pond up
    void StartTimerTxt() {
        if (timer >= 0.0f && isCounting) {
            timer -= Time.deltaTime;
            timerTxt.text = timer.ToString("F");
            pondImg.transform.localScale += new Vector3(0.03f,0.03f,0f);
        }
        else if (timer <= 0.0f) {
            isCounting = false;
            timerTxt.text = "0";
        }
    }

    // Button for starting the game
    void StartGameBtnUI() {
        if (!startGame) {
            // Disable menu UI
            // Show Timer UI & update game state
            startGame = true;
            startGameBtn.gameObject.SetActive(false);
            titleCardImg.gameObject.SetActive(false);
            timerObj.SetActive(true);
            gameState = 1;
        }
    }

    // ...
    void IndicatorsUI() {
        if(leftSteer > 15f) {
            leftIndicatorUI.gameObject.SetActive(false);
            rightIndicatorUI.gameObject.SetActive(true);
        }
        else if (leftSteer < -15f) {
            leftIndicatorUI.gameObject.SetActive(true);
            rightIndicatorUI.gameObject.SetActive(false);
        }
        else {
            leftIndicatorUI.gameObject.SetActive(false);
            rightIndicatorUI.gameObject.SetActive(false);
        }
    }
}
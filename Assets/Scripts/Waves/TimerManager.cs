using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimerManager : Timer {

    /*            
        30 sec alert
        Fight until all enemies dead
        x2, so 2 min total

        2 min
    */
   
    public enum GameState {WAITING, PREPARING, FIGHTING}   //Waiting = no enemies etc.
    public GameState gameState;
    public AudioSource song;
    
    //[SerializeField] means i can view the private fields in the inspector
    [SerializeField] private Text uiText;

    [SerializeField] private WarningTimer warningTimer;
    [SerializeField] private WaveSpawner wave;


    public void Start() {
        gameState = GameState.WAITING;        
        time = 180f;    // 2 minutes
        StartTimer();
    }
    
    public override void Update() {               

        // Waiting = Announcing when wave will start
        // Preparing = Preparing for wave
        // Fighting = Fighting wave

        switch(gameState) {

            case GameState.WAITING:
                StartCoroutine(WarningMessage());
                gameState = GameState.PREPARING;
                break;

            case GameState.PREPARING:
                if (wave.getState() == WaveSpawner.SpawnState.SPAWNING) {
                    gameState = GameState.FIGHTING;
                    StartCoroutine(RoundBeginMessage());
                }
                break;
                
            case GameState.FIGHTING:               
                if (wave.getState() == WaveSpawner.SpawnState.COUNTING) {
                    gameState = GameState.WAITING;
                }
                break;

            default:
                break;

        }

        if (curTime <= 0.0f) {
            curTime = 0.0f;
            isActive = false;
            OnEnd();
        }

        if (isActive) {
            curTime -= Time.deltaTime;
        }

        //Debug.Log(curTime);
    }

    protected override void OnEnd() {
        // End of level
        //Debug.Log("End of level");
        //Debug.Log("Ran for: " + time);
        StartCoroutine(End());
    }

    private IEnumerator End() {
        uiText.text = "Its time to leave this Planet!";
        yield return new WaitForSeconds(5.0f);
        uiText.text = "";
    }

    private IEnumerator WarningMessage() {
        uiText.text = wave.timeBetweenWaves + " Seconds until enemy spawn";
        yield return new WaitForSeconds(5.0f);
        uiText.text = "";
    }

    private IEnumerator RoundBeginMessage() {
        uiText.text = "Enemies have spawned!";
        yield return new WaitForSeconds(5.0f);
        uiText.text = "";
    }
}


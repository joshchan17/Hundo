using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class WarningTimer : Timer {
 
    /*
    public void Start() {
        StartTimer();
    }
    */

    protected override void OnEnd() {        
        //Debug.Log("Timer ended, ran for " + time + " seconds");
    }

    public override void Update() {
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

    /*
    [SerializeField]
    private Text uiText;

    public void Start() {
        uiText.text = curTime + " seconds until round starts!";        
        StartTimer();
    }

    public void Update() {
        Debug.Log(time);
    }

    protected override void OnEnd() {        
        StartCoroutine(End());        
    }    
    
    [SerializeField]
    private Text uiText;
    [SerializeField]
    private float mainTimer = 15;    //how long it takes each time ex) always a 30 sec warning  
    
   
    //private float timer;        //Actual timer = curTime
    private bool canCount = true;
    private bool doOnce = false;

	// Use this for initialization
	public WarningTimer() {        
        time = mainTimer;
        StartTimer();
    }

    public float getMainTimer() {
        return mainTimer;
    }
	
    /*
	// Update is called once per frame
	void Update () {        
		if (curTime >= 0.0f && canCount) {
            uiText.text = curTime.ToString("0") + " Seconds until enemy arrives!";
            curTime -= Time.deltaTime;        
        }
        else if (curTime <= 0.05f && !doOnce) {
            canCount = false;
            doOnce = true;
            StartCoroutine(End());
            curTime = 0.0f;
            RestartTimer();
        }
	}


    

    public void RestartTimer() {
        curTime = mainTimer;
        canCount = true;
        doOnce = false;
    }

    protected override void OnEnd() {        
        canCount = false;
        doOnce = true;
        curTime = 0.0f;
    }

    private IEnumerator End() {
        uiText.text = "Wave Incoming!";
        yield return new WaitForSeconds(5.0f);
        uiText.text = "";
    }

    */

}

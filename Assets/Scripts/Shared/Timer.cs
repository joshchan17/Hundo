using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public abstract class Timer : MonoBehaviour {

    //public delegate void OnEndDelegate();
    //OnEndDelegate endDelegate;   

    public float time; // How long the timer should be set to
    protected float curTime { get; set; }   // Current time of timer
    protected bool isActive;  // Determines if timer is acti

    public void Awake() {
        isActive = false;        
    }   
   
    protected abstract void OnEnd();    //What happens when timer ends?

    //function to set variables of timer
    public void StartTimer() {
        //Debug.Log("isActive = " + isActive);
        if (!isActive) {
            isActive = true;
            curTime = time;
            //Debug.Log("Time: " + time);
            //Debug.Log("Currrent time: " + curTime);
            //StartCoroutine(exec());                     
        }
    }

    //Main funtionality of timer
    public abstract void Update();

    /*
    private IEnumerator exec() {
        Debug.Log("Starting coroutine");
        curTime -= Time.deltaTime;
        if (curTime >= 0.0f) {
            yield return new WaitForFixedUpdate();
            StartCoroutine(exec());
        }
        else {
            curTime = 0.0f;
            isActive = false;
            OnEnd();
            yield break;
        }
    }
    */
}
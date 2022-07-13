using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public Text timerText;
    private float startTime;
 
     bool keepTiming;
    // float timer;
 
     void Start () {
         StopTimer();
     }
 
     void Update () {
        if(Globals.score == Globals.gameLevel && Globals.pauseGame){
            StopTimer();
            //Debug.Log("Timer stopped at " + TimeToString(StopTimer()));
            //Globals.pauseGame = false;
        }
 
        if(Globals.clickOnStart && !Globals.restartTimer)
        {
             StartTimer();
             Globals.restartTimer = true;
        }

        if(Globals.levelFour && !Globals.pauseGame)
        {
            StartTimer();
            Globals.pauseGame = true;
        }

        if(keepTiming){
             UpdateTime();
        }
     }
 
     void UpdateTime(){
         Globals.timer = Time.time - startTime;
         timerText.text = TimeToString(Globals.timer);
     }
 
     float StopTimer(){
         keepTiming = false;
         return Globals.timer;
     }
 
     void ResumeTimer(){
         keepTiming = true;
         startTime = Time.time-Globals.timer;
     }
 
     void StartTimer(){
         keepTiming = true;
         startTime = Time.time;
     }
 
     string TimeToString(float t){
         float mins = ((int) t / 60);
         float secs = (t % 60 );
         string minutes = ((int) t / 60).ToString();
         string seconds = ((int) t % 60 ).ToString();
         string miliseconds = ((int)(((t % 60) - ((int) t % 60)) * 100 )).ToString();
         if(secs < 10) { 
             if (mins < 10){
                Globals.finalTime = "0" + minutes + ":0" + seconds + ":" + miliseconds;
                return "Tid: " + System.Environment.NewLine + "0" + minutes + ":0" + seconds + ":" + miliseconds;
             }
             else{
                Globals.finalTime = minutes + ":0" + seconds + ":" + miliseconds;
                return "Tid: " + System.Environment.NewLine + minutes + ":0" + seconds + ":" + miliseconds; 
             }
             
         }
         else {
            if (mins < 10){
                Globals.finalTime = "0" + minutes + ":" + seconds + ":" + miliseconds; 
                return "Tid: " + System.Environment.NewLine + "0" + minutes + ":" + seconds + ":" + miliseconds;
             }
             else{
                Globals.finalTime = minutes + ":" + seconds + ":" + miliseconds; 
                return "Tid: " + System.Environment.NewLine + minutes + ":" + seconds + ":" + miliseconds; 
             }
            
         }
     }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StartButton : MonoBehaviour
{
    public InputField input;

    // Start is called before the first frame update
    void Start()
    {
        
    }        

    public void OnClick(){
        if (input.text != "")
        {
            Globals.playerName = input.text;
            Globals.clickOnStart = true;
            //Debug.Log("PlayerName: " + Globals.playerName);
            //Debug.Log("clickOnStart: " + Globals.clickOnStart);
            //Debug.Log("gameStarted: " + Globals.gameStarted);
        }
        else
        {
            
        }
    }
}

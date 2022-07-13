using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class NextButton : MonoBehaviour
{
    void Start()
    {

    }
    
    private void Awake()
    {
        Show();
    }
    public void OnClick()
    {
        //SceneManager.LoadScene("Scene_00" + Globals.sceneNumber);
        Globals.nextFlag = false;
        Globals.pauseGame = false;
        Globals.sceneNumber++;
        //Globals.gameLevel++;
        Hide();
    }
    public void Show()
    {
        gameObject.SetActive(true);
    }
    public void Hide()
    {
        gameObject.SetActive(false);
    }

    void Update()
    {
        if(Globals.nextFlag)
        {
            //Debug.Log("nextFlag: " + Globals.nextFlag);
           Show();
        }
       /* else
        {
            Hide();
        }*/
    }

}

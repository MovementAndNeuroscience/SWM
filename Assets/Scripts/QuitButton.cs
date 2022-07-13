using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class QuitButton : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void OnClick()
    {
        Globals.nextFlag = false;
        Globals.pauseGame = false;
        Globals.sceneNumber++;
        Hide();
        //SceneManager.LoadScene("Scene_005");
        QuitGame();
        //Globals.resetAll = true;

    }

    public void Hide()
    {
        gameObject.SetActive(false);
    }

    public void QuitGame()
    {
        #if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
        #else
            Application.Quit();
        #endif
        //SceneManager.LoadScene("Scene_003");
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}

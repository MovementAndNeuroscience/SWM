using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class UI_InputWindow : MonoBehaviour
{
    private void Awake()
    {
        Show();
    }
    public void Show()
    {
        gameObject.SetActive(true);
    }
    public void Hide()
    {
        gameObject.SetActive(false);
    }

    public void Update()
    {
        if(Globals.clickOnStart){ Hide();}
    }

}

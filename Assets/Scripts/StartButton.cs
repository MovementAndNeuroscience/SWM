using UnityEngine;
using TMPro; 

public class StartButton : MonoBehaviour
{
    public TMP_InputField tmp_input; 

    // Start is called before the first frame update
    void Start()
    {
        
    }        

    public void OnClick(){
        if(tmp_input.text != "")
        {
            Globals.playerName = tmp_input.text;
            Globals.clickOnStart = true;
        }
    }
}

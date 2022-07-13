using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public static class Globals
{
    public static int score = 0;
    public static int errors = 0;
    public static int errorsA = 0;
    public static int errorsB = 0;
    public static int[] clickSequence = new int[5000];
    public static int[] currentCycleSequence = new int[5000];
    public static int iterations = 0;
    public static int currentCycleIterations = 0;
    public static float timer = 0;
    public static bool writeToFile = false;
    public static bool clickOnStart = false;
    public static bool gameStarted = false;
    public static bool restartTimer = false;
    public static int sceneNumber = 3;
    public static bool nextFlag = false;
    public static int gameLevel = 3;
    public static bool pauseGame = false;
    public static bool levelFour = false;
    public static bool levelFive = false;
    public static bool levelSix = false;
    public static bool levelSeven = false;
    public static bool levelEight = false;
    public static bool levelNine = false;
    public static bool moveFlag = false;

    // Flags for identifying when each level is completed (this happens when each red circle is found)
    public static bool level3Complete = false;
    public static bool level4Complete = false;
    public static bool level5Complete = false;
    public static bool level6Complete = false;
    public static bool level7Complete = false;
    public static bool level8Complete = false;
    public static bool level9Complete = false;


    // variables for saving each levels results into a string. They are saved as a whole at the end
    public static string resultsLevel3 = "";
    public static string resultsLevel4 = "";
    public static string resultsLevel5 = "";
    public static string resultsLevel6 = "";
    public static string resultsLevel7 = "";
    public static string resultsLevel8 = "";
    public static string resultsLevel9 = "";

    public static string playerName = "";
    public static string finalTime = "";

    public static int clicks_0 = 0;
    public static int clicks_1 = 0;
    public static int clicks_2 = 0;
    public static int clicks_3 = 0;
    public static int clicks_4 = 0;

    public static bool resetAll = false;
}

public class SceneController : MonoBehaviour
{
    public GameObject MainSquare;
    public GameObject SecondSquare;
    public GameObject ThirdSquare;
    public GameObject ForthSquare;
    public GameObject FifthSquare;
    public GameObject SixthSquare;
    public GameObject PlayingArea;
    public GameObject DropArea;
    public GameObject doneMessage;
    public GameObject ThankyouMessage;
    public GameObject nextSceneButton;
    public GameObject quitButton;
    //[SerializeField] private GameObject Square_Yellow;
    // Add as much spaces has round pieces (MainSquare) are all together in all the levels
    bool[] flagsArray = {false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false};
    private int startSquare = 0;

    List<GameObject> squares = new List<GameObject>();
    List<GameObject> squares4 = new List<GameObject>();
    List<GameObject> squares5 = new List<GameObject>();
    List<GameObject> squares6 = new List<GameObject>();
    List<GameObject> squares7 = new List<GameObject>();
    List<GameObject> squares8 = new List<GameObject>();

    // Start is called before the first frame update
    void Start()
    {
        /* These elements are active for debuggin purposes only */
        /* Unncomment for final version */
        gameLevelText.SetActive(false);
        errorLabel.SetActive(false);
        scoreLabel.SetActive(false);
        TimeLabel.SetActive(false);
        /*******************************************************/

        doneMessage.SetActive(false);
        ThankyouMessage.SetActive(false);
        nextSceneButton.SetActive(false);
        quitButton.SetActive(false);
        if (Globals.gameStarted){
            BeginTest(Globals.gameLevel);
        }
    }

    public void BeginTest(int level)
    {

        int yellowRandom = Random.Range(0,level);   // Defines a random position for the first Yellow Square
        int posX = Random.Range(-280,280);      // First random position for the first Square (x axis)
        int posY = Random.Range(-170,170);      // First random position for the first Square (y axis)

        // Cykel for creating 5 Squares when clicking on Start button
        for (int i = 0; i < level; i++){          
            GameObject playerSquare = Instantiate(MainSquare, new Vector3(posX,posY,0), Quaternion.identity);
            playerSquare.transform.SetParent(PlayingArea.transform, false);
            playerSquare.transform.Find("Square_Yellow").gameObject.SetActive(false);   // By default all Yellow Squares are not active
            squares.Add(playerSquare);   // add each Square to the list for future use/referance

            // Set the random selected Yellow Square as active (only when game starts)
            if (i == 0){
                playerSquare.transform.Find("Square_Yellow").gameObject.SetActive(true);
                flagsArray[i] = true;
                startSquare = i;     
            }
            posX = Random.Range(-280,280);
            posY = Random.Range(-170,170);
        }
     
    }

    public void BeginTest4(int level)
    {

        int yellowRandom = Random.Range(0,level);   // Defines a random position for the first Yellow Square
        int posX = Random.Range(-280,280);      // First random position for the first Square (x axis)
        int posY = Random.Range(-170,170);      // First random position for the first Square (y axis)

        // Cykel for creating 4 Squares on Level 4
        for (int i = 0; i < level; i++){          
            GameObject playerSquare = Instantiate(SecondSquare, new Vector3(posX,posY,0), Quaternion.identity);
            playerSquare.transform.SetParent(PlayingArea.transform, false);
            playerSquare.transform.Find("Square_Yellow").gameObject.SetActive(false);   // By default all Yellow Squares are not active
            squares4.Add(playerSquare);   // add each Square to the list for future use/referance

            // Set the random selected Yellow Square as active (only when game starts)
            if (i == 0){
                playerSquare.transform.Find("Square_Yellow").gameObject.SetActive(true);
                flagsArray[i] = true;
                startSquare = i;     
            }
            posX = Random.Range(-280,280);
            posY = Random.Range(-170,170);
        }
     
    }

    public void BeginTest5(int level)
    {

        int yellowRandom = Random.Range(0,level);   // Defines a random position for the first Yellow Square
        int posX = Random.Range(-280,280);      // First random position for the first Square (x axis)
        int posY = Random.Range(-170,170);      // First random position for the first Square (y axis)

        // Cykel for creating 5 Squares on Level 5
        for (int i = 0; i < level; i++){          
            GameObject playerSquare = Instantiate(ThirdSquare, new Vector3(posX,posY,0), Quaternion.identity);
            playerSquare.transform.SetParent(PlayingArea.transform, false);
            playerSquare.transform.Find("Square_Yellow").gameObject.SetActive(false);   // By default all Yellow Squares are not active
            squares5.Add(playerSquare);   // add each Square to the list for future use/referance

            // Set the random selected Yellow Square as active (only when game starts)
            if (i == 0){
                playerSquare.transform.Find("Square_Yellow").gameObject.SetActive(true);
                flagsArray[i] = true;
                startSquare = i;     
            }
            posX = Random.Range(-280,280);
            posY = Random.Range(-170,170);
        }
     
    }

    public void BeginTest6(int level)
    {

        int yellowRandom = Random.Range(0,level);   // Defines a random position for the first Yellow Square
        int posX = Random.Range(-280,280);      // First random position for the first Square (x axis)
        int posY = Random.Range(-170,170);      // First random position for the first Square (y axis)

        // Cykel for creating 6 Squares on Level 6
        for (int i = 0; i < level; i++){          
            GameObject playerSquare = Instantiate(ForthSquare, new Vector3(posX,posY,0), Quaternion.identity);
            playerSquare.transform.SetParent(PlayingArea.transform, false);
            playerSquare.transform.Find("Square_Yellow").gameObject.SetActive(false);   // By default all Yellow Squares are not active
            squares6.Add(playerSquare);   // add each Square to the list for future use/referance

            // Set the random selected Yellow Square as active (only when game starts)
            if (i == 0){
                playerSquare.transform.Find("Square_Yellow").gameObject.SetActive(true);
                flagsArray[i] = true;
                startSquare = i;     
            }
            posX = Random.Range(-280,280);
            posY = Random.Range(-170,170);
        }
     
    }

    public void BeginTest7(int level)
    {

        int yellowRandom = Random.Range(0,level);   // Defines a random position for the first Yellow Square
        int posX = Random.Range(-280,280);      // First random position for the first Square (x axis)
        int posY = Random.Range(-170,170);      // First random position for the first Square (y axis)

        // Cykel for creating 7 Squares on Level 7
        for (int i = 0; i < level; i++){          
            GameObject playerSquare = Instantiate(FifthSquare, new Vector3(posX,posY,0), Quaternion.identity);
            playerSquare.transform.SetParent(PlayingArea.transform, false);
            playerSquare.transform.Find("Square_Yellow").gameObject.SetActive(false);   // By default all Yellow Squares are not active
            squares7.Add(playerSquare);   // add each Square to the list for future use/referance

            // Set the random selected Yellow Square as active (only when game starts)
            if (i == 0){
                playerSquare.transform.Find("Square_Yellow").gameObject.SetActive(true);
                flagsArray[i] = true;
                startSquare = i;     
            }
            posX = Random.Range(-280,280);
            posY = Random.Range(-170,170);
        }
     
    }

    public void BeginTest8(int level)
    {

        int yellowRandom = Random.Range(0,level);   // Defines a random position for the first Yellow Square
        int posX = Random.Range(-280,280);      // First random position for the first Square (x axis)
        int posY = Random.Range(-170,170);      // First random position for the first Square (y axis)

        // Cykel for creating 8 Squares on Level 8
        for (int i = 0; i < level; i++){          
            GameObject playerSquare = Instantiate(SixthSquare, new Vector3(posX,posY,0), Quaternion.identity);
            playerSquare.transform.SetParent(PlayingArea.transform, false);
            playerSquare.transform.Find("Square_Yellow").gameObject.SetActive(false);   // By default all Yellow Squares are not active
            squares8.Add(playerSquare);   // add each Square to the list for future use/referance

            // Set the random selected Yellow Square as active (only when game starts)
            if (i == 0){
                playerSquare.transform.Find("Square_Yellow").gameObject.SetActive(true);
                flagsArray[i] = true;
                startSquare = i;     
            }
            posX = Random.Range(-280,280);
            posY = Random.Range(-170,170);
        }
     
    }

    public void BeginTest9(int level)
    {
        //ThankyouMessage.SetActive(true);
        //quitButton.SetActive(true);
        //StartCoroutine(FinalPause());
        //Start();
        //Application.LoadLevel(Application.loadedLevel);
        //SceneManager.LoadScene("Scene_003");
    }

    private IEnumerator FinalReset()
    {
        yield return new WaitForSeconds(3.0f);
        //ThankyouMessage.SetActive(false);
        Globals.score = 0;
        Globals.errors = 0;
        Globals.errorsA = 0;
        Globals.errorsB = 0;
        Globals.clickSequence = new int[5000];
        Globals.currentCycleSequence = new int[5000];
        Globals.iterations = 0;
        Globals.currentCycleIterations = 0;
        Globals.timer = 0;
        Globals.writeToFile = false;
        Globals.clickOnStart = false;
        Globals.gameStarted = false;
        Globals.restartTimer = false;
        Globals.sceneNumber = 3;
        Globals.nextFlag = false;
        Globals.gameLevel = 3;
        Globals.pauseGame = false;
        Globals.levelFour = false;
        Globals.levelFive = false;
        Globals.levelSix = false;
        Globals.levelSeven = false;
        Globals.levelEight = false;
        Globals.levelNine = false;
        Globals.moveFlag = false;

        // Flags for identifying when each level is completed (this happens when each red circle is found)
        Globals.level3Complete = false;
        Globals.level4Complete = false;
        Globals.level5Complete = false;
        Globals.level6Complete = false;
        Globals.level7Complete = false;
        Globals.level8Complete = false;
        Globals.level9Complete = false;


        // variables for saving each levels results into a string. They are saved as a whole at the end
        Globals.resultsLevel3 = "";
        Globals.resultsLevel4 = "";
        Globals.resultsLevel5 = "";
        Globals.resultsLevel6 = "";
        Globals.resultsLevel7 = "";
        Globals.resultsLevel8 = "";
        Globals.resultsLevel9 = "";

        Globals.playerName = "";
        Globals.finalTime = "";

        Globals.clicks_0 = 0;
        Globals.clicks_1 = 0;
        Globals.clicks_2 = 0;
        Globals.clicks_3 = 0;
        Globals.clicks_4 = 0;

        Globals.resetAll = false;
    }

    public void QuitGame()
    {
        #if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
        #else
            Application.Quit();
        #endif
    }
    public void ResetVariables()
    {
        Globals.score = 0;
        Globals.errors = 0;
        Globals.errorsA = 0;
        Globals.errorsB = 0;
        Globals.iterations = 0;
        Globals.currentCycleIterations = 0;
        startSquare = 0;
        for(int i = 0; i < 32; i++){
            flagsArray[i] = false;
        }
    }

    [SerializeField] private GameObject gameLevelText;
    [SerializeField] private GameObject errorLabel;
    [SerializeField] private GameObject TimeLabel;
    [SerializeField] private GameObject scoreLabel;

    // Update is called once per frame
    void Update()
    {
        // Automatically move Red Cicle
        /*if(Globals.moveFlag && MainSquare.transform.Find("Square_Yellow")){
            float shipSpeed = 7.0f;
            float totalSpeed = shipSpeed * Time.deltaTime;
            MainSquare.transform.Find("Square_Yellow").Translate(Vector3.down * totalSpeed);
            Globals.moveFlag = false;
        }*/
        if(Globals.clickOnStart && !Globals.gameStarted)
        {
            BeginTest(3);
            Globals.gameStarted = true;
        }
        if(Globals.resetAll){
            //StartCoroutine(FinalReset());
            //Start();
        }

        // Uncomment for debbugin purposes...  
        //gameLevelText.GetComponent<UnityEngine.UI.Text>().text = "Game Level: " + Globals.gameLevel;
        //errorLabel.GetComponent<UnityEngine.UI.Text>().text = "Fejl: " + Globals.errors;
        //scoreLabel.GetComponent<UnityEngine.UI.Text>().text = "Score: " + Globals.score;
        //TimeLabel.GetComponent<UnityEngine.UI.Text>().text = "Tid: " + System.Environment.NewLine + Globals.timer.ToString("0.0");


        //************************ BEGIN - PLACE NEW YELLOW SQUARE FOR THE DIFFERENT LEVELS ******************************************
        // Find the square for the new Yellow Square - Level 3
        if(Globals.gameLevel == 3 && startSquare < 2){
            if(flagsArray[startSquare] && squares[startSquare].transform.childCount == 1){
                startSquare++;
                flagsArray[startSquare] = true;
                squares[startSquare].transform.Find("Square_Yellow").gameObject.SetActive(true);
            }
            else{
                
            }
        }
        else
        {
            // Find the square for the new Yellow Square - Level 4
            if(Globals.gameLevel == 4 && startSquare < 3 && Globals.levelFour){
                if(flagsArray[startSquare] && squares4[startSquare].transform.childCount == 1){
                    startSquare++;
                    flagsArray[startSquare] = true;
                    squares4[startSquare].transform.Find("Square_Yellow").gameObject.SetActive(true);
                }
            }
            else{
                if(Globals.gameLevel == 5 && startSquare < 4 && Globals.levelFive){
                    if(flagsArray[startSquare] && squares5[startSquare].transform.childCount == 1){
                        startSquare++;
                        flagsArray[startSquare] = true;
                        squares5[startSquare].transform.Find("Square_Yellow").gameObject.SetActive(true);
                    }
                }
                else{
                    if(Globals.gameLevel == 6 && startSquare < 5 && Globals.levelSix){
                        if(flagsArray[startSquare] && squares6[startSquare].transform.childCount == 1){
                            startSquare++;
                            flagsArray[startSquare] = true;
                            squares6[startSquare].transform.Find("Square_Yellow").gameObject.SetActive(true);
                        }
                    }    
                    else{
                        if(Globals.gameLevel == 7 && startSquare < 6 && Globals.levelSeven){
                           if(flagsArray[startSquare] && squares7[startSquare].transform.childCount == 1){
                                startSquare++;
                                flagsArray[startSquare] = true;
                                squares7[startSquare].transform.Find("Square_Yellow").gameObject.SetActive(true);
                            }
                        }
                        else{
                            if(Globals.gameLevel == 8 && startSquare < 7 && Globals.levelEight){
                                if(flagsArray[startSquare] && squares8[startSquare].transform.childCount == 1){
                                    startSquare++;
                                    flagsArray[startSquare] = true;
                                    squares8[startSquare].transform.Find("Square_Yellow").gameObject.SetActive(true);
                                }
                            }
                        }
                    }
                }    
            }
        }

        //************************ END - PLACE NEW YELLOW SQUARE FOR THE DIFFERENT LEVELS ******************************************

        
        // Show messages and NEXT button each time a level is completed
        if((Globals.score == 3 && Globals.gameLevel == 3) || (Globals.score == 4 && Globals.gameLevel == 4) || (Globals.score == 5 && Globals.gameLevel == 5) || (Globals.score == 6 && Globals.gameLevel == 6) || (Globals.score == 7 && Globals.gameLevel == 7))
        {
            // Show "DONE!" messeage when a level is completed
            //GameObject GameOver = Instantiate(doneMessage, new Vector3(0,0,0), Quaternion.identity);
            doneMessage.gameObject.SetActive(true);
            //GameOver.transform.SetParent(PlayingArea.transform, false);

            nextSceneButton.SetActive(true);
            //Globals.writeToFile = true;
            Globals.nextFlag = true;
            Globals.level3Complete = true;
            Globals.gameLevel++;
            Globals.pauseGame = true;
            
        }

        //If the final level is completed... show thank you screen and quit
        if((Globals.score == 8 && Globals.gameLevel == 8))
        {
            Debug.Log("Level 8 completed");
            //ResetVariables();
            //StartCoroutine(FinalPause());
            ThankyouMessage.SetActive(true);
            quitButton.SetActive(true);
            Globals.nextFlag = true;
            Globals.level3Complete = true;
            Globals.gameLevel++;
            Globals.pauseGame = true;
            //StartCoroutine(FinalPause());
            //QuitGame();
        }

        // What to do if the level 3 is completed
        if(Globals.gameLevel == 4 && !Globals.levelFour && Globals.sceneNumber == 4){
            for (int i = 0; i < 3; i++){
                squares[i].gameObject.SetActive(false);
                DropArea.transform.GetChild(i).gameObject.SetActive(false);
                //DropArea.transform.Find("Square_Yellow").gameObject.SetActive(false);
            }
            // Copy results from Level 3 to string line
            Globals.resultsLevel3 = Globals.errors + "," + Globals.errorsA + "," + Globals.errorsB + "," + Globals.finalTime + ",";
            doneMessage.gameObject.SetActive(false);
            ResetVariables();
            BeginTest4(Globals.gameLevel);
            
            Globals.pauseGame = false;           
            Globals.levelFour = true;
        }

        // What to do if the level 4 is completed
        if(Globals.gameLevel == 5 && !Globals.levelFive && Globals.sceneNumber == 5){
            for (int i = 0; i < 4; i++){
                squares4[i].gameObject.SetActive(false);
                DropArea.transform.GetChild(i+3).gameObject.SetActive(false);
                //DropArea.transform.Find("Square_Yellow").gameObject.SetActive(false);
            }
            // Copy results from Level 4 to string line
            Globals.resultsLevel4 = Globals.errors + "," + Globals.errorsA + "," + Globals.errorsB + "," + Globals.finalTime + ",";
            doneMessage.gameObject.SetActive(false);
            ResetVariables();
            BeginTest5(Globals.gameLevel);
            
            Globals.pauseGame = false;           
            Globals.levelFive = true;
        }

        // What to do if the level 5 is completed
        if(Globals.gameLevel == 6 && !Globals.levelSix && Globals.sceneNumber == 6){
            for (int i = 0; i < 5; i++){
                squares5[i].gameObject.SetActive(false);
                DropArea.transform.GetChild(i+7).gameObject.SetActive(false);
                //DropArea.transform.Find("Square_Yellow").gameObject.SetActive(false);
            }
            // Copy results from Level 5 to string line
            Globals.resultsLevel5 = Globals.errors + "," + Globals.errorsA + "," + Globals.errorsB + "," + Globals.finalTime + ",";
            //Globals.writeToFile = true; // ONLY write at the end of the last level.
            doneMessage.gameObject.SetActive(false);
            ResetVariables();
            BeginTest6(Globals.gameLevel);
            
            Globals.pauseGame = false;           
            Globals.levelSix = true;
        }

        // What to do if the level 6 is completed
        if(Globals.gameLevel == 7 && !Globals.levelSeven && Globals.sceneNumber == 7){
            for (int i = 0; i < 6; i++){
                squares6[i].gameObject.SetActive(false);
                DropArea.transform.GetChild(i+12).gameObject.SetActive(false);
                //DropArea.transform.Find("Square_Yellow").gameObject.SetActive(false);
            }
            // Copy results from Level 6 to string line
            Globals.resultsLevel6 = Globals.errors + "," + Globals.errorsA + "," + Globals.errorsB + "," + Globals.finalTime + ","; 
            //Globals.writeToFile = true; // ONLY write at the end of the last level.
            doneMessage.gameObject.SetActive(false);
            ResetVariables();
            BeginTest7(Globals.gameLevel);
            
            Globals.pauseGame = false; // ONLY reset time if the game continues... if not. STOP           
            Globals.levelSeven = true;
        }

        // What to do if the level 7 is completed
        if(Globals.gameLevel == 8 && !Globals.levelEight && Globals.sceneNumber == 8){
            for (int i = 0; i < 7; i++){
                squares7[i].gameObject.SetActive(false);
                DropArea.transform.GetChild(i+18).gameObject.SetActive(false);
                //DropArea.transform.Find("Square_Yellow").gameObject.SetActive(false);
            }
            // Copy results from Level 7 to string line
            Globals.resultsLevel7 = Globals.errors + "," + Globals.errorsA + "," + Globals.errorsB + "," + Globals.finalTime + ","; 
            //Globals.writeToFile = true; // ONLY write at the end of the last level.
            doneMessage.gameObject.SetActive(false);
            ResetVariables();
            BeginTest8(Globals.gameLevel);
            
            Globals.pauseGame = false; // ONLY reset time if the game continues... if not. STOP           
            Globals.levelEight = true;
        }

        // What to do if the level 8 is completed
        if(Globals.gameLevel == 9 && !Globals.levelNine && Globals.sceneNumber == 9){
            for (int i = 0; i < 8; i++){
                squares8[i].gameObject.SetActive(false);
                DropArea.transform.GetChild(i+25).gameObject.SetActive(false);
                //DropArea.transform.Find("Square_Yellow").gameObject.SetActive(false);
            }
            // Copy results from Level 8 to string line
            Globals.resultsLevel8 = Globals.errors + "," + Globals.errorsA + "," + Globals.errorsB + "," + Globals.finalTime; //No comma at the last level
            Globals.writeToFile = true; // ONLY write at the end of the last level.
            Debug.Log("Write after level 8 = " + Globals.writeToFile);
            //doneMessage.gameObject.SetActive(false);
            //ResetVariables();
            //BeginTest9(3);

            /****RESTART ******/
            //ThankyouMessage.SetActive(true);
            //StartCoroutine(FinalPause());
            //QuitGame();
            
            //Globals.pauseGame = false; // ONLY reset time if the game continues... if not. STOP           
            Globals.levelNine = true;
        }

    }
}

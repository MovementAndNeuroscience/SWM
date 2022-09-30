using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    public GameObject MainSquare;
    public GameObject SecondSquare;
    public GameObject ThirdSquare;
    public GameObject ForthSquare;
    public GameObject FifthSquare;
    public GameObject SixthSquare;
    public GameObject SeventhSquare;
    public GameObject EightsSquare;
    public GameObject PlayingArea;
    public GameObject DropArea;
    public GameObject doneMessage;
    public GameObject ThankyouMessage;
    public GameObject nextSceneButton;
    public GameObject quitButton;
    //[SerializeField] private GameObject Square_Yellow;
    // Add as much spaces has round pieces (MainSquare) are all together in all the levels
    bool[] flagsArray = {false, false, false, 
        false, false, false, false, 
        false, false, false, false, false, 
        false, false, false, false, false, false, 
        false, false, false, false, false, false, false, 
        false, false, false, false, false, false, false, false,
        false, false, false, false, false, false, false, false, false,
        false, false, false, false, false, false, false, false, false, false};
    private int startSquare = 0;

    List<GameObject> squares = new List<GameObject>();
    List<GameObject> squares4 = new List<GameObject>();
    List<GameObject> squares5 = new List<GameObject>();
    List<GameObject> squares6 = new List<GameObject>();
    List<GameObject> squares7 = new List<GameObject>();
    List<GameObject> squares8 = new List<GameObject>();
    List<GameObject> squares9 = new List<GameObject>();
    List<GameObject> squares10 = new List<GameObject>();

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
            BeginTest(Globals.gameLevel, MainSquare, squares);
        }
    }

    [SerializeField] private GameObject gameLevelText;
    [SerializeField] private GameObject errorLabel;
    [SerializeField] private GameObject TimeLabel;
    [SerializeField] private GameObject scoreLabel;

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.Escape))
        {
            QuitGame();
        }

        if(Globals.clickOnStart && !Globals.gameStarted)
        {
            BeginTest(3, MainSquare, squares);
            Globals.gameStarted = true;
        }
        if(Globals.resetAll){
            //StartCoroutine(FinalReset());
            //Start();
        }

        //************************ BEGIN - PLACE NEW YELLOW SQUARE FOR THE DIFFERENT LEVELS ******************************************
        // Find the square for the new Yellow Square - Level 3
        if(Globals.gameLevel == 3 && startSquare < 2)
        {
            ActivateStimuli(squares);
        }// Find the square for the new Yellow Square - Level 4
        else if(Globals.gameLevel == 4 && startSquare < 3 && Globals.levelFour)
        {
            ActivateStimuli(squares4);
        }
        else if(Globals.gameLevel == 5 && startSquare < 4 && Globals.levelFive)
        {
            ActivateStimuli(squares5);
        }
        else if(Globals.gameLevel == 6 && startSquare < 5 && Globals.levelSix)
        {
            ActivateStimuli(squares6);
        }    
        else if(Globals.gameLevel == 7 && startSquare < 6 && Globals.levelSeven)
        {
            ActivateStimuli(squares7);
        }
        else if(Globals.gameLevel == 8 && startSquare < 7 && Globals.levelEight)
        {
            ActivateStimuli(squares8);
        }
        else if (Globals.gameLevel == 9 && startSquare < 8 && Globals.levelNine)
        {
            ActivateStimuli(squares9);
        }
        else if (Globals.gameLevel == 10 && startSquare < 9 && Globals.levelTen)
        {
            ActivateStimuli(squares10);
        }
        //************************ END - PLACE NEW YELLOW SQUARE FOR THE DIFFERENT LEVELS ******************************************


        // Show messages and NEXT button each time a level is completed
        if ((Globals.score == 3 && Globals.gameLevel == 3) || (Globals.score == 4 && Globals.gameLevel == 4) ||
            (Globals.score == 5 && Globals.gameLevel == 5) || (Globals.score == 6 && Globals.gameLevel == 6) || 
            (Globals.score == 7 && Globals.gameLevel == 7) || (Globals.score == 8 && Globals.gameLevel == 8) ||
            (Globals.score == 9 && Globals.gameLevel == 9))
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
        if((Globals.score == 10 && Globals.gameLevel == 10))
        {
            Debug.Log("Level 10 completed");
            Globals.resultsLevel10 = Globals.errors + "," + Globals.errorsA + "," + Globals.errorsB + "," + Globals.finalTime + ",";
            Globals.writeToFile = true;

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
        if(Globals.gameLevel == 4 && !Globals.levelFour && Globals.sceneNumber == 4)
        {
            (Globals.levelFour, Globals.resultsLevel3) = SaveLastlevelProgressToNext(Globals.gameLevel, squares, Globals.resultsLevel3, Globals.levelFour, SecondSquare, squares4);
        }
        // What to do if the level 4 is completed
        if (Globals.gameLevel == 5 && !Globals.levelFive && Globals.sceneNumber == 5){
            (Globals.levelFive, Globals.resultsLevel4) = SaveLastlevelProgressToNext(Globals.gameLevel, squares4, Globals.resultsLevel4, Globals.levelFive, ThirdSquare, squares5);
        }
        // What to do if the level 5 is completed
        if(Globals.gameLevel == 6 && !Globals.levelSix && Globals.sceneNumber == 6){
            (Globals.levelSix, Globals.resultsLevel5) = SaveLastlevelProgressToNext(Globals.gameLevel, squares5, Globals.resultsLevel5, Globals.levelSix, ForthSquare, squares6);
        }
        // What to do if the level 6 is completed
        if(Globals.gameLevel == 7 && !Globals.levelSeven && Globals.sceneNumber == 7){
            (Globals.levelSeven, Globals.resultsLevel6) =  SaveLastlevelProgressToNext(Globals.gameLevel, squares6, Globals.resultsLevel6, Globals.levelSeven, FifthSquare, squares7);
        }
        // What to do if the level 7 is completed
        if(Globals.gameLevel == 8 && !Globals.levelEight && Globals.sceneNumber == 8){
            (Globals.levelEight, Globals.resultsLevel7) = SaveLastlevelProgressToNext(Globals.gameLevel, squares7, Globals.resultsLevel7, Globals.levelEight, SixthSquare, squares8);
        }
        if (Globals.gameLevel == 9 && !Globals.levelNine && Globals.sceneNumber == 9)
        {
            (Globals.levelNine, Globals.resultsLevel8) = SaveLastlevelProgressToNext(Globals.gameLevel, squares8, Globals.resultsLevel8, Globals.levelNine, SeventhSquare, squares9);
        }
        if (Globals.gameLevel == 10 && !Globals.levelTen && Globals.sceneNumber == 10)
        {
            (Globals.levelTen, Globals.resultsLevel9) = SaveLastlevelProgressToNext(Globals.gameLevel, squares9, Globals.resultsLevel9, Globals.levelTen, EightsSquare, squares10);
        }
    }

    private (bool, string) SaveLastlevelProgressToNext(int gamelevel, List<GameObject> previousLevelSquares, string previousLevelData, bool currentLevel, GameObject currentLevelStimuli, List<GameObject> currentLevelStimuliList)
    {
        for (int i = 0; i < gamelevel - 1; i++)
        {
            previousLevelSquares[i].gameObject.SetActive(false);
        }
        DeactivateDropAreaChildren();

        // Copy results from Level 3 to string line
        previousLevelData = Globals.errors + "," + Globals.errorsA + "," + Globals.errorsB + "," + Globals.finalTime + ",";
        doneMessage.gameObject.SetActive(false);
        ResetVariables();
        BeginTest(gamelevel, currentLevelStimuli, currentLevelStimuliList);

        Globals.pauseGame = false;
        currentLevel = true;
        return (currentLevel, previousLevelData);
    }

    private void DeactivateDropAreaChildren()
    {
        for (int i = 0; i < DropArea.transform.childCount; i++)
        {
            DropArea.transform.GetChild(i).gameObject.SetActive(false);
        }
    }

    private void ActivateStimuli(List<GameObject> squares)
    {
        if (flagsArray[startSquare] && squares[startSquare].transform.childCount == 1)
        {
            startSquare++;
            flagsArray[startSquare] = true;
            squares[startSquare].transform.Find("Square_Yellow").gameObject.SetActive(true);
        }
    }
    public void BeginTest(int level, GameObject SquareType, List<GameObject> squares)
    {

        int yellowRandom = Random.Range(0, level);   // Defines a random position for the first Yellow Square
        int posX = Random.Range(-850, 700);      // First random position for the first Square (x axis)
        int posY = Random.Range(-450, 425);      // First random position for the first Square (y axis)

        // Cykel for creating 5 Squares when clicking on Start button
        for (int i = 0; i < level; i++)
        {
            GameObject playerSquare = Instantiate(SquareType, new Vector3(posX, posY, 0), Quaternion.identity);
            playerSquare.transform.SetParent(PlayingArea.transform, false);
            playerSquare.transform.Find("Square_Yellow").gameObject.SetActive(false);   // By default all Yellow Squares are not active
            squares.Add(playerSquare);   // add each Square to the list for future use/referance

            // Set the random selected Yellow Square as active (only when game starts)
            if (i == 0)
            {
                playerSquare.transform.Find("Square_Yellow").gameObject.SetActive(true);
                flagsArray[i] = true;
                startSquare = i;
            }
            posX = Random.Range(-850, 700);
            posY = Random.Range(-450, 425);
        }

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
        for (int i = 0; i < 32; i++)
        {
            flagsArray[i] = false;
        }
    }
}

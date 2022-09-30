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
    public static bool levelTen = false;
    public static bool moveFlag = false;

    // Flags for identifying when each level is completed (this happens when each red circle is found)
    public static bool level3Complete = false;
    public static bool level4Complete = false;
    public static bool level5Complete = false;
    public static bool level6Complete = false;
    public static bool level7Complete = false;
    public static bool level8Complete = false;
    public static bool level9Complete = false;
    public static bool level10Complete = false;

    // variables for saving each levels results into a string. They are saved as a whole at the end
    public static string resultsLevel3 = "";
    public static string resultsLevel4 = "";
    public static string resultsLevel5 = "";
    public static string resultsLevel6 = "";
    public static string resultsLevel7 = "";
    public static string resultsLevel8 = "";
    public static string resultsLevel9 = "";
    public static string resultsLevel10 = "";

    public static string playerName = "";
    public static string finalTime = "";

    public static int clicks_0 = 0;
    public static int clicks_1 = 0;
    public static int clicks_2 = 0;
    public static int clicks_3 = 0;
    public static int clicks_4 = 0;

    public static bool resetAll = false;
}

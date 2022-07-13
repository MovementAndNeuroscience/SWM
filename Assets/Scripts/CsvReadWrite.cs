using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System;

public class CsvReadWrite : MonoBehaviour {
    
    private List<string[]> rowData = new List<string[]>();

    string setURL = "post_data.php?player_data=";
    string finalData = null;
   

    // Use this for initialization
    void Start () {
        if (!File.Exists(getPath())) { Save();}
    }
    
    void Save(){
        // Instruct Excel to use comma as separator
        string[] rowDataTemp = new string[1];
        rowDataTemp[0] = "sep=,";
        rowData.Add(rowDataTemp);

        // Creating First row of titles manually..
        rowDataTemp = new string[26];
        rowDataTemp[0] = "ID";
        rowDataTemp[1] = "Date-timestamp";
        rowDataTemp[2] = "Level-3-Fejl";
        rowDataTemp[3] = "Level-3-Fejl-type-A";
        rowDataTemp[4] = "Level-3-Fejl-type-B";
        rowDataTemp[5] = "Level-3-Tid";
        rowDataTemp[6] = "Level-4-Fejl";
        rowDataTemp[7] = "Level-4-Fejl-type-A";
        rowDataTemp[8] = "Level-4-Fejl-type-B";
        rowDataTemp[9] = "Level-4-Tid";
        rowDataTemp[10] = "Level-5-Fejl";
        rowDataTemp[11] = "Level-5-Fejl-type-A";
        rowDataTemp[12] = "Level-5-Fejl-type-B";
        rowDataTemp[13] = "Level-5-Tid";
        rowDataTemp[14] = "Level-6-Fejl";
        rowDataTemp[15] = "Level-6-Fejl-type-A";
        rowDataTemp[16] = "Level-6-Fejl-type-B";
        rowDataTemp[17] = "Level-6-Tid";
        rowDataTemp[18] = "Level-7-Fejl";
        rowDataTemp[19] = "Level-7-Fejl-type-A";
        rowDataTemp[20] = "Level-7-Fejl-type-B";
        rowDataTemp[21] = "Level-7-Tid";
        rowDataTemp[22] = "Level-8-Fejl";
        rowDataTemp[23] = "Level-8-Fejl-type-A";
        rowDataTemp[24] = "Level-8-Fejl-type-B";
        rowDataTemp[25] = "Level-8-Tid";
       
       
        rowData.Add(rowDataTemp);

        /*string filePath = getPath();
        
        StreamWriter outStream = System.IO.File.CreateText(filePath);
        outStream.WriteLine("sep=,");
        outStream.WriteLine("ID,Date-timestamp,Level-3-Fejl,Level3-Fejl-typeA,Level3-Fejl-typeB,Level-3-Tid,Level-4-Fejl,Level-4-Fejl-typeA,Level-4-Fejl-typeB,Level-4-Tid");
*/
        // You can add up the values in as many cells as you want.
        /*for(int i = 0; i < 10; i++){
            rowDataTemp = new string[3];
            rowDataTemp[0] = "Sushanta"+i; // name
            rowDataTemp[1] = ""+i; // ID
            rowDataTemp[2] = "$"+UnityEngine.Random.Range(5000,10000); // Income
            rowData.Add(rowDataTemp);
        }*/


    }

    // Following method is used to retrive the relative path as device platform
    private string getPath(){
        #if UNITY_EDITOR
        return Application.dataPath +"/CSV/"+"Saved_data.csv";
        #elif UNITY_ANDROID
        return Application.persistentDataPath+"Saved_data.csv";
        #elif UNITY_IPHONE
        return Application.persistentDataPath+"/"+"Saved_data.csv";
        #else
        return Application.dataPath +"/"+"Saved_data.csv";
        #endif
    }
    
    void Update () {
         /*if (Globals.score == 3 && Globals.writeToFile){
            /*string[] rowDataTemp = new string[6];
            rowDataTemp[0] = "" + Globals.playerName; // name
            rowDataTemp[1] = DateTime.Now.ToString(); // Date-timestamp
            rowDataTemp[2] = "" + Globals.errors; // ID
            rowDataTemp[3] = "" + Globals.errorsA; // ID
            rowDataTemp[4] = "" + Globals.errorsB; // ID
            rowDataTemp[5] = "" + Globals.finalTime; // Income
            rowData.Add(rowDataTemp);
            
            Globals.resultsLevel3 = Globals.playerName + "," + DateTime.Now.ToString() + "," + Globals.errors + "," + Globals.errorsA + "," + Globals.errorsB + "," + Globals.finalTime + ",";
            Globals.writeToFile = false;
         }*/

        if (Globals.writeToFile)
        {
            
            //Globals.resultsLevel4 = Globals.errors + "," + Globals.errorsA + "," + Globals.errorsB + "," + Globals.finalTime + "\n";
            string[] rowDataTemp = new string[2];
            rowDataTemp[0] = "" + Globals.playerName; // name
            rowDataTemp[1] = DateTime.Now.ToString(); // Date-timestamp
            rowData.Add(rowDataTemp);

            string[][] output = new string[rowData.Count][];

            for(int i = 0; i < output.Length; i++){
                output[i] = rowData[i];
            }

            int     length         = output.GetLength(0);
            string     delimiter     = ",";

            StringBuilder sb = new StringBuilder();
            
            for (int index = 0; index < length; index++){
                sb.AppendLine(string.Join(delimiter, output[index]));
            }
            
            
            string filePath = getPath();

            /****************** IF DATA IS SAVED IN FILE ON SERVER ************************/
            finalData = "\n" + Globals.playerName + "," + DateTime.Now.ToString() + "," + Globals.resultsLevel3 + Globals.resultsLevel4 + Globals.resultsLevel5 + Globals.resultsLevel6 + Globals.resultsLevel7 + Globals.resultsLevel8 + "\n";
            StartCoroutine(SetTheText(finalData));
            Debug.Log("Writetofile = " + Globals.writeToFile);
            Debug.Log("FinalData = " + finalData);

            /******************************************************************************/

            /******************** LOC01 START - IF DATA IS SAVED IN LOCAL FILE ****************/
            
            /*if (!File.Exists(filePath))
            {
                StreamWriter outStream = System.IO.File.CreateText(filePath);
                outStream.WriteLine("sep=,");
                outStream.WriteLine("ID,Date-timestamp,Level-3-Fejl,Level-3-Fejl-type-A,Level-3-Fejl-type-B,Level-3-Tid,Level-4-Fejl,Level-4-Fejl-type-A,Level-4-Fejl-type-B,Level-4-Tid,Level-5-Fejl,Level-5-Fejl-type-A,Level-5-Fejl-type-B,Level-5-Tid,Level-6-Fejl,Level-6-Fejl-type-A,Level-6-Fejl-type-B,Level-6-Tid,Level-7-Fejl,Level-7-Fejl-type-A,Level-7-Fejl-type-B,Level-7-Tid,Level-8-Fejl,Level-8-Fejl-type-A,Level-8-Fejl-type-B,Level-8-Tid");
                outStream.WriteLine("\n" + Globals.playerName + "," + DateTime.Now.ToString() + "," + Globals.resultsLevel3 + Globals.resultsLevel4 + Globals.resultsLevel5 + Globals.resultsLevel6 + Globals.resultsLevel7 + Globals.resultsLevel8 + "\n");
                //outStream.WriteLine(sb + "," + Globals.resultsLevel3 + Globals.resultsLevel4);
                outStream.Close();
            }
            else 
            {
                File.AppendAllText(filePath, "\n" + Globals.playerName + "," + DateTime.Now.ToString() + "," + Globals.resultsLevel3 + Globals.resultsLevel4 + Globals.resultsLevel5 + Globals.resultsLevel6 + Globals.resultsLevel7 + Globals.resultsLevel8 + "\n");
            }*/
            
            /******************** LOC01 END *********************************************/
            
            Globals.writeToFile = false;
        }
    }
    IEnumerator SetTheText(string player_data){
        string URL = setURL + player_data;
        WWW www = new WWW (URL);
        yield return www;
    }
}
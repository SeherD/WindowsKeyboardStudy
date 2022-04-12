using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TextManagerPhysical : MonoBehaviour
{
    private int backspaceCounter;
    private int characterCounter;
    private float wordCounter;
    public float startTime=0.0F ;
    public float endTime=0.0F;
    public float totalSeconds;
    private double errorRate;
    public List<KeyCode> keys = new List<KeyCode>();
    private List<string> keyStrings = new List<string>();
    public Text testPhrase;
    public InputField textEntry;
    public string fileName = "LogFile.txt";
    public AddText add;
    public bool isTapStrap = false;
    public TapStrapLearningModule mod;
    // public TMP_InputField peckingKeyboardInput;

    public bool endPhrase;
    void Start()
    {
        add.ReadString();
        add.AddLongText();

        add.GenerateNewTestString();
        textEntry.Select();
        textEntry.ActivateInputField();

        if (isTapStrap)
         {
             mod.learningModule();
         }
 


    }

   private void errorCalculation()
    {
        int msd= MSD(testPhrase.text, textEntry.text);
        int maxLength = Mathf.Max(testPhrase.text.Length, textEntry.text.Length);
        errorRate =((double)msd/(maxLength)) *100;
    } 
    
    private int r(char x, char y)
    {
        if (x == y)
            return 0;
        else
            return 1;

    }

    private int MSD(string A, string B)
    {
        int[,] D = new int[A.Length+1, B.Length+1];
        for (int i = 0; i <= A.Length; i++)
        {
            D[i, 0] =i;
        }

        for (int j = 0;j<=B.Length; j++)
        {
            D[0, j] = j;
        }

        for(int i = 1; i <= A.Length; i++)
        {
            for (int j= 1; j <= B.Length; j++)
            {
                D[i, j] = Mathf.Min(D[i-1,j]+1, D[i,j-1]+1, D[i-1,j-1]+r(A[i-1],B[j-1]));

            }
        }

       
        return D[A.Length, B.Length];

    }
    private void calculateStartTime(string key)
    {
       
        if (textEntry.text.Equals(key))
        { if (startTime == 0.0F)
            {
                startTime = Time.time;
                endPhrase = true;
            }

        }

    }

    
    private void calculateEndTime(KeyCode key)
    {
        if (Input.GetKey(key))
        {
            
               endTime = Time.time;
            if (endPhrase)
            {
                endPhrase = false;
                characterCount();
                add.GenerateNextTest();
                textEntry.Select();
                textEntry.ActivateInputField();

                if (isTapStrap)
                {
                    mod.learningModule();
                }

               
            }
           

        }
        
    }
    int counter = 0;
    public void characterCount()
    {
        foreach (KeyCode key in keys) {
            keyStrings.Add(key.ToString());
            totalSeconds = endTime - startTime;

            if (key==KeyCode.Backspace)
            {
                backspaceCounter++;
                characterCounter--;
            }

            else if (key!=KeyCode.LeftShift && key != KeyCode.RightShift)
            {
                characterCounter++;
            }


        }

        wordCounter = (float)characterCounter / 5;
        errorCalculation();
        writeLog(counter);
        errorRate=totalSeconds=endTime=startTime=wordCounter=characterCounter=backspaceCounter = 0;
        keys.Clear();
        keyStrings.Clear();
        textEntry.text = "";
        counter++;

    }


    private void writeLog(int counter)
    {
        StreamWriter sr;
        if (counter == 0)
            sr = File.CreateText(fileName);
        else
            sr = File.AppendText(fileName);
        sr.WriteLine("Test Phrase:"+ testPhrase.text);
        sr.WriteLine("Transcribed Phrase:" + textEntry.text);
        sr.WriteLine("Number of characters typed: {0}", characterCounter);
        sr.WriteLine("Characters per second: {0}", characterCounter/totalSeconds);
        sr.WriteLine("Number of words typed: {0}", wordCounter);
        sr.WriteLine("Words per minute: {0}", wordCounter / (totalSeconds/60));
        sr.WriteLine("Error rate: {0}", errorRate);
        foreach (string key in keyStrings)
        {
            sr.Write(key+" ");
        }
        sr.Write("\n");
        sr.Close();

    }
    void Update()
    {
        calculateStartTime(testPhrase.text[0].ToString());
        

        if (Input.anyKey)
        {
            if (Input.GetKey(KeyCode.Mouse0) || Input.GetKey(KeyCode.Mouse1) )
            {
                return;
            }
            else
            {
                foreach (KeyCode kcode in System.Enum.GetValues(typeof(KeyCode)))
                {
                    if (Input.GetKeyDown(kcode))
                        keys.Add(kcode);
                }
               


            }

        }
        calculateEndTime(KeyCode.Return);
        }

        
}

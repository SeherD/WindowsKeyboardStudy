using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class TextManagerVR : MonoBehaviour
{
    public float startTime = 0.0F;
    public float endTime = 0.0F;
    private float wordCounter;
    public Text testPhrase;
    public InputField textEntry;
    public float totalSeconds;
    private double errorRate;
    private int backspaceCounter;
    private int characterCounter;
    public string fileName = "LogFile.txt";
    bool enterPressed = false;

    List<string> keyStrings = new List<string>();

    // Start is called before the first frame update
    void Start()
    {
        
    }
    private void errorCalculation()
    {
        int msd = MSD(testPhrase.text, textEntry.text);
        int maxLength = Mathf.Max(testPhrase.text.Length, textEntry.text.Length);
        errorRate = ((double)msd / (maxLength)) * 100;
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
        int[,] D = new int[A.Length + 1, B.Length + 1];
        for (int i = 0; i <= A.Length; i++)
        {
            D[i, 0] = i;
        }

        for (int j = 0; j <= B.Length; j++)
        {
            D[0, j] = j;
        }

        for (int i = 1; i <= A.Length; i++)
        {
            for (int j = 1; j <= B.Length; j++)
            {
                D[i, j] = Mathf.Min(D[i - 1, j] + 1, D[i, j - 1] + 1, D[i - 1, j - 1] + r(A[i - 1], B[j - 1]));

            }
        }


        return D[A.Length, B.Length];

    }

    private void calculateStartTime(string key)
    {
        if (textEntry.text.Equals(key))
        {
            if (startTime == 0.0F)
            {
                startTime = Time.time;
            }

        }

    }

   public void updateKeystrings(string letter)
    {
        keyStrings.Add(letter);
    }
    public void toggleEnter()
    {
        enterPressed = true;
    }

    public void backspaceCounterUpdate()
    {
        backspaceCounter++;
    }
    private void calculateEndTime()
    {
        if (enterPressed)
        {

            endTime = Time.time;

            enterPressed = false;


        }

    }
    int counter = 0;
    public void characterCount()
    {
        totalSeconds = endTime - startTime;
        foreach (char x in textEntry.text)
        {
            characterCounter++;
        }

        wordCounter = (float)characterCounter / 5;
        errorCalculation();
        writeLog(counter);
        errorRate = totalSeconds = endTime = startTime = wordCounter = characterCounter = backspaceCounter = 0;
       
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
        sr.WriteLine("Test Phrase:" + testPhrase.text);
        sr.WriteLine("Transcribed Phrase:" + textEntry.text);
        sr.WriteLine("Number of characters typed: {0}", characterCounter);
        sr.WriteLine("Characters per second: {0}", characterCounter / totalSeconds);
        sr.WriteLine("Number of words typed: {0}", wordCounter);
        sr.WriteLine("Words per minute: {0}", wordCounter / (totalSeconds / 60));
        sr.WriteLine("Error rate: {0}", errorRate);
        foreach (string key in keyStrings)
        {
            sr.Write(key + " ");
        }
        sr.Write("\n");
        sr.Close();

    }
    // Update is called once per frame
    void Update()
    {
        calculateStartTime(testPhrase.text[0].ToString());
        calculateEndTime();
    }
}

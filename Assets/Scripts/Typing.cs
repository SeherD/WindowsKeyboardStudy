using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

using UnityEngine.UI;

public class Typing : MonoBehaviour
{
    // Start is called before the first frame update
    
   public InputField TextHolder;
    public bool shifted = false;
    public TextMeshPro[] letters = new TextMeshPro[26];
    public TextManagerVR manager;

    public object InputField { get; private set; }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Backspace()
    {if (TextHolder.text.Length!=0)
        TextHolder.text=TextHolder.text.Remove(TextHolder.text.Length - 1);
        manager.backspaceCounterUpdate();
       


    }
    public void lowercase()
    {
        foreach( var x in letters)
        {
            x.text = x.text.ToLower();
        }
    }

    public void uppercase()
    {
        foreach (var x in letters)
        {
            x.text = x.text.ToUpper();
        }
    }
    public void Shift()
    {
        if (shifted)
        {
            
            shifted = false;
            lowercase();
        }
        else
        {   
            shifted = true;
            uppercase();
        }
    }

    public void typeText(string letter)
    {


        if (letter == "back")
            Backspace();
        else if( letter == "space")
        {
            TextHolder.text += " ";

        }
        else if (shifted)
        {
            TextHolder.text += letter.ToUpper();
        }
        
        else
        {
            TextHolder.text += letter;

        }

        manager.updateKeystrings(letter);
        
    }
}

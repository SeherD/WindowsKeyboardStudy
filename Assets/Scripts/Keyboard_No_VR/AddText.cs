using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;
using System;


public class AddText : MonoBehaviour
{
    public Image bg;
   
    public bool baseline = false;

    public Dictionary<int, string> phrases = new Dictionary<int, string>();

    public Dictionary<int, string> longText = new Dictionary<int, string>();

    public int longCounter = 1;
    public int shortCounter = 1;

    public Text myText;
    public RectTransform bgImage;
    // Start is called before the first frame update
    void Start()
    {
        
            bg.rectTransform.sizeDelta = new Vector2(300, 30);
            myText.rectTransform.sizeDelta = new Vector2(300, 30);
            shortCounter++;
           
        

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void GenerateNextTest()
    {
        if (!baseline)
        {

       
        if (shortCounter <= 3 && longCounter <= 1)
        {
            GenerateNewTestString();
            bg.rectTransform.sizeDelta = new Vector2(300, 30);
            myText.rectTransform.sizeDelta = new Vector2(300, 30);
            shortCounter++;

        }
        else if (shortCounter == 4 && longCounter <= 1)
        {
            GenerateLongString();
            bg.rectTransform.sizeDelta = new Vector2(400, 120);
            myText.rectTransform.sizeDelta = new Vector2(400, 120);
            bgImage.sizeDelta = new Vector2(400, 120);
                longCounter++;
        }

        }

        else
        {
            if (shortCounter <= 2 && longCounter <= 1)
            {
                GenerateNewTestString();
                bg.rectTransform.sizeDelta = new Vector2(300, 30);
                myText.rectTransform.sizeDelta = new Vector2(300, 30);
                shortCounter++;

            }
            else if (shortCounter == 3 && longCounter <= 1)
            {
                GenerateLongString();
                bg.rectTransform.sizeDelta = new Vector2(400, 120);
                myText.rectTransform.sizeDelta = new Vector2(400, 120);
                bgImage.sizeDelta = new Vector2(400, 120);
                longCounter++;
            }
        }

    }

    int firstLong = -1;
    public void GenerateLongString()
    {
        System.Random rd = new System.Random();
        int rand_num = rd.Next(0, 12);
        Debug.Log(rand_num);
        if (longCounter == 1)
        {
            firstLong = rand_num;
        }
        else
        {
            while (firstLong == rand_num)
            {
                rand_num = rd.Next(0, 12);

            }

        }
       
        
        
        string phrase = "";
        longText.TryGetValue(rand_num, out phrase);
        myText.text = phrase;
    }
    public void GenerateNewTestString()
    {
        System.Random rd = new System.Random();

        int rand_num = rd.Next(0, 500);

        string phrase = "";
        phrases.TryGetValue(rand_num, out phrase);
        myText.text = phrase;
    }
    public void ReadString()
    {
        string path = "Assets/Scripts/phrases2.txt";

        string line = "";
        int i = 0;
        StreamReader reader = new StreamReader(path);
        while ((line = reader.ReadLine()) != null)
        {
            phrases.Add(i, line);
            i++;
        }
        reader.Close();
    }

    public void AddLongText()
    {
        longText.Add(0, "\"It doesn't take much to touch someone's heart, \" Daisy said with a smile on her face. \"It's often just the little things you do that can change a person's day for the better.\" Daisy truly believed this to be the way the world worked, but she didn't understand that she was merely a robot that had been programmed to believe this.");

        longText.Add(1, "Dragons don't exist, they said. They are the stuff of legend and people's imagination. Greg would have agreed with this assessment without a second thought 24 hours ago. But now that there was a dragon staring directly into his eyes, he questioned everything that he had been told.");

        longText.Add(2, "The computer wouldn't start. She banged on the side and tried again. Nothing. She lifted it up and dropped it to the table. Still nothing. She banged her closed fist against the top. It was at this moment she saw the irony of trying to fix the machine with violence.");

        longText.Add(3, "It was a weird concept.Why would I really need to generate a random paragraph? Could I actually learn something from doing so? All these questions were running through her head as she pressed the generate button. To her surprise, she found what she least expected to see.");

        longText.Add(4, "Trees.It was something about the trees. The way they swayed with the wind in unison.The way they shaded the area around them. The sounds of their leaves in the wind and the creaks from the branches as they sway, the trees were making a statement that I just couldn't understand.");

        longText.Add(5, "Spending time at national parks can be an exciting adventure, but this wasn't the type of excitement she was hoping to experience. As she contemplated the situation she found herself in, she knew she'd gotten herself in a little more than she bargained for. It wasn't often that she found herself in a tree staring down at a pack of wolves that were looking to make her their next meal.");

        longText.Add(6, "The lone lamp post of the one - street town flickered, not quite dead but definitely on its way out. Suitcase by her side, she paid no heed to the light, the street or the town.A car was coming down the street and with her arm outstretched and thumb in the air, she had a plan.");

        longText.Add(7, "The alarm went off at exactly 6:00 AM as it had every morning for the past five years. Barbara began her morning and was ready to eat breakfast by 7:00 AM. The day appeared to be as normal as any other, but that was about to change. In fact, it was going to change at exactly 7:23 AM.");

        longText.Add(8, "The choice was red, green, or blue. It didn't seem like an important choice when he was making it, but it was a choice nonetheless. Had he known the consequences at that time, he would likely have considered the choice a bit longer. In the end, he didn't and ended up choosing blue.");

        longText.Add(9, "There wasn't a whole lot more that could be done. It had become a wait-and-see situation with the final results no longer in her control. That didn't stop her from trying to control the situation.She demanded that things be done as she desperately tried to control what couldn't be");

        longText.Add(10, "The day had begun on a bright note. The sun finally peeked through the rain for the first time in a week, and the birds were singing in its warmth. There was no way to anticipate what was about to happen. It was a worst -case scenario and there was no way out of it.");

        longText.Add(11, "\"Begin today!\" That's all the note said. There was no indication from where it came or who may have written it. Had it been meant for someone else? Meghan looked around the room, but nobody made eye contact back. For a brief moment, she thought it might be a message for her to follow her dreams, but ultimately decided it was easier to ignore it as she crumpled it up and threw it away.");

    }
}

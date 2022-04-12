using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TapStrapLearningModule : MonoBehaviour
{
    public Text testPhrase ;
    public TextMeshProUGUI sample;
    public Dictionary<char, List<int>> tapStrap = new Dictionary<char, List<int>>();
    public List<GameObject> fingers;
    public List<KeyCode> keys = new List<KeyCode>();
    private List<string> keyStrings = new List<string>();

    private List<char> doubles = new List<char>();
    private List<char> switches = new List<char>();

    // Start is called before the first frame update
    void Awake()
    {
        tapStrap.Add('a', new List<int> { 1, 0, 0, 0, 0 });
        tapStrap.Add('e', new List<int> { 0, 1, 0, 0, 0 });
        tapStrap.Add('i', new List<int> { 0, 0, 1, 0, 0 });
        tapStrap.Add('o', new List<int> { 0, 0, 0, 1, 0 });
        tapStrap.Add('u', new List<int> { 0, 0, 0, 0, 1 });

        tapStrap.Add('n', new List<int> { 1, 1, 0, 0, 0 });
        tapStrap.Add('t', new List<int> { 0, 1, 1, 0, 0 });
        tapStrap.Add('l', new List<int> { 0, 0, 1, 1, 0 });
        tapStrap.Add('s', new List<int> { 0, 0, 0, 1, 1 }); 
       
        tapStrap.Add('d', new List<int> { 1, 0, 1, 0, 0 });
        tapStrap.Add('m', new List<int> { 0, 1, 0, 1, 0 });
        tapStrap.Add('z', new List<int> { 0, 0, 1, 0, 1 });
        
        tapStrap.Add('k', new List<int> { 1, 0, 0, 1, 0 });
        tapStrap.Add('b', new List<int> { 0, 1, 0, 0, 1 });
        
        tapStrap.Add('y', new List<int> { 1, 0, 0, 0, 1 });
        tapStrap.Add('w', new List<int> { 1, 0, 1, 0, 1 });

        tapStrap.Add('h', new List<int> { 0, 1, 1, 1, 1 });
        tapStrap.Add('c', new List<int> { 1, 0, 1, 1, 1 });
        tapStrap.Add('v', new List<int> { 1, 1, 0, 1, 1 });
        tapStrap.Add('j', new List<int> { 1, 1, 1, 0, 1 });
        tapStrap.Add('r', new List<int> { 1, 1, 1, 1, 0 });

        tapStrap.Add('g', new List<int> { 1, 0, 1, 1, 0 }); 
        tapStrap.Add('x', new List<int> { 0, 1, 0, 1, 1 });

        tapStrap.Add('f', new List<int> { 1, 1, 0, 1, 0 });
        tapStrap.Add('q', new List<int> { 0, 1, 1, 0, 1 });

        tapStrap.Add('p', new List<int> { 1, 1, 0, 0, 1 }); 
    
        tapStrap.Add(' ', new List<int> { 1, 1, 1, 1, 1 });

        tapStrap.Add(',', new List<int> { 1, 0, 0, 0, 0 });
        tapStrap.Add('!', new List<int> { 0, 1, 0, 0, 0 });
        tapStrap.Add('?', new List<int> { 0, 0, 1, 0, 0 });
        tapStrap.Add(':', new List<int> { 0, 0, 0, 1, 0 });
        tapStrap.Add('-', new List<int> { 0, 0, 0, 0, 1 });
        tapStrap.Add('"', new List<int> { 0, 1, 1, 0, 0 });
        tapStrap.Add('\'', new List<int> { 0, 0, 1, 1, 0 });
        tapStrap.Add('.', new List<int> { 1, 1, 1, 1, 1 });

        tapStrap.Add('1', new List<int> { 1, 0, 0, 0, 0 });
        tapStrap.Add('2', new List<int> { 0, 1, 0, 0, 0 });
        tapStrap.Add('3', new List<int> { 0, 0, 1, 0, 0 });
        tapStrap.Add('4', new List<int> { 0, 0, 0, 1, 0 });
        tapStrap.Add('5', new List<int> { 0, 0, 0, 0, 1 });

        tapStrap.Add('6', new List<int> { 1, 1, 0, 0, 0 });
        tapStrap.Add('7', new List<int> { 0, 1, 1, 0, 0 });
        tapStrap.Add('8', new List<int> { 0, 0, 1, 1, 0 });
        tapStrap.Add('9', new List<int> { 0, 0, 0, 1, 1 });
        tapStrap.Add('0', new List<int> { 0, 1, 1, 1, 1 });


        doubles.Add('.');
        doubles.Add(',');
        doubles.Add('!');
        doubles.Add('?');
        doubles.Add(':');
        doubles.Add('-');
        doubles.Add('"');
        doubles.Add('\'');

      
        for(int i=0;i<10;i++)
        switches.Add((char)i);

        //learningModule();

        //Debug.Log("Values added");
    }

    // Update is called once per frame
    void Update()
    {
       
    }
    private IEnumerator waitForKeyPress()
    {
        Debug.Log(testPhrase.text);


        foreach (char a in testPhrase.text)
        {
           
            bool isUpper = char.IsUpper(a);
           
            sample.text = "Letter : " + a;
            var fingerList = tapStrap[char.ToLower(a)];
            for (int i = 0; i < 5; i++)
            {

                if (fingerList[i] == 1)
                {
                   
                    var sphereRenderer = fingers[i].GetComponent<Renderer>();
                    if (doubles.Contains(a))
                    {
                        sphereRenderer.material.SetColor("_Color", Color.blue);
                    }
                    else if (switches.Contains(a))
                    {
                        sphereRenderer.material.SetColor("_Color", Color.magenta);
                    }
                    else if (isUpper)
                    {
                        sphereRenderer.material.SetColor("_Color", Color.yellow);
                    }
                    else
                    {
                        sphereRenderer.material.SetColor("_Color", Color.red);

                    }
                   

                }
            }

            if (a == ' ')
                yield return new WaitUntil(() => (Input.GetKey(KeyCode.Space)));
            else
            {
                Debug.Log("waiting");
                yield return new WaitUntil(() => (Input.GetKey(a.ToString().ToLower())));
            }



            foreach (var x in fingers)
            {
                var sphereRenderer = x.GetComponent<Renderer>();

                //Call SetColor using the shader property name "_Color" and setting the color to red
                sphereRenderer.material.SetColor("_Color", Color.white);
            }
            yield return ExecuteAfterTime(0.1f);
        }
    }

    IEnumerator ExecuteAfterTime(float time)
    {
        yield return new WaitForSeconds(time);


    }
        
   public void learningModule()
    {
        StopAllCoroutines();
        foreach (var x in fingers)
        {
            var sphereRenderer = x.GetComponent<Renderer>();

            //Call SetColor using the shader property name "_Color" and setting the color to red
            sphereRenderer.material.SetColor("_Color", Color.white);
        }
        Debug.Log("Starting coroutine");
        StartCoroutine(waitForKeyPress());
        Debug.Log("Ending coroutine");
    }
}

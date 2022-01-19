using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MonologueBehaviour : MonoBehaviour
{
    public GameObject Textbox;
    public Text NameBox;
    public Text Sentence;
    public string Name;
    public List<string> Monologue;

    private int currentSentence;
    private GameObject background;

    // Start is called before the first frame update
    void Start()
    {
        background = GameObject.Find("background");
        background.SetActive(false);

        currentSentence = 0;
        NameBox.text = Name;
        Sentence.text = Monologue[currentSentence];
    }

    public void Next()
    {
        currentSentence++;
        if(currentSentence < Monologue.Count)
        {
            Sentence.text = Monologue[currentSentence];
        }
        else
        {
            End();
        }
    }

    private void End()
    {
        Textbox.gameObject.SetActive(false);
        background.SetActive(true);

    }
}

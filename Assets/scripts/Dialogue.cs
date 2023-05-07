using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI; 

public class Dialogue : MonoBehaviour {

    public Text textDisplay;
    public string[] sentences;
    private int index;
    public float typingSpeed;

    public GameObject trigger,continueButton,panel;

    void Start() {
        StartCoroutine(TypeSentence());
    }
    void Update()
    {
        if (textDisplay.text == sentences[index])
        {
            continueButton.SetActive(true);
        }


    }
    IEnumerator TypeSentence()
    {
        //textDisplay.text = "";
        foreach (char letter in sentences[index].ToCharArray())
        {
            textDisplay.text += letter;
            yield return new WaitForSeconds(typingSpeed);
        }
    }

    public void NextSentence()
    {
        continueButton.SetActive(false);
        if(index < sentences.Length - 1)
        {
            index++;
            textDisplay.text = "";
            StartCoroutine(TypeSentence());
            AudioManager.instance.Play("Typing");

        }
        else
        {
            textDisplay.text = "";
            continueButton.SetActive(false);
            panel.SetActive(false);
            Destroy(panel);
            trigger.SetActive(false) ;
        }
    }
    public void openpanel()
    {
        panel.SetActive(true);
        AudioManager.instance.Play("Typing");
    }


}

 


//[System.Serializable]
//public class Dialogue
//{

//	public string name;

//	[TextArea(3, 10)]
//	public string[] sentences;

//}

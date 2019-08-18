using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Dialog : MonoBehaviour
{
    public GameObject nextSentButton;

    public GameObject choiceBox;
    private bool hasChosen;

    public GameObject dialogText;
    Text textDisplay;
    public string[] sentences;
    private int index;
    public float typingSpeed;

    // Start is called before the first frame update
    void Start()
    {
        index = 0;
        textDisplay = dialogText.GetComponent<Text>();
        choiceBox.SetActive(false);
        hasChosen = false;

        StartCoroutine(Type());
    }

    public void NextSentence()
    {
        if (index < sentences.Length - 1)
        {
            index++;
            textDisplay.text = "";
            StartCoroutine(Type());
        }
        else if (hasChosen == false)
        {
            choiceBox.SetActive(true);
            hasChosen = true;
        }
        else
        {
            nextSentButton.SetActive(false);
        }
    }

    IEnumerator Type()
    {
        foreach(char letter in sentences[index].ToCharArray())
        {
            textDisplay.text += letter;
            yield return new WaitForSeconds(typingSpeed);
        }
    }
}

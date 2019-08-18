using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class InitialDialog : MonoBehaviour
{
    public string nextSceneName;

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
        else
        {
            SceneManager.LoadScene(nextSceneName);
        }
    }

    IEnumerator Type()
    {
        foreach (char letter in sentences[index].ToCharArray())
        {
            textDisplay.text += letter;
            yield return new WaitForSeconds(typingSpeed);
        }
    }
}

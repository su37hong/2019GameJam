using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LastScene : MonoBehaviour
{
    public GameObject choiceBox;
    public GameObject characterSprite;

    public GameObject gameOver1;
    public GameObject gameOver2;
    public GameObject gameOver3;
    public GameObject stageClearButton;

    public GameObject dialogText;
    Text textDisplay;
    public string[] sentences;
    public float typingSpeed;

    private void Start()
    {
        textDisplay = dialogText.GetComponent<Text>();
    }

    public void gameOver(int i)
    {
        characterSprite.transform.GetChild(0).gameObject.SetActive(false);
        characterSprite.transform.GetChild(1).gameObject.SetActive(true);

        StartCoroutine(Type(i));

        if (i == 1)
            gameOver1.SetActive(true);
        else if (i == 2)
            gameOver2.SetActive(true);
        else if (i == 3)
            gameOver3.SetActive(true);
    }

    public void stageClear()
    {
        characterSprite.transform.GetChild(0).gameObject.SetActive(false);
        characterSprite.transform.GetChild(2).gameObject.SetActive(true);

        StartCoroutine(Type(0));

        stageClearButton.SetActive(true);
    }

    public void endOfThisScene(int how)
    {
        if (how == 1)
            SceneManager.LoadScene("Hair Salon");
        else if (how == 2)
            SceneManager.LoadScene("Planetarium");
        else if (how == 3)
            SceneManager.LoadScene("Cinema");
        else
            SceneManager.LoadScene("True Ending");
    }

    IEnumerator Type(int index)
    {
        choiceBox.SetActive(false);
        textDisplay.text = "";
        foreach (char letter in sentences[index].ToCharArray())
        {
            textDisplay.text += letter;
            yield return new WaitForSeconds(typingSpeed);
        }
    }
}

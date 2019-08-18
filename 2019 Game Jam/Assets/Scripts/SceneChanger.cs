using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneChanger : MonoBehaviour
{
    public GameObject choiceBox;
    public GameObject characterSprite;

    public GameObject gameOverButton;
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

        gameOverButton.SetActive(true);
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
            SceneManager.LoadScene("Game Over");
        else
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
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

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonDown : MonoBehaviour
{
    public void onClick(int num)
    {
        if (num == 1)
            SceneManager.LoadScene("Phase 0");
        else if (num == 2)
            Application.Quit();
        else
            SceneManager.LoadScene("Title");

    }
}

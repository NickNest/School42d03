using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleButtons : MonoBehaviour
{
    public void OnStartButtonClick()
    {
        SceneManager.LoadScene("ex01");
    }

    public void OnExitButtonClick()
    {
        Application.Quit();
    }
}

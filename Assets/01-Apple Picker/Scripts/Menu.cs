using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{

    public void Apple()
    {
        SceneManager.LoadScene("Main-ApplePicker");
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}

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

    public void Title()
    {
        SceneManager.LoadScene("SceneMain");
    }

    public void MissionDemolition()
    {
        SceneManager.LoadScene("Main-MissionDemolition");
    }
    public void BattleCity()
    {
        SceneManager.LoadScene("Main-Prototype 1");
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public void Quit()
    {
        Application.Quit();
        Debug.Log("Quitting Application");
    }

    public void StartGame()
    {
        SceneManager.LoadScene("Story_Line");
    }

    public void Credits()
    {
        SceneManager.LoadScene("End_Screen");
    }

    public void LoadMenu()
    {
        SceneManager.LoadScene("Menu");
    }
}

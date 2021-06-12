using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Menu_Buttons : MonoBehaviour
{
    public void StartGame()
    {
        SceneManager.LoadScene("Game_Scene");
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}

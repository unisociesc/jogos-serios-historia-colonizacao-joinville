using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    public static LevelManager levelManager;

    [Header("Steps")]
    int steps, currentSteps;
    public int stepsToCreateMoreLanes = 12;

    [Header("Texts")]
    public Text stepText, gameOverText;

    void Awake()
    {
        levelManager = this;
        gameOverText.gameObject.SetActive(false);
    }

    //create more lanes
    public void SetSteps()
    {
        steps++;
        stepText.text = steps.ToString();
        currentSteps++;

        if(currentSteps > stepsToCreateMoreLanes)
        {
            currentSteps = 0;
            GetComponent<Level_Creator>().CreateLanes();
        }
    }

    //game over screen w/ points
    public void GameOver()
    {
        gameOverText.gameObject.SetActive(true);
        gameOverText.text = "Game Over \nPontos: " + steps.ToString();
        Invoke("ReloadScene", 2f);
    }

    void ReloadScene()
    {
        SceneManager.LoadScene("Game_Scene");
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ExitGame : MonoBehaviour
{
    public void ExitTheGame()
    {
        Application.Quit();
    }

    public void backGame()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }

    public void ReturnToLevelSelection()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(1);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    private int sceneToContinue;

    public void MenuBack()
    {
        SceneManager.LoadScene("Menu");
    }

    public void ContinueGame()
    {
        sceneToContinue = PlayerPrefs.GetInt("SavedScene");
        SceneManager.LoadScene(sceneToContinue);
    }
}

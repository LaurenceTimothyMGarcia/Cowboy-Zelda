using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    bool gameHasEnded = false;

    private int currentSceneIndex;

    public float restartDelay = 1f;

    public void EndGame()
    {
        if(gameHasEnded == false)
        {
            currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
            PlayerPrefs.SetInt("SavedScene", currentSceneIndex);

            gameHasEnded = true;
            Debug.Log("GameOVER");
            Invoke("Restart", restartDelay);
        }
        
    }

    void Restart()
    {
        SceneManager.LoadScene("Game Over");
    }

}

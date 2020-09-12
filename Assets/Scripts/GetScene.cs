using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GetScene : MonoBehaviour
{

    void Start()
    {
        if (SceneManager.GetActiveScene() == SceneManager.GetSceneByName("SplashScene"))
        {
            loadlevel("StartScene");
        }
    }
    public void loadlevel(string level)
    {
        SceneManager.LoadScene(level);

    }

    public void QuitGame()
    {
        Application.Quit();
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    public void QuitGame()
    {
        Application.Quit();
        Debug.Log("Quitting game");
    }

    public void LoadScene(string sceneName)
    {
        SceneManager.LoadScene("SampleScene");
    }
}

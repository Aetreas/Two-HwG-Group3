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

    IEnumerator sceneLoad()
    {
        yield return new WaitForSeconds(4);
    }
    public void LoadScene(string sceneName)
    {
        sceneLoad();
        SceneManager.LoadScene("SampleScene");
    }
}

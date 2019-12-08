using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour {

    public void LoadNextScene()
    {
        // we want to determine our present scene by determining  the index
        int intCurrentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        // load the next scene
        SceneManager.LoadScene(intCurrentSceneIndex + 1);
    } // LoadNextScene

    public void LoadStartScene()
    {
        // load the start scene
        SceneManager.LoadScene(0);
    }
    public void QuitGame()
    {
        Application.Quit();
    }

} // class SceneLoader

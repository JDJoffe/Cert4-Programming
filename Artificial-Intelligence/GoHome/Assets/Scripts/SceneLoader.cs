using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// When loading and unloading scenes
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public void NextScene()
    {
        // Get the current scene
        Scene currentScene = SceneManager.GetActiveScene();
        // Load the next scene after current scene
        SceneManager.LoadScene(currentScene.buildIndex + 1);
    }
}

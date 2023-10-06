using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScenesManager : MonoBehaviour
{
    public static ScenesManager instance;
    private void Awake()
    {
        instance = this;
    }

    public enum Scene
    {
        Start_Screen,
        Darkened_Adventure
    }

    public void LoadScene(Scene scene)
    {
        SceneManager.LoadScene(scene.ToString());
    }
    public void LoadNewGame()
    {
        //SceneManager.UnloadSceneAsync(Scene.Start_Screen.ToString());
        SceneManager.LoadScene(Scene.Darkened_Adventure.ToString());
        
    }
    public void LoadNextScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    public void LoadMainMenu()
    {
        SceneManager.LoadScene(Scene.Start_Screen.ToString());
    }
}

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
        Darkened_Adventure,
        Death_Screen
    }

    public void LoadScene(Scene scene)
    {
        SceneManager.LoadScene(scene.ToString());
    }
    public void LoadNewGame()
    {
        SceneManager.LoadScene("Darkened_Adventure");
        
    }

    public void LoadDeathScreen()
    {
        SceneManager.LoadScene("Death_Screen");
    }

    public void LoadNextScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    public void LoadMainMenu()
    {
        SceneManager.LoadScene("Start_Screen");
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    [SerializeField] private string currentScene;
    [SerializeField] private GameObject menu, settingsMenu;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void Exit()
    {
        Application.Quit();
        Debug.Log("exit");
    }

    public void play()
    {
       SceneManager.LoadScene(currentScene);
        Debug.Log("play");
    }

    public void settings()
    {
        menu.SetActive(false);
        settingsMenu.SetActive(true);
        Debug.Log("settings");
    }

    public void BackMenu()
    {
        menu.SetActive(true);
        settingsMenu.SetActive(false);
        Debug.Log("Back to menu");
    }
}

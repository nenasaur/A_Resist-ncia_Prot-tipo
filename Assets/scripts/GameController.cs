using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    [SerializeField] GameObject Player, interactText, pauseMenu, settingsMenu;
    private bool pause;



    // Start is called before the first frame update
    void Start()
    {
        pause = false;
    }

    // Update is called once per frame
    void Update()
    {

        //pause the game
        if (Input.GetKeyDown(KeyCode.P))
        {
            //pause
            if (!pause)
            {
                Time.timeScale = 0;
                pause = true;
                pauseMenu.SetActive(true);
            }
            //resume
            else
            {
                Continue();
                
            }
    

        }
         
        
    }

    public void options()
    {
        pauseMenu.SetActive(false);
        settingsMenu.SetActive(true);
        Debug.Log("abrindoOpções");
    }
     public void BackPause()
    {
        pauseMenu.SetActive(true);
        settingsMenu.SetActive(false);
        Debug.Log("Back to menu");
    }
    
    public void Continue()
    {
        Time.timeScale = 1;
        pauseMenu.SetActive(false);
        Debug.Log("continue");
        pause = false;
    }
   
   public void ReturnMenu()
   {
    SceneManager.LoadScene("menu");
   }

   public void seeDocuments(){
    Debug.Log("vendo documentos");
   }

   public void objective(){
    Debug.Log("seeing objectives");
   }
}

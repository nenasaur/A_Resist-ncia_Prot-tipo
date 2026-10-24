using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    [SerializeField] GameObject Player, interactText, pauseMenu;
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
        Debug.Log("abrindoOpções");
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
    Debug.Log("retornando ao menu");
   }

   public void seeDocuments(){
    Debug.Log("vendo documentos");
   }

   public void objective(){
    Debug.Log("seeing objectives");
   }
}

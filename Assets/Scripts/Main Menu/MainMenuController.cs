using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour
{
 

    void Start()
    {
        
    }
    
    void Update()
    {
        
    }


    public void StartGame()
    {
        GameManager.instance.gameRestarted = true;
       
        SceneManager.LoadScene(TagManager.LEVEL1_SCENE);
       
    }

    public void QuitGame()
    {
        Application.Quit();
    }






}

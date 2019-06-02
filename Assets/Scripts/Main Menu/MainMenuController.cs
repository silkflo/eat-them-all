using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuController : MonoBehaviour
{
    [SerializeField]
    private GameObject optionButton, successButton;

    [HideInInspector]
    static public bool fromMainMenu;

    void start()
    {
        
    }

    void Update()
    {

    }


    public void StartGame()
    {
        GameManager.instance.gameRestarted = true;
        AudioManager.instance.ButtonPressedSound();
        fromMainMenu = true;
        SceneManager.LoadScene(TagManager.FROG_SCENE);
        

    }

 
    public void OptionMenu()
    {

        AudioManager.instance.ButtonPressedSound();
     
        SceneManager.LoadScene(TagManager.OPTION_SCENE);
    }


    public void SuccessMenu()
    {
         AudioManager.instance.ButtonPressedSound();
       
        SceneManager.LoadScene(TagManager.SUCCESS_SCENE);
    }


    public void QuitGame()
    {
        AudioManager.instance.ButtonPressedSound();
      
        Application.Quit();
    }


   

}

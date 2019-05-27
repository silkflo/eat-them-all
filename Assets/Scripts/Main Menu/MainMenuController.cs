using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuController : MonoBehaviour
{
    [SerializeField]
    private GameObject optionButton, successButton;


    void Awake()
    {
        
    }

    void Update()
    {

    }


    public void StartGame()
    {
        GameManager.instance.gameRestarted = true;
   
        SceneManager.LoadScene(TagManager.FROG_SCENE);
        

    }

 
    public void OptionMenu()
    {
        SceneManager.LoadScene(TagManager.OPTION_SCENE);
    }


    public void SuccessMenu()
    {
        SceneManager.LoadScene(TagManager.SUCCESS_SCENE);
    }


    public void QuitGame()
    {
        Application.Quit();
    }


   

}

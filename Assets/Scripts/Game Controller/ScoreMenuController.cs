using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class ScoreMenuController : MonoBehaviour
{
    [SerializeField]
    private GameObject backButton;


    void Start()
    {
        
    }

    
    void Update()
    {
        
    }

    public void MainMenu()
    {
        SceneManager.LoadScene(TagManager.MAIN_MENU_SCENE);
    }


  


}

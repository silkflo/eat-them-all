using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelController : MonoBehaviour
{

    static public bool frogLevel;

    [SerializeField]
    private GameObject frogLevelButton, backButton;

    static public bool fromMainMenu;




    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void FrogLevel()
    {
        frogLevel = true; // add other level = false
        fromMainMenu = true;
        SceneManager.LoadScene(TagManager.FROG_SCENE);
    }

    public void OtherLEvel()
    {
        frogLevel = false; // new level = true

    }

    public void MainMenu()
    {
        SceneManager.LoadScene(TagManager.MAIN_MENU_SCENE);
    }


}

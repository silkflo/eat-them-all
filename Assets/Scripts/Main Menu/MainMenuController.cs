using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuController : MonoBehaviour
{
    [SerializeField]
    private GameObject musicButtonOn, musicButtonOff, difficultyButton,scoreButton;


    void Awake()
    {
        InitializeMusicButtonOnStart();
    }

    void Update()
    {

    }


    public void StartGame()
    {
        GameManager.instance.gameRestarted = true;

        SceneManager.LoadScene(TagManager.LEVEL1_SCENE);
        

    }

    public void DifficultyMenu()
    {
        SceneManager.LoadScene(TagManager.DIFFICULTY_MENU_SCENE);
    }



    public void ScoreMenu()
    {
        SceneManager.LoadScene(TagManager.SCORE_SCENE);
    }


    public void QuitGame()
    {
        Application.Quit();
    }


    public void PlayMusic()
    {
       
      
        if (GamePreferences.GetIsMusicOn() == 0)
        {
            GamePreferences.SetIsMusicOn(1);
            MusicController.instance.PlayMusic(true);
            musicButtonOn.SetActive(false);
            musicButtonOff.SetActive(true);
        }
        else if (GamePreferences.GetIsMusicOn() == 1)
        {
            GamePreferences.SetIsMusicOn(0);
            MusicController.instance.PlayMusic(true);
            musicButtonOn.SetActive(true);
            musicButtonOff.SetActive(false);
           
        }
        
    }

   void InitializeMusicButtonOnStart ()
   {
        if (GamePreferences.GetIsMusicOn() == 1)
        {
           
            musicButtonOn.SetActive(false);
            musicButtonOff.SetActive(true);

        }
        else if (GamePreferences.GetIsMusicOn() == 0)
        {
        
            musicButtonOn.SetActive(true);
            musicButtonOff.SetActive(false);

        }

    }

}

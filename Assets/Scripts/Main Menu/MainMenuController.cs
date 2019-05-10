using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuController : MonoBehaviour
{
    [SerializeField]
    private GameObject musicButtonOn, musicButtonOff;


    void Start()
    {
        CheckToPlayTheMusic();
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


    void CheckToPlayTheMusic()
    {
        if (GamePreferences.GetIsMusicOn() == 1)
        {
            MusicController.instance.PlayMusic(true);
          //  musicButtonOn.SetActive(false);
          //  musicButtonOff.SetActive(true);
        }
        else
        {
            MusicController.instance.PlayMusic(false);
           // musicButtonOn.SetActive(true);
           // musicButtonOff.SetActive(false);
        }
    }

    public void PlayMusic()
    {

        print(GamePreferences.GetIsMusicOn());
        if (GamePreferences.GetIsMusicOn() == 0)
        {
            GamePreferences.SetIsMusicOn(1);
            MusicController.instance.PlayMusic(true);
          //  musicButtonOn.SetActive(false);
          //  musicButtonOff.SetActive(true);
        }
        else if (GamePreferences.GetIsMusicOn() == 1)
        {
            GamePreferences.SetIsMusicOn(0);
          //  musicButtonOn.SetActive(true);
           // musicButtonOff.SetActive(false);
        }
        print(GamePreferences.GetIsMusicOn());
    }



}

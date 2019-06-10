using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OptionController : MonoBehaviour
{/* [SerializeField]
    private GameObject musicButtonOn, musicButtonOff, difficultyButton, backButton, helpButton;


    void Start()
    {
        InitializeMusicButtonOnStart();
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void DifficultyMenu()
    {
        AudioManager.instance.ButtonPressedSound();

        SceneManager.LoadScene(TagManager.DIFFICULTY_MENU_SCENE);
    }

    public void MainMenu()
    {
        AudioManager.instance.ButtonPressedSound();
        
        SceneManager.LoadScene(TagManager.MAIN_MENU_SCENE);
    }

    public void HelpMenu()
    {
        AudioManager.instance.ButtonPressedSound();
 
        SceneManager.LoadScene(TagManager.HELP_SCENE);
    }

    public void PlayMusic()
    {
        AudioManager.instance.ButtonPressedSound();
      

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

    void InitializeMusicButtonOnStart()
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
*/

}

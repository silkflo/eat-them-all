using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuController : MonoBehaviour
{
  
    [HideInInspector]
    static public bool fromMainMenu;

    [SerializeField]
    private GameObject musicButtonOn, musicButtonOff, soundFxButtonOn, soundFxButtonOff, scorePanel, speedPanel,
                       easyButton, easyButtonActivated,
                       mediumButton, mediumButtonActivated,
                       hardButton, hardButtonActivated,
                       backButton;

    [SerializeField]
    private Animator buttonPanelAnim, highScoreAnim, bottomButtonPanelAnim, speedAnimPanel;

    [SerializeField]
    private Text easyScoreText, mediumScoreText, hardScoreText;


    void Start()
    {
        SetScoreBasedOnDifficulty();
        SetTheDifficulty();
        InitializeMusicButtonOnStart();
        InitializeSoundButtonOnStart();
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
       
        SceneManager.LoadScene(TagManager.ACHIEVEMENT_SCENE);
    }

    public void HelpMenu()
    {
        AudioManager.instance.ButtonPressedSound();

        SceneManager.LoadScene(TagManager.HELP_SCENE);
    }



    //HIGHSCORE MENU DISPLAY
    public void ScorePanel()
    {
        AudioManager.instance.ButtonPressedSound();
        buttonPanelAnim.SetBool(TagManager.BUTTON_PANEL_PARAMETER, true);
        bottomButtonPanelAnim.SetBool(TagManager.BOTTOM_BUTTON_ICON_PARAMETER, true);

        StartCoroutine(DisplayHighScore());
    }


    IEnumerator DisplayHighScore()
    {
        yield return new WaitForSeconds(1f);
        scorePanel.SetActive(true);
        highScoreAnim.SetBool(TagManager.HIGH_SCORE_VIEW_PARAMETER, true);


    }

    public void BackScoreButton()
    {
        AudioManager.instance.ButtonPressedSound();
        highScoreAnim.SetBool(TagManager.HIGH_SCORE_VIEW_PARAMETER, false);
        StartCoroutine(HideHighScore());
        StartCoroutine(ShowMenu());

    }


    IEnumerator ShowMenu()
    {
        yield return new WaitForSeconds(0.5f);
        buttonPanelAnim.SetBool(TagManager.BUTTON_PANEL_PARAMETER, false);
        bottomButtonPanelAnim.SetBool(TagManager.BOTTOM_BUTTON_ICON_PARAMETER, false);

    }

    IEnumerator HideHighScore()
    {
        yield return new WaitForSeconds(1.5f);
        scorePanel.SetActive(false);
        

    }

    //SPEED MENU DISPLAY
    public void SpeedPanel()
    {
        AudioManager.instance.ButtonPressedSound();
        buttonPanelAnim.SetBool(TagManager.BUTTON_PANEL_PARAMETER, true);
        bottomButtonPanelAnim.SetBool(TagManager.BOTTOM_BUTTON_ICON_PARAMETER, true);

        StartCoroutine(DisplaySpeed());
    }

    IEnumerator DisplaySpeed()
    {
        yield return new WaitForSeconds(1f);
        speedPanel.SetActive(true);
        speedAnimPanel.SetBool(TagManager.SPEED_VIEW_PARAMETER, true);
    }


    public void BackSpeedButton()
    {
        AudioManager.instance.ButtonPressedSound();
        speedAnimPanel.SetBool(TagManager.SPEED_VIEW_PARAMETER, false);
        StartCoroutine(HideSpeed());
        StartCoroutine(ShowMenu());
    }

    IEnumerator HideSpeed()
    {
        yield return new WaitForSeconds(1.5f);
        speedPanel.SetActive(false);
    }







    //QUIT
    public void QuitGame()
    {
        AudioManager.instance.ButtonPressedSound();
      
        Application.Quit();
    }

    //SOUND
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


    void InitializeSoundButtonOnStart()
    {
        if (GamePreferences.GetIsSoundOn() == 1)
        {

            soundFxButtonOn.SetActive(false);
            soundFxButtonOff.SetActive(true);

        }
        else if (GamePreferences.GetIsSoundOn() == 0)
        {

            soundFxButtonOn.SetActive(true);
            soundFxButtonOff.SetActive(false);

        }

    }


    public void PlaySound()
    {
        AudioManager.instance.ButtonPressedSound();
        if (GamePreferences.GetIsSoundOn() == 0)
        {
            GamePreferences.SetIsSoundOn(1);
            // MusicController.instance.PlayMusic(true);
            //AudioManager.instance.PlaySound(true);

            soundFxButtonOn.SetActive(false);
            soundFxButtonOff.SetActive(true);
        }
        else if (GamePreferences.GetIsSoundOn() == 1)
        {
            GamePreferences.SetIsSoundOn(0);
            //  AudioManager.instance.PlaySound(false);
            soundFxButtonOn.SetActive(true);
            soundFxButtonOff.SetActive(false);
        }
    }



    //HIGHSCORE

    void SetEasyScore(int score)
    {
        easyScoreText.text = score.ToString();
    }

    void SetMediumScore(int score)
    {
        mediumScoreText.text = score.ToString();
    }

    void SetHardScore(int score)
    {
        hardScoreText.text = score.ToString();
    }


    void SetScoreBasedOnDifficulty()
    {

        SetEasyScore(GamePreferences.GetEasyDifficultyHighScore());


        SetMediumScore(GamePreferences.GetMediumDifficultyHighScore());


        SetHardScore(GamePreferences.GetHardDifficultyHighScore());

    }



    //SETSPEED


    void SetInitialDifficulty(string difficulty)
    {
        switch (difficulty)
        {
            case "easy":
                easyButtonActivated.SetActive(true);
                mediumButton.SetActive(true);
                hardButton.SetActive(true);
                mediumButtonActivated.SetActive(false);
                hardButtonActivated.SetActive(false);
                easyButton.SetActive(false);
                break;

            case "medium":
                easyButton.SetActive(true);
                mediumButtonActivated.SetActive(true);
                hardButton.SetActive(true);
                easyButtonActivated.SetActive(false);
                hardButtonActivated.SetActive(false);
                mediumButton.SetActive(false);
                break;

            case "hard":
                easyButton.SetActive(true);
                mediumButton.SetActive(true);
                hardButtonActivated.SetActive(true);
                easyButtonActivated.SetActive(false);
                mediumButtonActivated.SetActive(false);
                hardButton.SetActive(false);
                break;
        }
    }



    void SetTheDifficulty()
    {
        if (GamePreferences.GetEasyDifficulty() == 1)
        {
            SetInitialDifficulty("easy");
        }
        if (GamePreferences.GetMediumDifficulty() == 1)
        {
            SetInitialDifficulty("medium");
        }
        if (GamePreferences.GetHardDifficulty() == 1)
        {
            SetInitialDifficulty("hard");
        }
    }


    public void EasyMode()
    {
        AudioManager.instance.ButtonPressedSound();

        GamePreferences.SetEasyDifficulty(1);
        GamePreferences.SetMediumDifficulty(0);
        GamePreferences.SetHardDifficulty(0);

        easyButtonActivated.SetActive(true);
        mediumButton.SetActive(true);
        hardButton.SetActive(true);
        mediumButtonActivated.SetActive(false);
        hardButtonActivated.SetActive(false);
        easyButton.SetActive(false);
    }


    public void MediumMode()
    {
        AudioManager.instance.ButtonPressedSound();

        GamePreferences.SetEasyDifficulty(0);
        GamePreferences.SetMediumDifficulty(1);
        GamePreferences.SetHardDifficulty(0);

        easyButton.SetActive(true);
        mediumButtonActivated.SetActive(true);
        hardButton.SetActive(true);
        easyButtonActivated.SetActive(false);
        hardButtonActivated.SetActive(false);
        mediumButton.SetActive(false);
    }

    public void HardMode()
    {
        AudioManager.instance.ButtonPressedSound();

        GamePreferences.SetEasyDifficulty(0);
        GamePreferences.SetMediumDifficulty(0);
        GamePreferences.SetHardDifficulty(1);

        easyButton.SetActive(true);
        mediumButton.SetActive(true);
        hardButtonActivated.SetActive(true);
        easyButtonActivated.SetActive(false);
        mediumButtonActivated.SetActive(false);
        hardButton.SetActive(false);
    }



}

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
                       backButton, speedButton,
                       achievementMenu, closeAchievement;
   [SerializeField]
    private Animator buttonPanelAnim, highScoreAnim, bottomButtonPanelAnim, speedAnimPanel, achievementAnimPanel;

    [SerializeField]
    private Text easyScoreText, mediumScoreText, hardScoreText;


    private int fadeTime = 2;

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
        AudioManager.instance.ClickStartSound();
        fromMainMenu = true;
        SceneManager.LoadScene(TagManager.FROG_SCENE);
        

    }

    //ACHIEVEMENT
    public void SuccessMenu()
    {
         AudioManager.instance.ClickMenuSound();
        buttonPanelAnim.SetBool(TagManager.BUTTON_PANEL_PARAMETER, true);
        bottomButtonPanelAnim.SetBool(TagManager.BOTTOM_BUTTON_ICON_PARAMETER, true);

        StartCoroutine(DisplayAchievement());

    }

    IEnumerator DisplayAchievement()
    {
        yield return new WaitForSeconds(1f);
        achievementMenu.SetActive(true);
        achievementAnimPanel.SetBool(TagManager.ACHIEVEMENT_FADE_PARAMETER, true);
    }



    public void CloseAchievement()
    {
        AudioManager.instance.ClickBackSound();
     

        achievementAnimPanel.SetBool(TagManager.ACHIEVEMENT_FADE_PARAMETER, false);
        StartCoroutine(DeactivateAchievement());
        StartCoroutine(ShowMenu());
    }

    IEnumerator DeactivateAchievement()
    {
        yield return new WaitForSeconds(2f);
        achievementMenu.SetActive(false);
    }



    public void HelpMenu()
    {
        AudioManager.instance.ClickMenuSound();

        SceneManager.LoadScene(TagManager.HELP_SCENE);
    }



    //HIGHSCORE MENU DISPLAY
    public void ScorePanel()
    {
        AudioManager.instance.ClickMenuSound();
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
        AudioManager.instance.ClickBackSound();
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
        AudioManager.instance.ClickMenuSound();
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
        AudioManager.instance.ClickBackSound();
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
        AudioManager.instance.ClickMenuSound();
      
        Application.Quit();
    }

    //SOUND
    void InitializeMusicButtonOnStart()
    {
        if (GamePreferences.GetIsMusicOn() == 1)
        {
         
         
            musicButtonOn.SetActive(true);
            musicButtonOff.SetActive(false);

        }
        else if (GamePreferences.GetIsMusicOn() == 0)
        {
          
    
            musicButtonOn.SetActive(false);
            musicButtonOff.SetActive(true);

        }

    }


    

    public void PlayMusic()
    {
        AudioManager.instance.ClickMenuSound();
        if (GamePreferences.GetIsMusicOn() == 0)
        {
         
            GamePreferences.SetIsMusicOn(1);
            MusicController.instance.PlayMusic(true);
            musicButtonOn.SetActive(true);
            musicButtonOff.SetActive(false);
            print("music : " + GamePreferences.GetIsMusicOn());
        }
        else if (GamePreferences.GetIsMusicOn() == 1)
        {

            GamePreferences.SetIsMusicOn(0);
            MusicController.instance.PlayMusic(false);
            musicButtonOn.SetActive(false);
            musicButtonOff.SetActive(true);
            print("music : " + GamePreferences.GetIsMusicOn());
        }
    }


    void InitializeSoundButtonOnStart()
    {
        if (GamePreferences.GetIsSoundOn() == 1)
        {

            soundFxButtonOn.SetActive(true);
            soundFxButtonOff.SetActive(false);

        }
        else if (GamePreferences.GetIsSoundOn() == 0)
        {

            soundFxButtonOn.SetActive(false);
            soundFxButtonOff.SetActive(true);

        }

    }


    public void PlaySound()
    {
        AudioManager.instance.ClickMenuSound();
        if (GamePreferences.GetIsSoundOn() == 0)
        {
            GamePreferences.SetIsSoundOn(1);
            // MusicController.instance.PlayMusic(true);
            //AudioManager.instance.PlaySound(true);

            soundFxButtonOn.SetActive(true);
            soundFxButtonOff.SetActive(false);
        }
        else if (GamePreferences.GetIsSoundOn() == 1)
        {
            GamePreferences.SetIsSoundOn(0);
            //  AudioManager.instance.PlaySound(false);
            soundFxButtonOn.SetActive(false);
            soundFxButtonOff.SetActive(true);
        }
    }


    public void OnMouseEnter()
    {
        AudioManager.instance.ClickHoverSound();
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
        AudioManager.instance.ClickMenuSound();

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
        AudioManager.instance.ClickMenuSound();

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
        AudioManager.instance.ClickMenuSound();

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

    public void FacebookButton()
    {
        Application.OpenURL("https://www.facebook.com/sandbunniesstudio/");
        //Application.ExternalEval("window.open(\"https://www.facebook.com/sandbunniesstudio/\")");
    }

}

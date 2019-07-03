using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuController : MonoBehaviour
{
    public static MainMenuController instance;
    [HideInInspector]
    static public bool fromMainMenu;

    [SerializeField]
    private GameObject musicButtonOn, musicButtonOff, soundFxButtonOn, soundFxButtonOff, scorePanel, speedPanel,
                       easyButton, easyButtonActivated,
                       mediumButton, mediumButtonActivated,
                       hardButton, hardButtonActivated,
                       backButton, speedButton,
                       achievementMenu, closeAchievement;

    public  GameObject blockButtonPanel;


    [SerializeField]
    private Animator buttonPanelAnim, highScoreAnim, bottomButtonPanelAnim, speedAnimPanel, achievementAnimPanel;

    [SerializeField]
    private Text easyScoreText, mediumScoreText, hardScoreText;


    private int fadeTime = 2;

    public static int speedLevel;

    public bool music, sound;

    private void Awake()
    {
        MakeInstance();
    }

    void Start()
    {
        music = true;
        sound = true;
        SetScoreBasedOnDifficulty();
       
        InitializeMusicButtonOnStart();
        InitializeSoundButtonOnStart();
    }

    void Update()
    {
        print("level Mode : " + Garter.I.GetData<int>("speedLevel"));

        SetInitialDifficulty();

    }

  

    void MakeInstance()
    {
        if (instance == null)
        {
            instance = this;
        }
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
        Garter.I.OpenSdkWindow("badge");
    }

    //HELP
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
        if (music == true)
        {
            musicButtonOn.SetActive(true);
            musicButtonOff.SetActive(false);

        }
        else if (music == false)
        {
            musicButtonOn.SetActive(false);
            musicButtonOff.SetActive(true);
        }

    }

    

    public void PlayMusic()
    {
        AudioManager.instance.ClickMenuSound();
        if (music == false)
        {
            music = true;
            MusicController.instance.PlayMusic(true);
            musicButtonOn.SetActive(true);
            musicButtonOff.SetActive(false);
        }
        else if (music == true)
        {
            music = false;
            MusicController.instance.PlayMusic(false);
            musicButtonOn.SetActive(false);
            musicButtonOff.SetActive(true);
           
        }
    }


    void InitializeSoundButtonOnStart()
    {
        if (sound == true)
        {

            soundFxButtonOn.SetActive(true);
            soundFxButtonOff.SetActive(false);

        }
        else if (sound == false)
        {

            soundFxButtonOn.SetActive(false);
            soundFxButtonOff.SetActive(true);

        }

    }


    public void PlaySound()
    {
        AudioManager.instance.ClickMenuSound();
        if (sound == false)
        {
            sound = true;
         
            soundFxButtonOn.SetActive(true);
            soundFxButtonOff.SetActive(false);
        }
        else if (sound == true )
        {
            sound = false;
            
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
    void SetInitialDifficulty()
    {

      
        
        if (Garter.I.GetData<int>("speedLevel") == 1)
        {
            easyButtonActivated.SetActive(true);
            mediumButton.SetActive(true);
            hardButton.SetActive(true);
            mediumButtonActivated.SetActive(false);
            hardButtonActivated.SetActive(false);
            easyButton.SetActive(false);
        }
        else if (Garter.I.GetData<int>("speedLevel") == 2)
        {
            easyButton.SetActive(true);
            mediumButtonActivated.SetActive(true);
            hardButton.SetActive(true);
            easyButtonActivated.SetActive(false);
            hardButtonActivated.SetActive(false);
            mediumButton.SetActive(false);
        }

        else if(Garter.I.GetData<int>("speedLevel") == 3)
        {
            easyButton.SetActive(true);
            mediumButton.SetActive(true);
            hardButtonActivated.SetActive(true);
            easyButtonActivated.SetActive(false);
            mediumButtonActivated.SetActive(false);
            hardButton.SetActive(false);
        }

    }
  

    public void EasyMode()
    {
        AudioManager.instance.ClickMenuSound();

        speedLevel = 1;
        Garter.I.PostData<int>("speedLevel", speedLevel);

       

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

        speedLevel = 2;
        Garter.I.PostData<int>("speedLevel", speedLevel);

       

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

        speedLevel = 3;
        Garter.I.PostData<int>("speedLevel", speedLevel);

      

        easyButton.SetActive(true);
        mediumButton.SetActive(true);
        hardButtonActivated.SetActive(true);
        easyButtonActivated.SetActive(false);
        mediumButtonActivated.SetActive(false);
        hardButton.SetActive(false);
    }

    public void FacebookButton()
    {

        Garter.I.OpenSdkWindow("share");
        //Application.OpenURL("https://www.facebook.com/sandbunniesstudio/");
        //Application.ExternalEval("window.open(\"https://www.facebook.com/sandbunniesstudio/\")");
    }

}

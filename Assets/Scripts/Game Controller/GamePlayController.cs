using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GamePlayController : MonoBehaviour
{
    public static GamePlayController instance;

    [SerializeField]
    private Text timeText, scoreText, gameOverScoreText, gameOverTimeText, deactivateScoreAnim;

    [SerializeField]
    private GameObject musicButtonOn, gameOverPanel, musicButtonOff, deactivateScoreObject,
                         soundFxButtonOn, soundFxButtonOff,
                        gameSlowIcon, gameNormalIcon,gameFastIcon, //game view
                        selectSpeedPanel,                //select view
                        choiceSlowIcon,choiceSlowIconActivated, choiceNormalIcon, choiceNormalIconActivated, choiceFastIcon, choiceFastIconActivated,
                        starOn, starOff;

    public GameObject pausePanel, blockButtonPanel;

    
    public Animator gameOverAnim, pauseAnim,fiveScoreAnim,greatAnim, achievementAnimPanel;

    


   

    private float seconds, minutes;

    static public bool panelOnCantMove;
    static public int levelMode;

    private int totalScore;

    private int comboScoreDisplay;

    static public bool startCombo;

  
    private int maxCombo;


    public static bool guideOnStart;


    void Awake()
    {
        MakeInstance();
    }

    private void Start()
    {

        GameFirstStart();
       

        


        if (GamePreferences.GetIsMusicOn() == 0)
        {
            musicButtonOn.SetActive(false);
            musicButtonOff.SetActive(true);
        }
        else if (GamePreferences.GetIsMusicOn() == 1)
        {
            musicButtonOn.SetActive(true);
            musicButtonOff.SetActive(false);
        }


        if (GamePreferences.GetIsSoundOn() == 0)
        {
            soundFxButtonOn.SetActive(false);
            soundFxButtonOff.SetActive(true);
        }
        else if (GamePreferences.GetIsSoundOn() == 1)
        {
            soundFxButtonOn.SetActive(true);
            soundFxButtonOff.SetActive(false);
        }

        DisplaySpeed();
    }

    void Update()
    {
        SetInitialDifficulty();
        PauseGameByEsc();
        PausePanelTouchControl();
        ComboDisplay();
        DisplayStar();


        if (Input.GetKeyDown(KeyCode.M))
        {
            PlayMusic();
        }
    }

    void MakeInstance()
    {
        if (instance == null)
        {
            instance = this;
        }
    }



    //PAUSE PANEL
    public void PauseTheGame()
    {

        if (pausePanel.activeSelf == false || selectSpeedPanel.activeSelf == true)
        {
            if ( gameOverPanel.activeSelf == false  && AchievementManager.Instance.achievementMenu.activeSelf == false)
            {
                if(selectSpeedPanel.activeSelf== true)
                {
                    DisplaySelectSpeed();
                }
                

                
                 AudioManager.instance.PauseSound();
                 panelOnCantMove = true;
                 Time.timeScale = 0f;
                 pausePanel.SetActive(true);
               
                
                 pauseAnim.SetBool(TagManager.PAUSE_PARAMETER, true);




            }
        } else if (selectSpeedPanel.activeSelf== false)
        {
            ResumeGame();
        }
    }

    //GAME RESUME
    public void ResumeGame()
    {
        AudioManager.instance.ClickMenuSound();
       
        panelOnCantMove = false;
        pauseAnim.SetBool(TagManager.PAUSE_PARAMETER, false);
        SpawnSecurity.timeElapsed = 0f;
        StartCoroutine(TimeScaleDelay());
        StartCoroutine(DeativatePausePanel());

        if(AchievementManager.Instance.achievementMenu.activeSelf == true)
        {
            achievementAnimPanel.SetBool(TagManager.ACHIEVEMENT_FADE_PARAMETER, false);
        }

        
     
    }

    IEnumerator TimeScaleDelay()
    {
        yield return new WaitForSecondsRealtime(1f);
        AchievementManager.Instance.achievementMenu.SetActive(false);
        Time.timeScale = 1f;

    }


    IEnumerator DeativatePausePanel()
    {
        yield return new WaitForSeconds(1f);
        pausePanel.SetActive(false);
    }

    public void PauseGameByEsc()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && Lose.gameOver != true 
            && AchievementManager.Instance.achievementMenu.activeSelf == false
             && pausePanel.activeSelf == false)
        {


            PauseTheGame();
        }

        else if (Input.GetKeyDown(KeyCode.Escape) && pausePanel.activeSelf == true )
        {

            ResumeGame();
        }

        

    }

    //RESTART GAME
    public void RestartGame(string sceneName)
    {
        AudioManager.instance.ClickStartSound();

        Time.timeScale = 1f;
        panelOnCantMove = false;
        Lose.gameOver = false;
        Movement.fallingSpeed = -2.5f;
        GameManager.instance.gameRestarted = true;
        gameOverPanel.SetActive(false);

        DeactivateFood.countDeactivateobject = 0;

        SceneManager.LoadScene(TagManager.FROG_SCENE);
     

    }


    //QUIT GAME
    public void QuitGame(string sceneName)
    {
        AudioManager.instance.ClickBackSound();
        Time.timeScale = 1f;
        print("reset score?");
        Score.totalScore = 0;
        SpawnFood.scoreBySpawn = 0;
        DeactivateFood.countDeactivateobject = 0;
        BombScript.scoreByBomb = 0;
        Score.currentTime = 0;
        DeactivateFood.countStartCombo = 0;
        Lose.canLose = true;

        panelOnCantMove = false;
        Lose.gameOver = false;
        Movement.fallingSpeed = -2.5f;
        SceneManager.LoadScene(TagManager.MAIN_MENU_SCENE);
    }


    void PausePanelTouchControl()
    {
        if (pausePanel.activeSelf == true)
        {
            if (Input.GetKeyDown(KeyCode.Return) )
            {
               
                ResumeGame();
            }

            if (Input.GetKeyDown(KeyCode.R))
            {
               
                RestartGame(TagManager.FROG_SCENE);
       
            }



            if (Input.GetKeyDown(KeyCode.Q))
            {
               
                QuitGame(TagManager.MAIN_MENU_SCENE);
            }
        }
    }

 

    //SHOW ACHIEVEMENT
    public void AchievementPanel()
    {
        Garter.I.OpenSdkWindow("badge");
       // blockButtonPanel.SetActive(true);

        
    }





    //DISPLAY SCORE
    public void SetScore(int score)
    {

        scoreText.text = "" + score;

    }


    //DISPLAY TIME
    public void SetTime(float time)
    {
        minutes = (int)(time / 60f);
        seconds = (int)(time % 60f);

        timeText.text = minutes.ToString("00") + ":" + seconds.ToString("00");
    }

    //DISPLAY SPEED
    public void DisplaySpeed()
    {
        if (Garter.I.GetData<int>("speedLevel") == 1)
        {
            gameSlowIcon.SetActive(true);
            gameNormalIcon.SetActive(false);
            gameFastIcon.SetActive(false);

       //    choiceSlowIcon.SetActive(false);
       //    choiceNormalIcon.SetActive(true);
       //    choiceFastIcon.SetActive(true);
       //
       //    choiceSlowIconActivated.SetActive(true);
       //    choiceNormalIconActivated.SetActive(false);
       //    choiceFastIconActivated.SetActive(false);


        }
        else if (Garter.I.GetData<int>("speedLevel") == 2)
        {
            gameSlowIcon.SetActive(false);
            gameNormalIcon.SetActive(true);
            gameFastIcon.SetActive(false);

         //  choiceSlowIcon.SetActive(true);
         //  choiceNormalIcon.SetActive(false);
         //  choiceFastIcon.SetActive(true);
         //
         //  choiceSlowIconActivated.SetActive(false);
         //  choiceNormalIconActivated.SetActive(true);
         //  choiceFastIconActivated.SetActive(false);


        }
        else if (Garter.I.GetData<int>("speedLevel") == 3)
        {
           gameSlowIcon.SetActive(false);
           gameNormalIcon.SetActive(false);
           gameFastIcon.SetActive(true);

        //    choiceSlowIcon.SetActive(true);
        //    choiceNormalIcon.SetActive(true);
        //    choiceFastIcon.SetActive(false);
        //
        //    choiceSlowIconActivated.SetActive(false);
        //    choiceNormalIconActivated.SetActive(false);
        //    choiceFastIconActivated.SetActive(true);
        //

        }
    } 

    public void DisplaySelectSpeed()
    {
      
            if (selectSpeedPanel.activeSelf == false)
            {
                 if (pausePanel.activeSelf == true)
                 {
                      AudioManager.instance.ClickMenuSound();
                      pausePanel.SetActive(false);
                      Time.timeScale = 1f;
                      panelOnCantMove = false;
                      SpawnSecurity.timeElapsed = 0f;
                      AchievementManager.Instance.achievementMenu.SetActive(false);
                 }

                 if(AchievementManager.Instance.achievementMenu.activeSelf== true)
                 {
                AchievementPanel();
                 }


            AudioManager.instance.ClickMenuSound();
            selectSpeedPanel.SetActive(true);
        


                Time.timeScale = 0f;
            }
            else if(selectSpeedPanel.activeSelf == true)
            {
            AudioManager.instance.ClickBackSound();
            selectSpeedPanel.SetActive(false);
            
                Time.timeScale = 1f;
            }

      


     }


    void SetInitialDifficulty()
    {

        if (Garter.I.GetData<int>("speedLevel") == 1)
        {
            choiceSlowIcon.SetActive(false);
            choiceNormalIcon.SetActive(true);
            choiceFastIcon.SetActive(true);

            choiceSlowIconActivated.SetActive(true);
            choiceNormalIconActivated.SetActive(false);
            choiceFastIconActivated.SetActive(false);
        }
        else if (Garter.I.GetData<int>("speedLevel") == 2)
        {
            choiceSlowIcon.SetActive(true);
            choiceNormalIcon.SetActive(false);
            choiceFastIcon.SetActive(true);

            choiceSlowIconActivated.SetActive(false);
            choiceNormalIconActivated.SetActive(true);
            choiceFastIconActivated.SetActive(false);
        }

        else if (Garter.I.GetData<int>("speedLevel") == 3)
        {
            choiceSlowIcon.SetActive(true);
            choiceNormalIcon.SetActive(true);
            choiceFastIcon.SetActive(false);

            choiceSlowIconActivated.SetActive(false);
            choiceNormalIconActivated.SetActive(false);
            choiceFastIconActivated.SetActive(true);
        }

    }


    public void EasyMode()
    {
        AudioManager.instance.ClickStartSound();

        MainMenuController.speedLevel = 1;
        Garter.I.PostData<int>("speedLevel", MainMenuController.speedLevel);

        

        choiceSlowIconActivated.SetActive(true);
        choiceNormalIcon.SetActive(true);
        choiceFastIcon.SetActive(true);
        choiceNormalIconActivated.SetActive(false);
        choiceFastIconActivated.SetActive(false);
        choiceSlowIcon.SetActive(false);

        RestartGame(TagManager.FROG_SCENE);

    }


    public void MediumMode()
    {
        AudioManager.instance.ClickStartSound();

        MainMenuController.speedLevel = 2;
        Garter.I.PostData<int>("speedLevel", MainMenuController.speedLevel);

        choiceSlowIcon.SetActive(true);
        choiceNormalIconActivated.SetActive(true);
        choiceFastIcon.SetActive(true);
        choiceSlowIconActivated.SetActive(false);
        choiceFastIconActivated.SetActive(false);
        choiceNormalIcon.SetActive(false);

        RestartGame(TagManager.FROG_SCENE);

    }

    public void HardMode()
    {
        AudioManager.instance.ClickStartSound();

        MainMenuController.speedLevel = 3;
        Garter.I.PostData<int>("speedLevel", MainMenuController.speedLevel);

        choiceSlowIcon.SetActive(true);
        choiceNormalIcon.SetActive(true);
        choiceFastIconActivated.SetActive(true);
        choiceSlowIconActivated.SetActive(false);
        choiceNormalIconActivated.SetActive(false);
        choiceFastIcon.SetActive(false);

        RestartGame(TagManager.FROG_SCENE);

    }


    //DISPLAY GAMEOVER
    public void GameOver(int score, float time)
    {
        if (Lose.gameOver == true)
        {
            print("print you lose");

        
            panelOnCantMove = true;
            gameOverPanel.SetActive(true);
            gameOverAnim.SetBool(TagManager.GAMEOVER_PARAMETER, true);

            gameOverScoreText.text = score.ToString();
        
        
            minutes = (int)(time / 60f);
            seconds = (int)(time % 60f);
            gameOverTimeText.text = minutes.ToString("00") + ":" + seconds.ToString("00");
           
      

            Time.timeScale = 0f;

            if (AchievementManager.Instance.achievementMenu.activeSelf == false)
            {
                if (Input.GetKeyDown(KeyCode.Return))
                {

                    RestartGame(TagManager.FROG_SCENE);

                }

                if (Input.GetKeyDown(KeyCode.Escape))
                {

                    QuitGame(TagManager.MAIN_MENU_SCENE);
                }


                if (Input.GetKeyDown(KeyCode.Q))
                {
                    QuitGame(TagManager.MAIN_MENU_SCENE);
                }
            }
        }
    }

    //SOUND
    public void PlayMusic()
    {
        AudioManager.instance.ClickMenuSound();
        if (GamePreferences.GetIsMusicOn() == 0)
        {
            GamePreferences.SetIsMusicOn(1);
            MusicController.instance.PlayMusic(true);
            musicButtonOn.SetActive(true);
            musicButtonOff.SetActive(false);
        }
        else if (GamePreferences.GetIsMusicOn() == 1)
        {
            GamePreferences.SetIsMusicOn(0);
            MusicController.instance.PlayMusic(false);
            musicButtonOn.SetActive(false);
            musicButtonOff.SetActive(true);
        }
    }


    public void PlaySound()
    {
        AudioManager.instance.ClickMenuSound();
        if (GamePreferences.GetIsSoundOn() == 0)
        {
            GamePreferences.SetIsSoundOn(1);
           

            soundFxButtonOn.SetActive(true);
            soundFxButtonOff.SetActive(false);
        }
        else if (GamePreferences.GetIsSoundOn() == 1)
        {
            GamePreferences.SetIsSoundOn(0);
        
            soundFxButtonOn.SetActive(false);
            soundFxButtonOff.SetActive(true);
        }
    }


    //COMBO
    public void ComboDisplay()
    {

        if (DeactivateFood.countStartCombo >0)
        {
            fiveScoreAnim.SetBool(TagManager.DISPLAY_5_PARAMETER, true);
            deactivateScoreAnim.text =  DeactivateFood.countStartCombo.ToString();
        }
        else
        {
            fiveScoreAnim.SetBool(TagManager.DISPLAY_5_PARAMETER, false);
        }

    }

    public void DisplayStar()
    {
        if(Lose.canLose == true)
        {
            starOn.SetActive(false);
            starOff.SetActive(true);
        }
        else if( Lose.canLose == false)
        {
            starOn.SetActive(true);
            starOff.SetActive(false);
        }
    }



    public void GameFirstStart()
    {
        if (GamePreferences.GetFirstTimeGamePlay() == 0)
        {
           
            guideOnStart = true;
            GamePreferences.SetFirstTimeGamePlay(1);
            SceneManager.LoadScene(TagManager.HELP_SCENE);
            print("1st start :  " + GamePreferences.GetFirstTimeGamePlay());

        } else if(GamePreferences.GetFirstTimeGamePlay() == 1)
        {
            guideOnStart = false;
            AudioManager.instance.LetsGoSound();
        }
    }
  


}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GamePlayController : MonoBehaviour
{
    public static GamePlayController instance;

    [SerializeField]
    private Text timeText, scoreText, gameOverScoreText, gameOverTimeText, deactivateScoreAnim, greatText, speedTextGameOver, speedTextPause, speedTextGeneral;

    [SerializeField]
    private GameObject musicButtonOn, gameOverPanel, musicButtonOff, deactivateScoreObject,
                         moveGuidePanel, bombGuidePanel, exploseGuidePanel, loseGuidePanel, shortcutGuidePanel,
                        guidePanel, soundFxButtonOn, soundFxButtonOff,
                        gameSlowIcon, gameNormalIcon,gameFastIcon,
                        pauseSlowIcon, pauseNormalIcon,pauseFastIcon,
                        gameoverSlowIcon,gameoverNormalIcon, gameOverFastIcon;

    public GameObject pausePanel;

    [SerializeField]
    private Button nextMoveButton,
                    previousBombButton, nextBombButton,
                    previousExploseButton, NextExploseButton,
                    previousLoseButton, nextLoseButton,
                    previousShortcutButton;


    [SerializeField]
    private Animator gameOverAnim, pauseAnim, greatAnim, fiveScoreAnim;

    private bool pauseAnimBoool;

    private float seconds, minutes;

    static public bool panelOnCantMove;
    static public int levelMode;

    private int totalScore;

    private int comboScoreDisplay;

    static public bool startCombo;

    [HideInInspector]
    public bool greatBoolAnim, awesomeBoolAnim, amazingBoolAnim;


    private int maxCombo;


    public static bool guideOnStart;


    void Awake()
    {
        MakeInstance();
    }

    private void Start()
    {

        GameFirstStart();
       

        if (GamePreferences.GetEasyDifficulty() == 1)
        {
            levelMode = 1;
            print("it's easy");
        }
        if (GamePreferences.GetMediumDifficulty() == 1)
        {
            levelMode = 2;
            print("It's medium level");
        }
        if (GamePreferences.GetHardDifficulty() == 1)
        {
            levelMode = 3;
            print("That's Hard");
        }


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

        SetSpeed();
    }

    void Update()
    {
        PauseGameByEsc();
        PausePanelTouchControl();
        ComboDisplay();
        

        if (Input.GetKeyDown(KeyCode.S))
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

        if (pausePanel.activeSelf == false)
        {
            if (AchievementManager.Instance.achievementMenu.activeSelf == false && gameOverPanel.activeSelf == false)
            { 
                 AudioManager.instance.PauseSound();
                 panelOnCantMove = true;
                 Time.timeScale = 0f;
                 pausePanel.SetActive(true);
                 pauseAnimBoool = true;
                 pauseAnim.SetBool(TagManager.PAUSE_PARAMETER, pauseAnimBoool);




                 if (levelMode == 1)
                 {
                     speedTextPause.text = "slow";
                 }
                 else if (levelMode == 2)
                 {
                     speedTextPause.text = "normal";
                 }
                 else if (levelMode == 3)
                 {
                     speedTextPause.text = "fast";
                 }

            }
        } else
        {
            ResumeGame();
        }
    }

    //GAME RESUME
    public void ResumeGame()
    {
        AudioManager.instance.ClickMenuSound();
        Time.timeScale = 1f;
        panelOnCantMove = false;
        pauseAnim.SetBool(TagManager.PAUSE_PARAMETER, false);
        SpawnSecurity.timeElapsed = 0f;
        pausePanel.SetActive(false);
        AchievementManager.Instance.achievementMenu.SetActive(false);
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
        AudioManager.instance.ClickMenuSound();

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
        AudioManager.instance.ClickMenuSound();
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
        AudioManager.instance.ClickMenuSound();

        AchievementManager.Instance.achievementMenu.SetActive(!AchievementManager.Instance.achievementMenu.activeSelf);

        if (AchievementManager.Instance.achievementMenu.activeSelf == true)
        {
            Time.timeScale = 0f;
        }
        else
        {
            Time.timeScale = 1f;
        }
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
    public void SetSpeed()
    {
        if (levelMode == 1)
        {
            speedTextGeneral.text = "slow";

            gameSlowIcon.SetActive(true);
            pauseSlowIcon.SetActive(true);
            gameoverSlowIcon.SetActive(true);

            gameNormalIcon.SetActive(false);
            pauseNormalIcon.SetActive(false);
            gameoverNormalIcon.SetActive(false);

            gameFastIcon.SetActive(false);
            pauseFastIcon.SetActive(false);
            gameOverFastIcon.SetActive(false);
        }
        else if (levelMode == 2)
        {
            speedTextGeneral.text = "normal";

            gameSlowIcon.SetActive(false);
            pauseSlowIcon.SetActive(false);
            gameoverSlowIcon.SetActive(false);

            gameNormalIcon.SetActive(true);
            pauseNormalIcon.SetActive(true);
            gameoverNormalIcon.SetActive(true);

            gameFastIcon.SetActive(false);
            pauseFastIcon.SetActive(false);
            gameOverFastIcon.SetActive(false);
        }
        else if (levelMode == 3)
        {
            speedTextGeneral.text = "fast";

            gameSlowIcon.SetActive(false);
            pauseSlowIcon.SetActive(false);
            gameoverSlowIcon.SetActive(false);

            gameNormalIcon.SetActive(false);
            pauseNormalIcon.SetActive(false);
            gameoverNormalIcon.SetActive(false);

            gameFastIcon.SetActive(true);
            pauseFastIcon.SetActive(true);
            gameOverFastIcon.SetActive(true);
        }
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

            if (levelMode == 1)
            {
                speedTextGameOver.text = "slow";
            }
            else if (levelMode == 2)
            {
                speedTextGameOver.text = "normal";
            }
            else if (levelMode == 3)
            {
                speedTextGameOver.text = "fast";
            }


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


    //ITEM DEACTIVATE
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

        if (DeactivateFood.countStartCombo >=4 && DeactivateFood.countStartCombo <8)
        {
            

            GameManager.instance.greatBoolAnim = true;
            greatText.text = "GREAT";
            StartCoroutine(DisplayText());
        }

       else if (DeactivateFood.countStartCombo >= 8 && DeactivateFood.countStartCombo < 12)
        {

            
            GameManager.instance.awesomeBoolAnim = true;
            greatText.text = "AWESOME";
            StartCoroutine(DisplayText());
        }
      else  if (DeactivateFood.countStartCombo >= 12 )
        {
           
            GameManager.instance.amazingBoolAnim = true;
            greatText.text = "AMAZING";
            StartCoroutine(DisplayText());
        }
        else
        {
            greatAnim.SetBool(TagManager.DISPLAY_GREAT_PARAMETER, false);
            StartCoroutine(SetTextNull());

        }
        IEnumerator DisplayText()
        {
            yield return new WaitForSeconds(1f);
            greatAnim.SetBool(TagManager.DISPLAY_GREAT_PARAMETER, true);
            GameManager.instance.greatBoolAnim = false;
            GameManager.instance.awesomeBoolAnim = false;
            GameManager.instance.amazingBoolAnim = false;
        }

        IEnumerator SetTextNull()
        {

            yield return new WaitForSeconds(2f);
            greatText.text = "";
            startCombo = false;

        }

    }

    //GUIDE

    public void NextMoveButton() {
        AudioManager.instance.ClickMenuSound();
        moveGuidePanel.SetActive(false);
        bombGuidePanel.SetActive(true);
    }

    public void PreviousBombButton() {
        AudioManager.instance.ClickMenuSound();
        moveGuidePanel.SetActive(true);
        bombGuidePanel.SetActive(false);
    }

    public void NextBombButton() {
        AudioManager.instance.ClickMenuSound();
        bombGuidePanel.SetActive(false);
        exploseGuidePanel.SetActive(true);
    }

    public void PreviousExploseButton() {
        AudioManager.instance.ClickMenuSound();
        bombGuidePanel.SetActive(true);
        exploseGuidePanel.SetActive(false);
    }

    public void NextExplodeButton() {
        AudioManager.instance.ClickMenuSound();
        exploseGuidePanel.SetActive(false);
        loseGuidePanel.SetActive(true);
    }

    public void PreviousLoseButton() {
        AudioManager.instance.ClickMenuSound();
        loseGuidePanel.SetActive(false);
        exploseGuidePanel.SetActive(true);
    }

    public void NextLoseButton() {
        AudioManager.instance.ClickMenuSound();
        shortcutGuidePanel.SetActive(true);
        loseGuidePanel.SetActive(false);
    }

    public void PreviousShortcutButton() {
        AudioManager.instance.ClickMenuSound();
        shortcutGuidePanel.SetActive(false);
        loseGuidePanel.SetActive(true);
    }

    public void GuideButtons()
    {
        /*
             nextMoveButton.onClick.AddListener(() => {
             moveGuidePanel.SetActive(false);
             bombGuidePanel.SetActive(true);
             });

             previousBombButton.onClick.AddListener(() => {
                 moveGuidePanel.SetActive(true);
                 bombGuidePanel.SetActive(false);
             });

             nextBombButton.onClick.AddListener(() => {
                 bombGuidePanel.SetActive(false);
                 exploseGuidePanel.SetActive(true);
             });

             previousExploseButton.onClick.AddListener(() => {
                 exploseGuidePanel.SetActive(false);
                 bombGuidePanel.SetActive(true);
             });

             NextExploseButton.onClick.AddListener(() => {
                 exploseGuidePanel.SetActive(false);
                 loseGuidePanel.SetActive(true);
             });

             previousLoseButton.onClick.AddListener(() =>
             {
                 loseGuidePanel.SetActive(false);
                 exploseGuidePanel.SetActive(true);
             });

             nextLoseButton.onClick.AddListener(() => {
                 shortcutGuidePanel.SetActive(true);
                 loseGuidePanel.SetActive(false);

             });

             previousShortcutButton.onClick.AddListener(() => {
                 shortcutGuidePanel.SetActive(false);
                 loseGuidePanel.SetActive(true);
             });

         */
    }

    public void GameFirstStart()
    {
        if (GamePreferences.GetFirstTimeGamePlay() == 0)
        {
            /*  Time.timeScale = 0f;

               guidePanel.SetActive(true);

               
               */
            guideOnStart = true;
            GamePreferences.SetFirstTimeGamePlay(1);
            SceneManager.LoadScene(TagManager.HELP_SCENE);
            print("1st start :  " + GamePreferences.GetFirstTimeGamePlay());

        } else if(GamePreferences.GetFirstTimeGamePlay() == 1)
        {
            guideOnStart = false;
        }
    }
  


}

﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GamePlayController : MonoBehaviour
{
    public static GamePlayController instance;

    [SerializeField]
    private Text timeText, scoreText, gameOverScoreText, gameOverTimeText, deactivateScoreAnim, greatText;

    [SerializeField]
    private GameObject musicButtonOn, gameOverPanel, musicButtonOff, deactivateScoreObject,
                         moveGuidePanel, bombGuidePanel, exploseGuidePanel, loseGuidePanel, shortcutGuidePanel,
                        guidePanel;

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
            musicButtonOn.SetActive(true);
            musicButtonOff.SetActive(false);
        }
        else if (GamePreferences.GetIsMusicOn() == 1)
        {
            musicButtonOn.SetActive(false);
            musicButtonOff.SetActive(true);
        }
    }

    void Update()
    {
        PauseGameByEsc();
        PausePanelTouchControl();
        ItemDeactivateCount();

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



    //GAME PAUSE
    public void PauseTheGame()
    {
        AudioManager.instance.PauseSound();
        panelOnCantMove = true;
        Time.timeScale = 0f;
        pausePanel.SetActive(true);
        pauseAnimBoool = true;
        pauseAnim.SetBool(TagManager.PAUSE_PARAMETER, pauseAnimBoool);
    }

    //GAME RESUME
    public void ResumeGame()
    {
        AudioManager.instance.ButtonPressedSound();
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

        else if (Input.GetKeyDown(KeyCode.Escape) && pausePanel.activeSelf == true)
        {

            ResumeGame();
        }

        

    }

    //RESTART GAME
    public void RestartGame(string sceneName)
    {
        AudioManager.instance.ButtonPressedSound();

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
        AudioManager.instance.ButtonPressedSound();
        Time.timeScale = 1f;
        print("reset score?");
        Score.totalScore = 0;
        SpawnFood.scoreBySpawn = 0;
        DeactivateFood.countDeactivateobject = 0;
        BombScript.scoreByBomb = 0;
        Score.currentTime = 0;

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
        AudioManager.instance.ButtonPressedSound();

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


    //DISPLAY GAMEOVER
    public void GameOver(int score, float time)
    {
        if (Lose.gameOver == true)
        {
            print("print you lose");
            AudioManager.instance.GameOverSound();

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

    //MUSIC
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


    //ITEM DEACTIVATE
    public void ItemDeactivateCount()
    {
/*
        int countnow;
        int countafter;
       

        countnow = DeactivateFood.countDeactivateobject;
        //  print("countnow : " + countnow);

        StartCoroutine(CountAfter());

        IEnumerator CountAfter()
        {
            yield return new WaitForSeconds(5f);

            countafter = DeactivateFood.countDeactivateobject;
            comboScoreDisplay = countafter - countnow;
            // print("countafter : " + countafter);
            // print("Total Combo = " + comboScoreDisplay);

          

            if (comboScoreDisplay > 0)
            {
               
                fiveScoreAnim.SetBool(TagManager.DISPLAY_5_PARAMETER, true);
                deactivateScoreAnim.text = "X " + comboScoreDisplay.ToString();
            }
            else
            {
                fiveScoreAnim.SetBool(TagManager.DISPLAY_5_PARAMETER, false);
            }


            if (comboScoreDisplay >= 1 && comboScoreDisplay < 2 && greatText.text == "") //4-8
            {

                
                AudioManager.instance.GreatSound();

                GameManager.instance.greatBoolAnim = true;
                greatText.text = "GREAT";
                StartCoroutine(DisplayText());
            }
            else if (comboScoreDisplay >= 2 && comboScoreDisplay < 3 && greatText.text == "") //8-12
            {
                
                AudioManager.instance.AwesomeSound();
                GameManager.instance.awesomeBoolAnim = true;
                greatText.text = "AWESOME";
                StartCoroutine(DisplayText());
            }
            else if (comboScoreDisplay >= 4 && greatText.text == "") //12
            {
               
                AudioManager.instance.AmazingSound();
                GameManager.instance.amazingBoolAnim = true;
                greatText.text = "AMAZING";
                StartCoroutine(DisplayText());
            }
            else
            {
                greatAnim.SetBool(TagManager.DISPLAY_GREAT_PARAMETER, false);
                StartCoroutine(SetTextNull());

            }

            IEnumerator SetTextNull()
            {
                
                yield return new WaitForSeconds(2f);
                greatText.text = "";
                startCombo = false;
              
            }

            IEnumerator DisplayText()
            {
                yield return new WaitForSeconds(1f);
                greatAnim.SetBool(TagManager.DISPLAY_GREAT_PARAMETER, true);
                GameManager.instance.greatBoolAnim = false;
                GameManager.instance.awesomeBoolAnim = false;
                GameManager.instance.amazingBoolAnim = false;
            }
          
        }

*/
        if (DeactivateFood.countStartCombo >0)
        {
            fiveScoreAnim.SetBool(TagManager.DISPLAY_5_PARAMETER, true);
            deactivateScoreAnim.text = "X " + DeactivateFood.countStartCombo.ToString();
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
        AudioManager.instance.ButtonPressedSound();
        moveGuidePanel.SetActive(false);
        bombGuidePanel.SetActive(true);
    }

    public void PreviousBombButton() {
        AudioManager.instance.ButtonPressedSound();
        moveGuidePanel.SetActive(true);
        bombGuidePanel.SetActive(false);
    }

    public void NextBombButton() {
        AudioManager.instance.ButtonPressedSound();
        bombGuidePanel.SetActive(false);
        exploseGuidePanel.SetActive(true);
    }

    public void PreviousExploseButton() {
        AudioManager.instance.ButtonPressedSound();
        bombGuidePanel.SetActive(true);
        exploseGuidePanel.SetActive(false);
    }

    public void NextExplodeButton() {
        AudioManager.instance.ButtonPressedSound();
        exploseGuidePanel.SetActive(false);
        loseGuidePanel.SetActive(true);
    }

    public void PreviousLoseButton() {
        AudioManager.instance.ButtonPressedSound();
        loseGuidePanel.SetActive(false);
        exploseGuidePanel.SetActive(true);
    }

    public void NextLoseButton() {
        AudioManager.instance.ButtonPressedSound();
        shortcutGuidePanel.SetActive(true);
        loseGuidePanel.SetActive(false);
    }

    public void PreviousShortcutButton() {
        AudioManager.instance.ButtonPressedSound();
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
           Time.timeScale = 0f;
            
            guidePanel.SetActive(true);

            GamePreferences.SetFirstTimeGamePlay(1);
        } else if(GamePreferences.GetFirstTimeGamePlay() == 1)
        {
            Destroy(guidePanel);
        }
    }
  


}

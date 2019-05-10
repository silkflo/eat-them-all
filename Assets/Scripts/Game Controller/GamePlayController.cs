using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GamePlayController : MonoBehaviour
{
    public static GamePlayController instance;

    [SerializeField]
    private Text timeText, scoreText, gameOverScoreText, gameOverTimeText;

    [SerializeField]
    private GameObject pausePanel, musicButtonOn, gameOverPanel, musicButtonOff;

    [SerializeField]
    private Animator gameOverAnim;

    private float seconds, minutes;

    static public bool panelOnCantMove;

    private int totalScore;

    static public float totalTimeScore;

    void Awake()
    {
        MakeInstance();


    }

    private void Start()
    {

    }

    void Update()
    {


        PauseGameByEsc();
        PausePanelTouchControl();


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
        panelOnCantMove = true;
        Time.timeScale = 0f;
        pausePanel.SetActive(true);
       
    }

    public void PauseGameByEsc()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && Lose.gameOver != true)
        {
         
            if (pausePanel.activeSelf == false)
            {
                panelOnCantMove = true;
                Time.timeScale = 0f;
                pausePanel.SetActive(true);
                
            }
            else
            {
               
                Time.timeScale = 1f;
                panelOnCantMove = false;
                pausePanel.SetActive(false);
            }
        }

    }

    void PausePanelTouchControl()
    {
        if (pausePanel.activeSelf == true)
        {

            print("Pause");

            if (Input.GetKeyDown(KeyCode.Return))
            {
                ResumeGame();
            }


            if (Input.GetKeyDown(KeyCode.R))
            {
                RestartGame(TagManager.LEVEL1_SCENE);
            }

            if (Input.GetKeyDown(KeyCode.M))
            {
                //music ON OFF
            }

            if (Input.GetKeyDown(KeyCode.Q))
            {
                QuitGame(TagManager.MAIN_MENU_SCENE);
            }
        }
    }

    //GAME RESUME
    public void ResumeGame()
    {
        Time.timeScale = 1f;
        panelOnCantMove = false;
        pausePanel.SetActive(false);
        SpawnSecurity.timeElapsed = 0f;
    }

    //QUIT GAME
    public void QuitGame(string sceneName)
    {
        Time.timeScale = 1f;
        panelOnCantMove = false;
        Lose.gameOver = false;
        Movement.fallingSpeed = -2.5f;
        SceneManager.LoadScene(TagManager.MAIN_MENU_SCENE);
    }



    //RESTART GAME
    public void RestartGame(string sceneName)
    {
        Time.timeScale = 1f;
        panelOnCantMove = false;
        Lose.gameOver = false;
        Movement.fallingSpeed = -2.5f;
        GameManager.instance.gameRestarted = true;
        gameOverPanel.SetActive(false);
        SceneManager.LoadScene(TagManager.LEVEL1_SCENE);
     
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
            panelOnCantMove = true;
            gameOverPanel.SetActive(true);
            gameOverAnim.SetBool(TagManager.GAMEOVER_PARAMETER, true);

            gameOverScoreText.text = score.ToString();

            minutes = (int)(time / 60f);
            seconds = (int)(time % 60f);
            gameOverTimeText.text = minutes.ToString("00") + ":" + seconds.ToString("00");

           

            Time.timeScale = 0f;

            if (Input.GetKeyDown(KeyCode.Return))
            {
                RestartGame(TagManager.LEVEL1_SCENE);
            }


            if (Input.GetKeyDown(KeyCode.Q))
            {
                QuitGame(TagManager.MAIN_MENU_SCENE);
            }

        }
    }

    //MUSIC

    void CheckToPlayTheMusic()
    {
        if (GamePreferences.GetIsMusicOn() == 1)
        {
            MusicController.instance.PlayMusic(true);
            musicButtonOn.SetActive(false);
            musicButtonOff.SetActive(true);
        }
        else
        {
            MusicController.instance.PlayMusic(false);
            musicButtonOn.SetActive(true);
            musicButtonOff.SetActive(false);
        }
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
            musicButtonOn.SetActive(true);
            musicButtonOff.SetActive(false);
        }
    }





}

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
    private GameObject pausePanel, gameOverPanel;

    private float seconds, minutes;

    private int totalScore;
    
    static public float totalTimeScore;

    void Awake()
    {
        MakeInstance();
    
       
    }

    // Update is called once per frame
    void Update()
    {
     
        SetTime();
        PauseGameByEsc();


    }

    void MakeInstance()
    {
        if(instance == null)
        {
            instance = this;
        }
    }



    //GAME PAUSE
    public void PauseTheGame()
    {
        Time.timeScale = 0f;
        pausePanel.SetActive(true);
    }

    public void PauseGameByEsc()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (pausePanel.activeSelf == false)
            {
                Time.timeScale = 0f;
                pausePanel.SetActive(true);
            }
            else
            {
                Time.timeScale = 1f;
                pausePanel.SetActive(false);
            }
        }
        
    }

    //GAME RESUME
    public void ResumeGame()
    {
        Time.timeScale = 1f;
        pausePanel.SetActive(false);
        SpawnSecurity.timeElapsed = 0f;
    }

    //QUIT GAME
    public void QuitGame(string sceneName)
    {
        Time.timeScale = 1f;
        Lose.gameOver = false;
        SceneManager.LoadScene(TagManager.MAIN_MENU_SCENE);
    }


    
    //RESTART GAME
    public void RestartGame (string sceneName)
    {
        Time.timeScale = 1f;
        Lose.gameOver = false;
        GameManager.instance.gameRestarted = true;

        gameOverPanel.SetActive(false);
        
        SceneManager.LoadScene(TagManager.LEVEL1_SCENE);
      
    }

    public void SetScore(int score)
    {
        
            scoreText.text = "" + score;
     
    }

    public void SetTime()
    {
        minutes = (int)(Time.time / 60f);
        seconds = (int)(Time.time % 60f);

        timeText.text = minutes.ToString("00") + ":" + seconds.ToString("00");
    }


    public void GameOver(int score)
    {
        if (Lose.gameOver == true)
        {
            print("print you lose");
            gameOverPanel.SetActive(true);
            gameOverScoreText.text = score.ToString();
            gameOverTimeText.text = minutes.ToString("00") + ":" + seconds.ToString("00");
            


            Time.timeScale = 0f;
        }
    }

}

using System.Collections;
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
    private GameObject pausePanel, musicButtonOn, gameOverPanel, musicButtonOff, deactivateScoreObject;

    [SerializeField]
    private Animator gameOverAnim, pauseAnim, greatAnim, fiveScoreAnim;
    private bool pauseAnimBoool;

    private float seconds, minutes;

    static public bool panelOnCantMove;
    static public int levelMode;

    private int totalScore;
   // private int totalDeactivate;
   // private bool greatBoolParam;
    private int comboScoreDisplay;


   // static public float comboTime;


  //  private float addTotime = 1f;

    //static public float totalTimeScore;

    void Awake()
    {
        MakeInstance();


    }

    private void Start()
    {

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
        pauseAnimBoool = true;
        pauseAnim.SetBool(TagManager.PAUSE_PARAMETER, pauseAnimBoool);
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
                pauseAnimBoool = true;
                pauseAnim.SetBool(TagManager.PAUSE_PARAMETER, pauseAnimBoool);

            }
            else
            {
               
                Time.timeScale = 1f;
                panelOnCantMove = false;
                pauseAnimBoool = false;
                pauseAnim.SetBool(TagManager.PAUSE_PARAMETER, pauseAnimBoool);
                pausePanel.SetActive(false);
            }

        }
      
    }


    void PausePanelTouchControl()
    {
        if (pausePanel.activeSelf == true)
        {

            

            if (Input.GetKeyDown(KeyCode.Return))
            {
                ResumeGame();
            }


            if (Input.GetKeyDown(KeyCode.R))
            {
                if(LevelController.frogLevel == true)
                {
                    RestartGame(TagManager.FROG_SCENE);
                }
               
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
        pauseAnim.SetBool(TagManager.PAUSE_PARAMETER, false);
        SpawnSecurity.timeElapsed = 0f;
        pausePanel.SetActive(false);
        AchievementManager.Instance.achievementMenu.SetActive(false);
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

        if (LevelController.frogLevel == true)
        {
        SceneManager.LoadScene(TagManager.FROG_SCENE);
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
            panelOnCantMove = true;
            gameOverPanel.SetActive(true);
            gameOverAnim.SetBool(TagManager.GAMEOVER_PARAMETER, true);

            gameOverScoreText.text = score.ToString();

            minutes = (int)(time / 60f);
            seconds = (int)(time % 60f);
            gameOverTimeText.text = minutes.ToString("00") + ":" + seconds.ToString("00");

           

            Time.timeScale = 0f;
            SpawnFood.scoreBySpawn = 0;

            if (Input.GetKeyDown(KeyCode.Return))
            {
               if (LevelController.frogLevel == true)
               {
                 RestartGame(TagManager.FROG_SCENE);
               }
            }

            if (Input.GetKeyDown(KeyCode.Escape))
            {
                QuitGame(TagManager.MAIN_MENU_SCENE );
            }


            if (Input.GetKeyDown(KeyCode.Q))
            {
                QuitGame(TagManager.MAIN_MENU_SCENE);
            }

        }
    }

    //MUSIC
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
            MusicController.instance.PlayMusic(true);
            musicButtonOn.SetActive(true);
            musicButtonOff.SetActive(false);
        }
    }

   




    //ITEM DEACTIVATE
    public void ItemDeactivateCount()
    {

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
                deactivateScoreAnim.text = comboScoreDisplay.ToString() + " x 5";
            }
            else
            {
                fiveScoreAnim.SetBool(TagManager.DISPLAY_5_PARAMETER, false);
            }


            if (comboScoreDisplay >= 4 && comboScoreDisplay < 8 &&  greatText.text == "")
            {
               greatText.text = "GREAT";
                StartCoroutine(DisplayText());
            }
            else if (comboScoreDisplay >= 8 && comboScoreDisplay < 12 && greatText.text == "")
            {
                greatText.text = "AWESOME";
                StartCoroutine(DisplayText());
            }
            else if (comboScoreDisplay >= 12 && greatText.text == "")
            {
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
            }

            IEnumerator DisplayText()
            {
                yield return new WaitForSeconds(1f);
                greatAnim.SetBool(TagManager.DISPLAY_GREAT_PARAMETER, true);
            }

        }

    }


}

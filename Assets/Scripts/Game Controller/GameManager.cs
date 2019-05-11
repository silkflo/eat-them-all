using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    [HideInInspector]
    public bool gameRestarted;

    [HideInInspector]
    public int score;
    [HideInInspector]
    public float timeScore;

    void Awake()
    {
        MakeSingleton();
    }

    void Start()
    {
        InitializeVariables();
    }

    void Update()
    {

        // print("gameStartedFromMainMenu : " + gameRestarted);
    }


    void MakeSingleton()
    {
        if (instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }



    void InitializeVariables()
    {
        if(!PlayerPrefs.HasKey("Game Initialized"))
        {
            GamePreferences.SetEasyDifficulty(1);
            GamePreferences.SetEasyDifficultyHighScore(0);

            GamePreferences.SetMediumDifficulty(0);
            GamePreferences.SetMediumDifficultyHighScore(0);

            GamePreferences.SetHardDifficulty(0);
            GamePreferences.SetHardDifficultyHighScore(0);

            GamePreferences.SetIsMusicOn(0);

            PlayerPrefs.SetInt("Game Initialized", 123);  //giving a key to just use that condition a the first start of the game
        }
    }

    public void CheckGameStatus(int score, float time)
    {
        if (Lose.gameOver == true)
        {

            if (GamePreferences.GetEasyDifficulty() == 1)
            {
                int highScore = GamePreferences.GetEasyDifficultyHighScore();

                if (highScore < score)
                {
                    GamePreferences.SetEasyDifficultyHighScore(score);
                }

            }

            if (GamePreferences.GetMediumDifficulty() == 1)
            {
                int highScore = GamePreferences.GetMediumDifficultyHighScore();

                if (highScore < score)
                {
                    GamePreferences.SetMediumDifficultyHighScore(score);
                }

            }

            if (GamePreferences.GetHardDifficulty() == 1)
            {
                int highScore = GamePreferences.GetHardDifficultyHighScore();

                if (highScore < score)
                {
                    GamePreferences.SetHardDifficultyHighScore(score);
                }

            }

            gameRestarted = false;
            GamePlayController.instance.GameOver(score, time);

            // GamePlayController.instance.GameOver(score);    
        }


    }







    /*
           void OnEnable()
       {
           SceneManager.sceneLoaded += GameLoading;
       }

       void OnDisable()
       {
           SceneManager.sceneLoaded -= GameLoading;
       }


       void GameLoading(Scene scene, LoadSceneMode mode)
        {
          if( scene.name == TagManager.LEVEL1_SCENE)
           {
                if (gameRestarted == true)
                  {

                    Score.totalScore = 0;

                    print("new game score : " + Score.totalScore);

                    GamePlayController.instance.SetScore(0);



                   //gameStartedFromMainMenu = false;

                }
           }
        }

      */







}

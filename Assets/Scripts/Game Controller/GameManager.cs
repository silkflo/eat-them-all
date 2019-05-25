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

    public GameObject visualAchievement;
   

    void Awake()
    {
        MakeSingleton();
    }

    void Start()
    {
        InitializeVariables();
        CheckToPlayTheMusic();


  


    }

    void Update()
    {
        


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
                    print("You beat your easy high Score");
                    GamePreferences.SetEasyDifficultyHighScore(score);
                }

            }

            if (GamePreferences.GetMediumDifficulty() == 1)
            {
                int highScore = GamePreferences.GetMediumDifficultyHighScore();

                if (highScore < score)
                {
                    print("You beat your medium high Score");
                    GamePreferences.SetMediumDifficultyHighScore(score);
                }

            }

            if (GamePreferences.GetHardDifficulty() == 1)
            {
                int highScore = GamePreferences.GetHardDifficultyHighScore();

                if (highScore < score)
                {
                    print("You beat your hard high Score");
                    GamePreferences.SetHardDifficultyHighScore(score);
                }

            }

            gameRestarted = false;
            GamePlayController.instance.GameOver(score, time);

           
        }


    }

    void CheckToPlayTheMusic()
    {
        if (GamePreferences.GetIsMusicOn() == 1)
        {
            MusicController.instance.PlayMusic(true);
            

        }
        else
        {
            MusicController.instance.PlayMusic(false);
           
        }
    }











  

}

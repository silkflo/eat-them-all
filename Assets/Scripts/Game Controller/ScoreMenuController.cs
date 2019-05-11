using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class ScoreMenuController : MonoBehaviour
{
    [SerializeField]
    private GameObject backButton;


    [SerializeField]
    private Text scoreText;


    void Start()
    {
        
    }

    
    void Update()
    {
        
    }


    void SetScore (int score)
    {
        scoreText.text = score.ToString();
    }


    void SetScoreBasedOnDifficulty()
    {
        if(GamePreferences.GetEasyDifficulty() == 1)
        {
            SetScore(GamePreferences.GetEasyDifficultyHighScore());
        }
        if (GamePreferences.GetMediumDifficulty() == 1)
        {
            SetScore(GamePreferences.GetMediumDifficultyHighScore());
        }
        if (GamePreferences.GetHardDifficulty() == 1)
        {
            SetScore(GamePreferences.GetHardDifficultyHighScore());
        }
    }




    public void MainMenu()
    {
        SceneManager.LoadScene(TagManager.MAIN_MENU_SCENE);
    }


  


}

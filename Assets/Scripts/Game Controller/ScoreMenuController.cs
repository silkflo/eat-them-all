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
    private Text easyScoreText, mediumScoreText, hardScoreText;


    void Start()
    {
        SetScoreBasedOnDifficulty();
    }

    
    void Update()
    {
        
    }


    void SetEasyScore (int score)
    {
        easyScoreText.text = score.ToString();
    }

    void SetMediumScore (int score)
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




    public void MainMenu()
    {
        AudioManager.instance.ButtonPressedSound();
       
        SceneManager.LoadScene(TagManager.SUCCESS_SCENE);
    }


  


}

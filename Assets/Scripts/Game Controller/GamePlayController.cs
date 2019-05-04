using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GamePlayController : MonoBehaviour
{
    public static GamePlayController instance;

    [SerializeField] 
    private Text timeText, scoreText;

    [SerializeField]
    private GameObject pausePanel;


    private int score;

    void Awake()
    {
        MakeInstance();
        score = 0;
    }

    // Update is called once per frame
    void Update()
    {
        SetScore();
    }

    void MakeInstance()
    {
        if(instance == null)
        {
            instance = this;
        }
    }


    public void PauseTheGame()
    {
        Time.timeScale = 0f;
        pausePanel.SetActive(true);
    }

    public void ResumeGame()
    {
        Time.timeScale = 1f;
        pausePanel.SetActive(false);
    }


    public void QuitGame(string sceneName)
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(TagManager.MAIN_MENU_NAME);
    }


    public void SetScore()
    {
       
        score = SpawnSecurity.scoreBySpawn + BombScript.scoreByBomb + DeactivateScript.itemDeactivateScore;
        scoreText.text = "" + score;
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class DifficultyController : MonoBehaviour
{
    //static public int levelMode;


    [SerializeField]
    private GameObject  easyButton,easyButtonActivated,
                        mediumButton, mediumButtonActivated,
                        hardButton, hardButtonActivated,
                        backButton;

    void Start()
    {
        SetTheDifficulty();
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    void SetInitialDifficulty(string difficulty)
    {
        switch (difficulty)
        {
            case "easy":
                easyButtonActivated.SetActive(true);
                mediumButton.SetActive(true);
                hardButton.SetActive(true);
                mediumButtonActivated.SetActive(false);
                hardButtonActivated.SetActive(false);
                easyButton.SetActive(false);

             //   levelMode = 1;
                break;
            case "medium":
                easyButton.SetActive(true);
                mediumButtonActivated.SetActive(true);
                hardButton.SetActive(true);
                easyButtonActivated.SetActive(false);
                hardButtonActivated.SetActive(false);
                mediumButton.SetActive(false);

             //   levelMode = 2;
                break;
            case "hard":
                easyButton.SetActive(true);
                mediumButton.SetActive(true);
                hardButtonActivated.SetActive(true);
                easyButtonActivated.SetActive(false);
                mediumButtonActivated.SetActive(false);
                hardButton.SetActive(false);

              //  levelMode = 3;
                break;
        }
       



    }



    void SetTheDifficulty()
    {
        if(GamePreferences.GetEasyDifficulty() == 1)
        {
            SetInitialDifficulty("easy");
        }
        if (GamePreferences.GetMediumDifficulty() == 1)
        {
            SetInitialDifficulty("medium");
        }
        if (GamePreferences.GetHardDifficulty() == 1)
        {
            SetInitialDifficulty("hard");
        }
    }


    public void EasyMode()
    {

        GamePreferences.SetEasyDifficulty(1);
        GamePreferences.SetMediumDifficulty(0);
        GamePreferences.SetHardDifficulty(0);

        easyButtonActivated.SetActive(true);
        mediumButton.SetActive(true);
        hardButton.SetActive(true);
        mediumButtonActivated.SetActive(false);
        hardButtonActivated.SetActive(false);
        easyButton.SetActive(false);

        // levelMode = 1;
        print("Easy :" + GamePreferences.GetEasyDifficulty());
        print("Medium :" + GamePreferences.GetMediumDifficulty());
        print("Hard : " + GamePreferences.GetHardDifficulty());

    }


    public void MediumMode()
    {
        GamePreferences.SetEasyDifficulty(0);
        GamePreferences.SetMediumDifficulty(1);
        GamePreferences.SetHardDifficulty(0);

        easyButton.SetActive(true);
        mediumButtonActivated.SetActive(true);
        hardButton.SetActive(true);
        easyButtonActivated.SetActive(false);
        hardButtonActivated.SetActive(false);
        mediumButton.SetActive(false);

        print("Easy :" + GamePreferences.GetEasyDifficulty());
        print("Medium :" + GamePreferences.GetMediumDifficulty());
        print("Hard : " + GamePreferences.GetHardDifficulty());

        //  levelMode = 2;
    }

    public void HardMode()
    {
        GamePreferences.SetEasyDifficulty(0);
        GamePreferences.SetMediumDifficulty(0);
        GamePreferences.SetHardDifficulty(1);

        easyButton.SetActive(true);
        mediumButton.SetActive(true);
        hardButtonActivated.SetActive(true);
        easyButtonActivated.SetActive(false);
        mediumButtonActivated.SetActive(false);
        hardButton.SetActive(false);


        print("Easy :" + GamePreferences.GetEasyDifficulty());
        print("Medium :" + GamePreferences.GetMediumDifficulty());
        print("Hard : " + GamePreferences.GetHardDifficulty());
        // levelMode = 3;
    }


    public void MainMenu()
    {
        SceneManager.LoadScene(TagManager.MAIN_MENU_SCENE);
    }



}

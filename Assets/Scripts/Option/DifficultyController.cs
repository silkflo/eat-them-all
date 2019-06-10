using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class DifficultyController : MonoBehaviour
{/*
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
            break;

            case "medium":
                easyButton.SetActive(true);
                mediumButtonActivated.SetActive(true);
                hardButton.SetActive(true);
                easyButtonActivated.SetActive(false);
                hardButtonActivated.SetActive(false);
                mediumButton.SetActive(false);
            break;

            case "hard":
                easyButton.SetActive(true);
                mediumButton.SetActive(true);
                hardButtonActivated.SetActive(true);
                easyButtonActivated.SetActive(false);
                mediumButtonActivated.SetActive(false);
                hardButton.SetActive(false);
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
        AudioManager.instance.ButtonPressedSound();

        GamePreferences.SetEasyDifficulty(1);
        GamePreferences.SetMediumDifficulty(0);
        GamePreferences.SetHardDifficulty(0);

        easyButtonActivated.SetActive(true);
        mediumButton.SetActive(true);
        hardButton.SetActive(true);
        mediumButtonActivated.SetActive(false);
        hardButtonActivated.SetActive(false);
        easyButton.SetActive(false);
    }


    public void MediumMode()
    {
        AudioManager.instance.ButtonPressedSound();
     
        GamePreferences.SetEasyDifficulty(0);
        GamePreferences.SetMediumDifficulty(1);
        GamePreferences.SetHardDifficulty(0);

        easyButton.SetActive(true);
        mediumButtonActivated.SetActive(true);
        hardButton.SetActive(true);
        easyButtonActivated.SetActive(false);
        hardButtonActivated.SetActive(false);
        mediumButton.SetActive(false);
    }

    public void HardMode()
    {
        AudioManager.instance.ButtonPressedSound();
   
        GamePreferences.SetEasyDifficulty(0);
        GamePreferences.SetMediumDifficulty(0);
        GamePreferences.SetHardDifficulty(1);

        easyButton.SetActive(true);
        mediumButton.SetActive(true);
        hardButtonActivated.SetActive(true);
        easyButtonActivated.SetActive(false);
        mediumButtonActivated.SetActive(false);
        hardButton.SetActive(false);
    }


    public void OptionMenu()
    {
        AudioManager.instance.ButtonPressedSound();

        SceneManager.LoadScene(TagManager.OPTION_SCENE);
    }

    */

}

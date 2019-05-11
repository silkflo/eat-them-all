using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class DifficultyController : MonoBehaviour
{
    static public int levelMode;


    [SerializeField]
    private GameObject  easyButton,easyButtonActivated,
                        mediumButton, mediumButtonActivated,
                        hardButton, hardButtonActivated,
                        backButton;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }



    public void MainMenu()
    {
        SceneManager.LoadScene(TagManager.MAIN_MENU_SCENE);
    }


    public void EasyMode()
    {
        
        easyButtonActivated.SetActive(true);
        mediumButton.SetActive(true);
        hardButton.SetActive(true);
        mediumButtonActivated.SetActive(false);
        hardButtonActivated.SetActive(false);
        easyButton.SetActive(false);

        levelMode = 1;
        

   }





    public void MediumMode()
    {
        
        easyButton.SetActive(true);
        mediumButtonActivated.SetActive(true);
        hardButton.SetActive(true);
        easyButtonActivated.SetActive(false);
        hardButtonActivated.SetActive(false);
        mediumButton.SetActive(false);

        levelMode = 2;
    }

    public void HardMode()
    {
        easyButton.SetActive(true);
        mediumButton.SetActive(true);
        hardButtonActivated.SetActive(true);
        easyButtonActivated.SetActive(false);
        mediumButtonActivated.SetActive(false);
        hardButton.SetActive(false);


        levelMode = 3;
    }

}

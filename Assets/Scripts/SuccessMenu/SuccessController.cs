using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SuccessController : MonoBehaviour
{


    [SerializeField]
    private GameObject scoreButton, tropheeButton, backButton;


    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void ScoreMenu()
    {
        AudioManager.instance.ButtonPressedSound();

        SceneManager.LoadScene(TagManager.SCORE_SCENE);
    }

    public void TropheeMenu()
    {
        AudioManager.instance.ButtonPressedSound();
       
        SceneManager.LoadScene(TagManager.ACHIEVEMENT_SCENE);
    }


    public void MainMenu()
    {
        AudioManager.instance.ButtonPressedSound();

        SceneManager.LoadScene(TagManager.MAIN_MENU_SCENE);
    }

}

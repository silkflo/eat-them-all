using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class HelpController : MonoBehaviour
{
    [SerializeField]
    private GameObject moveGuidePanel, bombGuidePanel, exploseGuidePanel, loseGuidePanel, shortcutGuidePanel;

    [SerializeField]
    private Text buttonText;



    void Start()
    {
        if (GamePlayController.guideOnStart == false)
        {
            buttonText.text = "Back";
        }
        else if (GamePlayController.guideOnStart == true)
        {
            buttonText.text = "Start";
        }
    }


    void Update()
    {
        
    }




    public void NextMoveButton()
    {
        AudioManager.instance.ClickMenuSound();

        moveGuidePanel.SetActive(false);
        bombGuidePanel.SetActive(true);
    }

    public void PreviousBombButton()
    {
        AudioManager.instance.ClickMenuSound();
        
        moveGuidePanel.SetActive(true);
        bombGuidePanel.SetActive(false);
    }

    public void NextBombButton()
    {
        AudioManager.instance.ClickMenuSound();
   
        bombGuidePanel.SetActive(false);
        exploseGuidePanel.SetActive(true);
    }

    public void PreviousExploseButton()
    {
        AudioManager.instance.ClickMenuSound();
   
        bombGuidePanel.SetActive(true);
        exploseGuidePanel.SetActive(false);
    }

    public void NextExplodeButton()
    {
        AudioManager.instance.ClickMenuSound();
      
        exploseGuidePanel.SetActive(false);
        loseGuidePanel.SetActive(true);
    }

    public void PreviousLoseButton()
    {
        AudioManager.instance.ClickMenuSound();
       
        loseGuidePanel.SetActive(false);
        exploseGuidePanel.SetActive(true);
    }

    public void NextLoseButton()
    {
        AudioManager.instance.ClickMenuSound();
    
        shortcutGuidePanel.SetActive(true);
        loseGuidePanel.SetActive(false);
    }

    public void PreviousShortcutButton()
    {
        AudioManager.instance.ClickMenuSound();

        shortcutGuidePanel.SetActive(false);
        loseGuidePanel.SetActive(true);
    }



    public void ReturnMainMenuORPlay()
    {
      

        if (GamePlayController.guideOnStart == false)
        {
            AudioManager.instance.ClickBackSound();
            SceneManager.LoadScene(TagManager.MAIN_MENU_SCENE);
        }
        else if (GamePlayController.guideOnStart == true)
        {
            GamePlayController.guideOnStart = false;
            AudioManager.instance.ClickStartSound();
            SpawnFood.scoreBySpawn = 0;
        
            SceneManager.LoadScene(TagManager.FROG_SCENE);
        }
    }




}

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
            buttonText.text = "MENU";
        }
        else if (GamePlayController.guideOnStart == true)
        {
            buttonText.text = "PLAY";
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
        AudioManager.instance.ClickBackSound();
        
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
        AudioManager.instance.ClickBackSound();
   
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
        AudioManager.instance.ClickBackSound();
       
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
        AudioManager.instance.ClickBackSound();

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

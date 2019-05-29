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
    private Button  nextMoveButton,
                    previousBombButton, nextBombButton,
                    previousExploseButton, NextExploseButton,
                    previousLoseButton, nextLoseButton,
                    previousShortcutButton,
                    optionButton;


    void Start()
    {
        
    }

   
    void Update()
    {
        
    }




    public void NextMoveButton()
    {
        AudioManager.instance.ButtonPressedSound();

        moveGuidePanel.SetActive(false);
        bombGuidePanel.SetActive(true);
    }

    public void PreviousBombButton()
    {
        AudioManager.instance.ButtonPressedSound();
        
        moveGuidePanel.SetActive(true);
        bombGuidePanel.SetActive(false);
    }

    public void NextBombButton()
    {
        AudioManager.instance.ButtonPressedSound();
   
        bombGuidePanel.SetActive(false);
        exploseGuidePanel.SetActive(true);
    }

    public void PreviousExploseButton()
    {
        AudioManager.instance.ButtonPressedSound();
   
        bombGuidePanel.SetActive(true);
        exploseGuidePanel.SetActive(false);
    }

    public void NextExplodeButton()
    {
        AudioManager.instance.ButtonPressedSound();
      
        exploseGuidePanel.SetActive(false);
        loseGuidePanel.SetActive(true);
    }

    public void PreviousLoseButton()
    {
        AudioManager.instance.ButtonPressedSound();
       
        loseGuidePanel.SetActive(false);
        exploseGuidePanel.SetActive(true);
    }

    public void NextLoseButton()
    {
        AudioManager.instance.ButtonPressedSound();
    
        shortcutGuidePanel.SetActive(true);
        loseGuidePanel.SetActive(false);
    }

    public void PreviousShortcutButton()
    {
        AudioManager.instance.ButtonPressedSound();

        shortcutGuidePanel.SetActive(false);
        loseGuidePanel.SetActive(true);
    }



    public void ReturnOption()
    {
        AudioManager.instance.ButtonPressedSound();
       
        SceneManager.LoadScene(TagManager.OPTION_SCENE);
    }




}

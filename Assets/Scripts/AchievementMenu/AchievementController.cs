using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AchievementController : MonoBehaviour
{

    [SerializeField]
    private GameObject  backButton;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void SuccessMenu()
    {
        AudioManager.instance.ButtonPressedSound();

        SceneManager.LoadScene(TagManager.MAIN_MENU_SCENE);
    }


}

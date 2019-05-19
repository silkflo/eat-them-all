using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelController : MonoBehaviour
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


    public void MainMenu()
    {
        SceneManager.LoadScene(TagManager.MAIN_MENU_SCENE);
    }


}

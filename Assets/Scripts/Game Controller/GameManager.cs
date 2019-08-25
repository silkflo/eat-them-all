using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    [HideInInspector]
    public bool gameRestarted;

    [HideInInspector]
    public int score;
    [HideInInspector]
    public float timeScore;

   

    public bool greatBoolAnim, awesomeBoolAnim, amazingBoolAnim;
  

   

    void Awake()
    {
        MakeSingleton();
        //Delete all save data in game
        // PlayerPrefs.DeleteAll();
     //   MainMenuController.instance.sound = true;
       // MainMenuController.instance.music = true;
      
    }

    void Start()
    {
      

      
        MusicController.instance.PlayMusic(true);

       // MainMenuController.instance.InitializeMusicButtonOnStart(true);
       // MainMenuController.instance.InitializeSoundButtonOnStart(true);
      //  MainMenuController.instance.PlayMusic();
    }

    void Update()
    {

        print("sound : " + MainMenuController.sound + " Music : " + MainMenuController.music);

    }


    void MakeSingleton()
    {
        if (instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }










}






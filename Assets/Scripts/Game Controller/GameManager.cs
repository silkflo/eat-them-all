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

    void Awake()
    {
        MakeSingleton();
    }

 

    void Update()
    {
     
       // print("gameStartedFromMainMenu : " + gameRestarted);
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

    /*
           void OnEnable()
       {
           SceneManager.sceneLoaded += GameLoading;
       }

       void OnDisable()
       {
           SceneManager.sceneLoaded -= GameLoading;
       }


       void GameLoading(Scene scene, LoadSceneMode mode)
        {
          if( scene.name == TagManager.LEVEL1_SCENE)
           {
                if (gameRestarted == true)
                  {

                    Score.totalScore = 0;

                    print("new game score : " + Score.totalScore);

                    GamePlayController.instance.SetScore(0);



                   //gameStartedFromMainMenu = false;

                }
           }
        }

      */

    public void CheckGameStatus(int score, float time)
    {
               if(Lose.gameOver == true)
               {
                 gameRestarted = false;

                GamePlayController.instance.GameOver(score, time);

                  // GamePlayController.instance.GameOver(score);    
               }

     
    }



     


}

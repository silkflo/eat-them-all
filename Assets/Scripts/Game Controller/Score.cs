using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Score : MonoBehaviour
{

    static public int totalScore;


    static public float currentTime;

    private float addTotime = 1f;

    void Awake()
    {
   
    }

    
    void Update()
    {

        currentTime += addTotime * Time.deltaTime;
        

        //print("current time : " + currentTime);
        CalculateTheScore();
        
    }

    void CalculateTheScore()
    {
       


            totalScore = SpawnSecurity.scoreBySpawn + BombScript.scoreByBomb + DeactivateScript.itemDeactivateScore;

            GamePlayController.instance.SetScore(totalScore);
            GamePlayController.instance.GameOver(totalScore,currentTime);
            GamePlayController.instance.SetTime(currentTime);

        
        if(Lose.gameOver == true)
        {
          //  GameManager.instance.CheckGameStatus(totalScore);
        }

        if(GameManager.instance.gameRestarted == true)
        {
            print("reset score");
            SpawnSecurity.scoreBySpawn = 0;
            BombScript.scoreByBomb = 0;
            DeactivateScript.itemDeactivateScore = 0;
            totalScore = SpawnSecurity.scoreBySpawn + BombScript.scoreByBomb + DeactivateScript.itemDeactivateScore;
            currentTime = 0f;
            GamePlayController.instance.SetScore(totalScore);
            GamePlayController.instance.SetTime(currentTime);

            GameManager.instance.gameRestarted = false;
        }

    }

  

}

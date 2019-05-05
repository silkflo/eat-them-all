using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Score : MonoBehaviour
{

    static public int totalScore;

    void Awake()
    {
   
    }

    
    void Update()
    {
       CalculateTheScore();
        
    }

    void CalculateTheScore()
    {
       


            totalScore = SpawnSecurity.scoreBySpawn + BombScript.scoreByBomb + DeactivateScript.itemDeactivateScore;

            GamePlayController.instance.SetScore(totalScore);
            GamePlayController.instance.GameOver(totalScore);

        
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

            GamePlayController.instance.SetScore(totalScore);

            GameManager.instance.gameRestarted = false;
        }

    }

  

}

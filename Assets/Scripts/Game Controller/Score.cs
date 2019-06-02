using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Score : MonoBehaviour
{

    static public int totalScore;


    static public float currentTime;
    static public int scoreByBombAdd10;

    private float addTotime = 1f;

    void Awake()
    {
        totalScore = 0;
    }


    void Update()
    {

        currentTime += addTotime * Time.deltaTime;


        //print("current time : " + currentTime);
        print("Total Score : "+ totalScore +" =  Score by Spawn : " + SpawnFood.scoreBySpawn + " score by bomb : " + BombScript.scoreByBomb + " score by eject : " + DeactivateFood.itemDeactivateScore);
        CalculateTheScore();

    }

    void CalculateTheScore()
    {

     


        totalScore = SpawnFood.scoreBySpawn + BombScript.scoreByBomb + DeactivateFood.itemDeactivateScore;

        GamePlayController.instance.SetScore(totalScore);
        GamePlayController.instance.GameOver(totalScore, currentTime);
        GamePlayController.instance.SetTime(currentTime);


        if (Lose.gameOver == true)
        {
             GameManager.instance.CheckGameStatus(totalScore, currentTime);
        }

        if (GameManager.instance != null)
        {
            if (GameManager.instance.gameRestarted == true)
            {
                print("reset score");
               
               
                BombScript.scoreByBomb = 0;
                DeactivateFood.countDeactivateobject = 0;
                DeactivateFood.itemDeactivateScore = 0;

                if (SpawnFood.scoreBySpawn == 1 && MainMenuController.fromMainMenu == true)
                {
                    SpawnFood.scoreBySpawn = 1;
                    MainMenuController.fromMainMenu = false;
                }
                else
                {
                    SpawnFood.scoreBySpawn = 0;
                }
                totalScore = SpawnFood.scoreBySpawn + BombScript.scoreByBomb + DeactivateFood.itemDeactivateScore;


                currentTime = 0f;
                GamePlayController.instance.SetScore(totalScore);
                GamePlayController.instance.SetTime(currentTime);

                GameManager.instance.gameRestarted = false;
            }
        }

    }



}

﻿using System.Collections;
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



        totalScore = SpawnFood.scoreBySpawn + BombScript.scoreByBomb + DeactivateScript.itemDeactivateScore;

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
                SpawnFood.scoreBySpawn = 0;
                BombScript.scoreByBomb = 0;
                DeactivateScript.itemDeactivateScore = 0;
                totalScore = SpawnFood.scoreBySpawn + BombScript.scoreByBomb + DeactivateScript.itemDeactivateScore;
                currentTime = 0f;
                GamePlayController.instance.SetScore(totalScore);
                GamePlayController.instance.SetTime(currentTime);

                GameManager.instance.gameRestarted = false;
            }
        }

    }



}

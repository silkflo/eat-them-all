﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lose : MonoBehaviour
{
    static public bool canLose = true;

    public float minY = -25f;
    public float maxY = 21f;

    static public bool gameOver = false;
    static public int endCountCombo;
    static public int comboScore;

   


    private void Awake()
    {
        gameOver = false;
    }


    private void Start()
    {
        
    }

    void Update()
    {

        SetCanLoseTrue();

        //  print("Can Lose : "+ canLose);
    }


    private void OnTriggerEnter2D(Collider2D target)
    {
        if ((target.tag == TagManager.FOOD_TAG || target.tag == TagManager.BOMB_TAG) 
            && canLose == true && target.tag != "BombLoseLine")
        {
            print("GAME OVER by food!!!");
            gameOver = true;
            AudioManager.instance.GameOverSound();
            GameManager.instance.CheckGameStatus(Score.totalScore, Score.currentTime);


        }
    }



    void SetCanLoseTrue()
    {

        if (BombRadius.hasExploded == true)
        {
            StopCoroutine("CanLoseTiming");
         //   BombRadius.hasExploded = false;
        }
        else if (canLose == false)
        {
            StartCoroutine("CanLoseTiming");
        }
    }

    IEnumerator CanLoseTiming()
    {
        yield return new WaitForSeconds(5f);

        if(canLose == true)
        {
            endCountCombo = DeactivateFood.countDeactivateobject;
        }
   
        comboScore = endCountCombo - BombScript.startCountCombo;
     //   print("combo score : " + comboScore + " - EndCombo : " + endCountCombo + " - StartCombo : " + BombScript.startCountCombo);

        canLose = true;
       // BombRadius.hasExploded = false;
    }

    //Lose by bomb Cf BombScript
   
}

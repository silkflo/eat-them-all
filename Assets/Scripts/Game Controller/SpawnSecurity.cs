﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnSecurity : MonoBehaviour
{
    static public float timeElapsed;
    static public int scoreBySpawn;
    static public int spawnSecurityTime = 250; //250

    private bool newObject;
   

   

     void Update()
     {
        
        if (newObject == true || Time.deltaTime == 0)
        {
            timeElapsed = 0f;
        }
        else
        {
            timeElapsed++;
        }
        
         newObject = false;
       // print(timeElapsed);
        
        SpawnMissingObject();
     }


    private void OnTriggerEnter2D(Collider2D target)
    {

        if(target.tag == TagManager.FOOD_TAG ||
          target.tag == TagManager.BOMB_TAG)
        {
            newObject = true;

            scoreBySpawn = scoreBySpawn + 1;

            
        }
    }


    void SpawnMissingObject()
    {
        
        if(timeElapsed == spawnSecurityTime)
        {
            print("SPAWN SECURITY");
                      
            StartCoroutine(SpawnNewFood());
        
        }

        IEnumerator SpawnNewFood()
        {
            yield return new WaitForSeconds(1f);
            print("Spawning!!");
                      
            SpawnFood.instance.StartSpawningFood();
         
        }

    }

}

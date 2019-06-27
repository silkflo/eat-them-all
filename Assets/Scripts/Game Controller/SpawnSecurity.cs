using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnSecurity : MonoBehaviour
{
    static public float timeElapsed;
    
    static public int spawnSecurityTime ; //250

    private bool newObject;
   

   

     void Update()
     {
        
/*
        if(BombRadius.hasExploded == true && Lose.canLose == false )
        {
           spawnSecurityTime = 150; //250
            

        }
        else
        {
            spawnSecurityTime = 500;
        }
*/
        print("SpawnTime = " + spawnSecurityTime);

        if (newObject == true || Time.deltaTime == 0 || timeElapsed>500)
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

        if(target.tag == TagManager.FOOD_TAG||
          target.tag == TagManager.BOMB_TAG)
        {
            newObject = true;
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

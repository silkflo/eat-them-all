using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnSecurity : MonoBehaviour
{
    static public float timeElapsed;
    static public int scoreBySpawn;

    private bool newObject;
    private int spawnSecurityTime = 250;

   

     void Update()
     {
        
        if (newObject == true)
        {
            timeElapsed = 0f;
        }
        else
        {
            timeElapsed++;
        }
        
         newObject = false;
        //print(timeElapsed);
        
        SpawnMissingObject();
     }


    private void OnTriggerEnter2D(Collider2D target)
    {

        if(target.tag == TagManager.FOOD_TAG ||
          target.tag == TagManager.BOMB_TAG)
        {
            newObject = true;
            
            scoreBySpawn =  scoreBySpawn + 1;
            
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
            yield return new WaitForSeconds(2f);
            print("Spawning!!");
                      
            SpawnFood.instance.StartSpawningFood();
         
        }

    }

}

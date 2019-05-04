using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lose : MonoBehaviour
{
    static public bool canLose = true;

    public float minY = -25f;
    public float maxY = 21f;


    
    void Update()
    {
        
        SetCanLoseTrue();

      //  print("Can Lose : "+ canLose);
    }


    private void OnTriggerEnter2D(Collider2D target)
    {
        if (target.tag == TagManager.FOOD_TAG && canLose == true)
        {
            print("GAME OVER by food!!!");
            SpawnFood.canScore = false;
            Time.timeScale = 0f;
        }
    }

 
    
    void SetCanLoseTrue()
    {
        
        if ( BombRadius.hasExploded == true)
        {
            StopCoroutine("CanLoseTiming");
            BombRadius.hasExploded = false;
        }
        else if (canLose == false)
        {
            StartCoroutine("CanLoseTiming");
        }
    }

    IEnumerator CanLoseTiming()
    {
        yield return new WaitForSeconds(5f);

        canLose = true;
        BombRadius.hasExploded = false;


    }

    //Lose by bomb Cf BombScript

}

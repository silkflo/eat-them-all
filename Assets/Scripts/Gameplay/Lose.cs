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

        print("Can Lose? "+ canLose);
    }


    private void OnTriggerEnter2D(Collider2D target)
    {
        if (target.tag == TagManager.FOOD_TAG && canLose == true)
        {
            print("GAME OVER by food!!!");
            Time.timeScale = 0f;
        }
    }

 

    void SetCanLoseTrue()
    {
        if (canLose == false)
        {
            
            StartCoroutine(CanLoseTiming());
        }
        else if (canLose == true)
        {
            
            StopCoroutine(CanLoseTiming());
        }

        IEnumerator CanLoseTiming()
        {
            yield return new WaitForSeconds(10f);
            
            canLose = true;


        }
    }

    //Lose by bomb Cf BombScript

 }

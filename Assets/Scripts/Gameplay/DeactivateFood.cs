using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeactivateFood : MonoBehaviour
{

    static public int countDeactivateobject = 0;
    static public int itemDeactivateScore = 0;

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }




    private void OnTriggerEnter2D(Collider2D target)
    {
       

        if ((target.tag == TagManager.FOOD_TAG || target.tag == TagManager.BOMB_TAG) && Lose.canLose == false)
        {

           
                countDeactivateobject++;



                print("food deactivated = " + countDeactivateobject + " NAME : " + target.gameObject.name + " TAG : " + target.gameObject.tag);


                itemDeactivateScore = itemDeactivateScore + 5;
              
                target.gameObject.SetActive(false);

        }


    }


}



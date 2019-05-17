using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeactivateScript : MonoBehaviour
{
    static public int itemDeactivateScore = 0;

    static public bool scoreAnim = true;

    static public int countDeactivateobject = 0;

    private void Awake()
    {
        
    }


    private void Update()
    {
     
    }

    private void OnTriggerEnter2D(Collider2D target)
    {
        bool triggerOnce = true;

        if (target.tag == TagManager.DEACTIVATE_LINE_TAG && Lose.canLose == false)
        {

            if(triggerOnce == true)
            {
                countDeactivateobject++;
                print("food deactivated = " + countDeactivateobject);


                itemDeactivateScore = itemDeactivateScore + 5;

                gameObject.SetActive(false);
                triggerOnce = false;
            }
            
          
        }

    }

 

}//class

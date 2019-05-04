using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeactivateScript : MonoBehaviour
{

    static public int itemDeactivateScore = 0;

    private void OnTriggerEnter2D(Collider2D target)
    {
        if (target.tag == TagManager.DEACTIVATE_LINE_TAG && Lose.canLose == false)
        {
            // print("food deactivated??");

            itemDeactivateScore = itemDeactivateScore + 5;
            gameObject.SetActive(false);
        }
    }

 









































}//class

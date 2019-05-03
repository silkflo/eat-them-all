using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeactivateScript : MonoBehaviour
{

    private void OnTriggerEnter2D(Collider2D target)
    {
        if (target.tag == TagManager.DEACTIVATE_LINE_TAG && Lose.canLose == false)
        {
           // print("food deactivated??");
            gameObject.SetActive(false);
        }
    }

 









































}//class

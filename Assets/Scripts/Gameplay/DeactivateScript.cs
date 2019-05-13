using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeactivateScript : MonoBehaviour
{
    
    public Animator deactivateScoreAnim;

    static public int itemDeactivateScore = 0;

    static public bool scoreAnim = true;

    static public int countDeactivateobject = 0;

    private void Awake()
    {
        deactivateScoreAnim = GameObject.FindGameObjectWithTag("ScoreDeactivate").GetComponent<Animator>();
    }


    private void Update()
    {
       // print(scoreAnim);
    }

    private void OnTriggerEnter2D(Collider2D target)
    {
        if (target.tag == TagManager.DEACTIVATE_LINE_TAG && Lose.canLose == false)
        {
            scoreAnim = true;
            countDeactivateobject++;
            //print("food deactivated = " + countDeactivateobject);
          

            itemDeactivateScore = itemDeactivateScore + 5;
           
            gameObject.SetActive(false);

            if(gameObject.activeSelf == false)
            {
                scoreAnim = false;
            }
        }
        
    }

 

}//class

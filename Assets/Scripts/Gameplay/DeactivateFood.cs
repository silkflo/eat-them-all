using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeactivateFood : MonoBehaviour
{

    static public int countDeactivateobject = 0;
    static public int itemDeactivateScore = 0;
    static public  int countStartCombo;
    static public int countendcombo;
    public bool startCombo;
    public int comboLevel;


  
    void Update()
    {
        if(countStartCombo == 4)
        {
           
            comboLevel = 1;
        }
        else if( countStartCombo  == 8)
        {
            comboLevel = 2;
        }
        else if(countStartCombo == 12)
        {
            comboLevel = 3;
        }


        print("combo count" + countStartCombo);
    }




    private void OnTriggerEnter2D(Collider2D target)
    {
       



        if ((target.tag == TagManager.FOOD_TAG || target.tag == TagManager.BOMB_TAG ) && Lose.canLose == false)
        {

            StopCoroutine("ComboTime");
            countDeactivateobject++;
                startCombo = true;
            Lose.canLose = false;
            countStartCombo++;

            print("canLose : " + Lose.canLose);
                print("food deactivated = " + countDeactivateobject + " NAME : " + target.gameObject.name + " TAG : " + target.gameObject.tag);


                itemDeactivateScore = itemDeactivateScore + 5;

           target.gameObject.SetActive(false);

            StartCoroutine("ComboTime");

        }
       
        
    }
    
        IEnumerator ComboTime()
        {
            yield return new WaitForSeconds(5f);

            print("COROUTINE");
            if (comboLevel == 1)
            {
                AudioManager.instance.GreatSound();
                print("great");
            }
            else if (comboLevel == 2)
            {
                AudioManager.instance.AwesomeSound();
                print("awesome");
            }
            else if (comboLevel == 3)
            {
                AudioManager.instance.AmazingSound();
                print("amazing");
            }
            countStartCombo = 0;
            comboLevel = 0;
            Lose.canLose = true;
        }
    
}



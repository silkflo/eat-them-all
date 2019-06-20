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
        if(countStartCombo == 4) //4
        {
           
            comboLevel = 1;
        }
        if( countStartCombo  == 8) //8
        {
            comboLevel = 2;
        }
        if(countStartCombo >= 12) //12
        {
            comboLevel = 3;
        }


        print("combo count" + countStartCombo +" combo Level : " + comboLevel);
        print("has Exploded : " + BombRadius.hasExploded);
    }




    private void OnTriggerEnter2D(Collider2D target)
    {
       



        if ((target.tag == TagManager.FOOD_TAG || target.tag == TagManager.BOMB_TAG ) && Lose.canLose == false && BombRadius.hasExploded == true)
        {

            StopCoroutine("ComboTime");
            countDeactivateobject++;
                startCombo = true;
            Lose.canLose = false;
            countStartCombo++;

            print("canLose : " + Lose.canLose);
          //      print("food deactivated = " + countDeactivateobject + " NAME : " + target.gameObject.name + " TAG : " + target.gameObject.tag);


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
            
            GamePlayController.instance.greatAnim.SetBool(TagManager.GREAT_PARAMETER, true);
            StartCoroutine(SetAnimFalse());
           StartCoroutine(GreatSoundDelay());
            
            IEnumerator GreatSoundDelay()
            {
                yield return new WaitForSeconds(0.5f);
                AudioManager.instance.GreatSound();
            }

            print("great");
            }
            else if (comboLevel == 2)
            {
            GamePlayController.instance.greatAnim.SetBool(TagManager.AWESOME_PARAMETER, true);
            
            StartCoroutine(SetAnimFalse());
            StartCoroutine(AwesomeSoundDelay());

            IEnumerator AwesomeSoundDelay()
            {
                yield return new WaitForSeconds(0.5f);
                AudioManager.instance.AwesomeSound();
            }

            print("awesome");
            }
            else if (comboLevel == 3)
            {
            GamePlayController.instance.greatAnim.SetBool(TagManager.AMAZING_PARAMETER, true);
            StartCoroutine(SetAnimFalse());
            StartCoroutine(AmazingSoundDelay());


            IEnumerator AmazingSoundDelay()
            {
                yield return new WaitForSeconds(0.5f);
                    AudioManager.instance.AmazingSound();
               
            }

            print("amazing");
            }
            countStartCombo = 0;
            comboLevel = 0;

        BombRadius.hasExploded = false;
        Lose.canLose = true;


        IEnumerator SetAnimFalse()
        {
            yield return new WaitForSeconds(2f);
            GamePlayController.instance.greatAnim.SetBool(TagManager.GREAT_PARAMETER, false);
            GamePlayController.instance.greatAnim.SetBool(TagManager.AMAZING_PARAMETER, false);
            GamePlayController.instance.greatAnim.SetBool(TagManager.AWESOME_PARAMETER, false);
        }
      
      

        }
    
}



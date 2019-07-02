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

    private void Start()
    {
        countStartCombo = 0;
    }


 

    void Update()
    {

        NoDeactivate();

        if (countStartCombo >= 4 && countStartCombo <8) //4
        {
           
            comboLevel = 1;
        }
        if( countStartCombo  >= 8 && countStartCombo <12) //8
        {
            comboLevel = 2;
        }
        if(countStartCombo >= 12) //12
        {
            comboLevel = 3;
        }

     

        print("combo count : " + countStartCombo +" combo Level : " + comboLevel);
        print("has Exploded : " + BombRadius.hasExploded);
    }

    public void NoDeactivate()
    {
        if(BombRadius.hasExploded == true && countStartCombo == 0)
        {
            Lose.canLose = false;
            StartCoroutine("SetCanLose");
            print("COUNT COMBO 0");
        }
        else if(BombRadius.hasExploded == true && countStartCombo > 0)
        {
            StopCoroutine("SetCanLose");
            print("stop coroutine setcan lose");
        }

      

    }
    IEnumerator SetCanLose()
    {
        yield return new WaitForSeconds(5f);
        Lose.canLose = true;
        BombRadius.hasExploded = false;
        countStartCombo = 0;
        comboLevel = 0;
    }


    private void OnTriggerEnter2D(Collider2D target)
    {
           if ((target.tag == TagManager.FOOD_TAG || target.tag == TagManager.BOMB_TAG )  && BombRadius.hasExploded == true)
           {
                StopCoroutine("ComboTime");
                countDeactivateobject++;
                startCombo = true;
                Lose.canLose = false;
                countStartCombo++;
                itemDeactivateScore = itemDeactivateScore + 5;
                target.gameObject.SetActive(false);
                StartCoroutine("ComboTime");

            EventGA.instance.EjectInsectEvent(countDeactivateobject);

            //print("canLose : " + Lose.canLose);
            //print("food deactivated = " + countDeactivateobject + " NAME : " + target.gameObject.name + " TAG : " + target.gameObject.tag);
           }
    }
    
        IEnumerator ComboTime()
        {
            yield return new WaitForSeconds(5f);

            if (comboLevel == 1)
            {
                GamePlayController.instance.greatAnim.SetBool(TagManager.GREAT_PARAMETER, true);
                GameManager.instance.greatBoolAnim = true;
                StartCoroutine(SetAnimFalse());
                StartCoroutine(GreatSoundDelay());
                print("great");

            EventGA.instance.ComboEvent(comboLevel);

                  IEnumerator GreatSoundDelay()
                  {
                      yield return new WaitForSeconds(0.5f);
                      AudioManager.instance.GreatSound();
                  }
            }

            else if (comboLevel == 2)
            {
            GamePlayController.instance.greatAnim.SetBool(TagManager.AWESOME_PARAMETER, true);
            GameManager.instance.awesomeBoolAnim = true;
            StartCoroutine(SetAnimFalse());
            StartCoroutine(AwesomeSoundDelay());
            print("awesome");

            EventGA.instance.ComboEvent(comboLevel);

            IEnumerator AwesomeSoundDelay()
                 {
                    yield return new WaitForSeconds(0.5f);
                    AudioManager.instance.AwesomeSound();
                 }
            }

            else if (comboLevel == 3)
            {
            GamePlayController.instance.greatAnim.SetBool(TagManager.AMAZING_PARAMETER, true);
            GameManager.instance.amazingBoolAnim = true;
            StartCoroutine(SetAnimFalse());
            StartCoroutine(AmazingSoundDelay());
            print("amazing");

            EventGA.instance.ComboEvent(comboLevel);

            IEnumerator AmazingSoundDelay()
                 {
                    yield return new WaitForSeconds(0.5f);
                    AudioManager.instance.AmazingSound();
               
                 }
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

                   GameManager.instance.greatBoolAnim = false;
                   GameManager.instance.awesomeBoolAnim = false;
                   GameManager.instance.amazingBoolAnim = false;

               }
        }
    
}



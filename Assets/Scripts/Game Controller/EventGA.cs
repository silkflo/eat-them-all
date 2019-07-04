using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventGA : MonoBehaviour
{
    public static EventGA instance;


    void Start()
    {
        MakeInstance();
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    void MakeInstance()
    {
        if (instance == null)
        {
            instance = this;
        }
    }



    public void BombEvent(int bombAmount)
    {
        if (Garter.I.GetData<int>("speedLevel") == 1)
        {
            decimal bestAchievedValue = Garter.I.Event("SlowBomb");

            if (bombAmount / 10 > bestAchievedValue)
            {
                
                Garter.I.Event("SlowBomb", (bombAmount / 10 - bestAchievedValue));

                if(bombAmount/10 == 10)
                {
                    AudioManager.instance.AchievementSound();
                }
                else if(bombAmount/10 == 25)
                {
                    AudioManager.instance.AchievementSound();
                }
                else if (bombAmount / 10 == 50)
                {
                    AudioManager.instance.AchievementSound();
                }
            }
        }

        if (Garter.I.GetData<int>("speedLevel") == 2)
        {
            decimal bestAchievedValue = Garter.I.Event("NormalBomb");

            if (bombAmount / 10 > bestAchievedValue)
            {
               
                Garter.I.Event("NormalBomb", (bombAmount / 10 - bestAchievedValue));

                if (bombAmount / 10 == 10)
                {
                    AudioManager.instance.AchievementSound();
                }
                else if (bombAmount / 10 == 25)
                {
                    AudioManager.instance.AchievementSound();
                }
                else if (bombAmount / 10 == 50)
                {
                    AudioManager.instance.AchievementSound();
                }
            }
        }

        if (Garter.I.GetData<int>("speedLevel") == 3)
        {
            decimal bestAchievedValue = Garter.I.Event("FastBomb");

            if (bombAmount / 10 > bestAchievedValue)
            {
               
                Garter.I.Event("FastBomb", (bombAmount / 10 - bestAchievedValue));

                if (bombAmount / 10 == 10)
                {
                    AudioManager.instance.AchievementSound();
                }
                else if (bombAmount / 10 == 25)
                {
                    AudioManager.instance.AchievementSound();
                }
                else if (bombAmount / 10 == 50)
                {
                    AudioManager.instance.AchievementSound();
                }
            }
        }

    }

    public void ScoreEvent(int score)
    {
        if (Garter.I.GetData<int>("speedLevel") == 1)
        {
            decimal bestAchievedValue = Garter.I.Event("SlowScore");
            if (score > bestAchievedValue)
            {
               
                Garter.I.Event("SlowScore", (score - bestAchievedValue));

                if (score == 400)
                {
                    AudioManager.instance.AchievementSound();
                }
                else if (score == 700)
                {
                    AudioManager.instance.AchievementSound();
                }
                else if (score == 1000)
                {
                    AudioManager.instance.AchievementSound();
                }
            }
        }
        if (Garter.I.GetData<int>("speedLevel") == 2)
        {
            decimal bestAchievedValue = Garter.I.Event("NormalScore");

            if (score > bestAchievedValue)
            {
               
                Garter.I.Event("NormalScore", (score - bestAchievedValue));

                if (score == 400)
                {
                    AudioManager.instance.AchievementSound();
                }
                else if (score == 700)
                {
                    AudioManager.instance.AchievementSound();
                }
                else if (score == 1000)
                {
                    AudioManager.instance.AchievementSound();
                }
            }
        }

        if (Garter.I.GetData<int>("speedLevel") == 3)
        {
            decimal bestAchievedValue = Garter.I.Event("FastScore");

            if (score > bestAchievedValue)
            {
               
                Garter.I.Event("FastScore", (score - bestAchievedValue));

                if (score == 400)
                {
                    AudioManager.instance.AchievementSound();
                }
                else if (score == 700)
                {
                    AudioManager.instance.AchievementSound();
                }
                else if (score == 1000)
                {
                    AudioManager.instance.AchievementSound();
                }
            }
        }
    }

    
    public void EatInsectEvent(int insectIn)
    {
        if (Garter.I.GetData<int>("speedLevel") == 1)
        {
            decimal bestAchievedValue = Garter.I.Event("SlowInsectIn");
            if (insectIn > bestAchievedValue)
            {
               
                Garter.I.Event("SlowInsectIn", (insectIn - bestAchievedValue));

                if (insectIn == 50)
                {
                    AudioManager.instance.AchievementSound();
                }
                else if (insectIn == 100)
                {
                    AudioManager.instance.AchievementSound();
                }
                else if (insectIn == 150)
                {
                    AudioManager.instance.AchievementSound();
                }
            }
        }

        if (Garter.I.GetData<int>("speedLevel") == 2)
        {
            decimal bestAchievedValue = Garter.I.Event("NormalInsectIn");
            if (insectIn > bestAchievedValue)
            {
               
                Garter.I.Event("NormalInsectIn", (insectIn - bestAchievedValue));

                if (insectIn == 50)
                {
                    AudioManager.instance.AchievementSound();
                }
                else if (insectIn == 100)
                {
                    AudioManager.instance.AchievementSound();
                }
                else if (insectIn == 150)
                {
                    AudioManager.instance.AchievementSound();
                }
            }
        }


        if (Garter.I.GetData<int>("speedLevel") == 3)
        {
            decimal bestAchievedValue = Garter.I.Event("FastInsectIn");
            if (insectIn > bestAchievedValue)
            {
               
                Garter.I.Event("FastInsectIn", (insectIn - bestAchievedValue));

                if (insectIn == 50)
                {
                    AudioManager.instance.AchievementSound();
                }
                else if (insectIn == 100)
                {
                    AudioManager.instance.AchievementSound();
                }
                else if (insectIn == 150)
                {
                    AudioManager.instance.AchievementSound();
                }
            }
        }

    }

    public void EjectInsectEvent(int insectOut)
    {
        if (Garter.I.GetData<int>("speedLevel") == 1)
        {
            decimal bestAchievedValue = Garter.I.Event("SlowInsectOut");
            if (insectOut > bestAchievedValue)
            {
               
                Garter.I.Event("SlowInsectOut", (insectOut - bestAchievedValue));

                if (insectOut == 30)
                {
                    AudioManager.instance.AchievementSound();
                }
                else if (insectOut == 60)
                {
                    AudioManager.instance.AchievementSound();
                }
                else if (insectOut == 90)
                {
                    AudioManager.instance.AchievementSound();
                }
            }
        }

        if (Garter.I.GetData<int>("speedLevel") == 2)
        {
            decimal bestAchievedValue = Garter.I.Event("NormalInsectOut");
            if (insectOut > bestAchievedValue)
            {
               
                Garter.I.Event("NormalInsectOut", (insectOut - bestAchievedValue));

                if (insectOut == 30)
                {
                    AudioManager.instance.AchievementSound();
                }
                else if (insectOut == 60)
                {
                    AudioManager.instance.AchievementSound();
                }
                else if (insectOut == 90)
                {
                    AudioManager.instance.AchievementSound();
                }
            }
        }

        if (Garter.I.GetData<int>("speedLevel") == 3)
        {
            decimal bestAchievedValue = Garter.I.Event("FastInsectOut");
            if (insectOut > bestAchievedValue)
            {
               
                Garter.I.Event("FastInsectOut", (insectOut - bestAchievedValue));

                if (insectOut == 30)
                {
                    AudioManager.instance.AchievementSound();
                }
                else if (insectOut == 60)
                {
                    AudioManager.instance.AchievementSound();
                }
                else if (insectOut == 90)
                {
                    AudioManager.instance.AchievementSound();
                }
            }
        }
    }


    public void ComboEvent(int comboLevel)
    {
        if (Garter.I.GetData<int>("speedLevel") == 1)
        {
            decimal bestAchievedValue = Garter.I.Event("SlowCombo");
            if (comboLevel > bestAchievedValue)
            {
               
                Garter.I.Event("SlowCombo", (comboLevel - bestAchievedValue));

                if (comboLevel == 1)
                {
                    AudioManager.instance.AchievementSound();
                }
                else if (comboLevel == 2)
                {
                    AudioManager.instance.AchievementSound();
                }
                else if (comboLevel == 3)
                {
                    AudioManager.instance.AchievementSound();
                }
            }
        }

        if (Garter.I.GetData<int>("speedLevel") == 2)
        {
            decimal bestAchievedValue = Garter.I.Event("NormalCombo");
            if (comboLevel > bestAchievedValue)
            {
               
                Garter.I.Event("NormalCombo", (comboLevel - bestAchievedValue));


                if (comboLevel == 1)
                {
                    AudioManager.instance.AchievementSound();
                }
                else if (comboLevel == 2)
                {
                    AudioManager.instance.AchievementSound();
                }
                else if (comboLevel == 3)
                {
                    AudioManager.instance.AchievementSound();
                }
            }
        }

        if (Garter.I.GetData<int>("speedLevel") == 3)
        {
            decimal bestAchievedValue = Garter.I.Event("FastCombo");
            if (comboLevel > bestAchievedValue)
            {
               
                Garter.I.Event("FastCombo", (comboLevel - bestAchievedValue));


                if (comboLevel == 1)
                {
                    AudioManager.instance.AchievementSound();
                }
                else if (comboLevel == 2)
                {
                    AudioManager.instance.AchievementSound();
                }
                else if (comboLevel == 3)
                {
                    AudioManager.instance.AchievementSound();
                }
            }
        }
    }


    public void SurvivalEvent(int time)
    {
        if (Garter.I.GetData<int>("speedLevel") == 1)
        {
            decimal bestAchievedValue = Garter.I.Event("SlowSurvival");
            if (time > bestAchievedValue)
            {
               
                Garter.I.Event("SlowSurvival", (time - bestAchievedValue));


                if (time == 240)
                {
                    AudioManager.instance.AchievementSound();
                }
                else if (time == 420)
                {
                    AudioManager.instance.AchievementSound();
                }
                else if (time == 600)
                {
                    AudioManager.instance.AchievementSound();
                }
            }
        }

        if (Garter.I.GetData<int>("speedLevel") == 2)
        {
            decimal bestAchievedValue = Garter.I.Event("NormalSurvival");
            if (time > bestAchievedValue)
            {
               
                Garter.I.Event("NormalSurvival", (time - bestAchievedValue));

                if (time == 240)
                {
                    AudioManager.instance.AchievementSound();
                }
                else if (time == 420)
                {
                    AudioManager.instance.AchievementSound();
                }
                else if (time == 600)
                {
                    AudioManager.instance.AchievementSound();
                }

            }
        }

        if (Garter.I.GetData<int>("speedLevel") == 3)
        {
            decimal bestAchievedValue = Garter.I.Event("FastSurvival");
            if (time > bestAchievedValue)
            {
               
                Garter.I.Event("FastSurvival", (time - bestAchievedValue));

                if (time == 240)
                {
                    AudioManager.instance.AchievementSound();
                }
                else if (time == 420)
                {
                    AudioManager.instance.AchievementSound();
                }
                else if (time == 600)
                {
                    AudioManager.instance.AchievementSound();
                }
            }
        }
    }


}

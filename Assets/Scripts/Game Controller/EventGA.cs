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
            }
        }

        if (Garter.I.GetData<int>("speedLevel") == 2)
        {
            decimal bestAchievedValue = Garter.I.Event("NormalBomb");

            if (bombAmount / 10 > bestAchievedValue)
            {
                Garter.I.Event("NormalBomb", (bombAmount / 10 - bestAchievedValue));
            }
        }

        if (Garter.I.GetData<int>("speedLevel") == 3)
        {
            decimal bestAchievedValue = Garter.I.Event("FastBomb");

            if (bombAmount / 10 > bestAchievedValue)
            {
                Garter.I.Event("FastBomb", (bombAmount / 10 - bestAchievedValue));
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
            }
        }
        if (Garter.I.GetData<int>("speedLevel") == 2)
        {
            decimal bestAchievedValue = Garter.I.Event("NormalScore");

            if (score > bestAchievedValue)
            {
                Garter.I.Event("NormalScore", (score - bestAchievedValue));
            }
        }

        if (Garter.I.GetData<int>("speedLevel") == 3)
        {
            decimal bestAchievedValue = Garter.I.Event("FastScore");

            if (score > bestAchievedValue)
            {
                Garter.I.Event("FastScore", (score - bestAchievedValue));
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
            }
        }

        if (Garter.I.GetData<int>("speedLevel") == 2)
        {
            decimal bestAchievedValue = Garter.I.Event("NormalInsectIn");
            if (insectIn > bestAchievedValue)
            {
                Garter.I.Event("NormalInsectIn", (insectIn - bestAchievedValue));
            }
        }


        if (Garter.I.GetData<int>("speedLevel") == 3)
        {
            decimal bestAchievedValue = Garter.I.Event("FastInsectIn");
            if (insectIn > bestAchievedValue)
            {
                Garter.I.Event("FastInsectIn", (insectIn - bestAchievedValue));
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
            }
        }

        if (Garter.I.GetData<int>("speedLevel") == 2)
        {
            decimal bestAchievedValue = Garter.I.Event("NormalInsectOut");
            if (insectOut > bestAchievedValue)
            {
                Garter.I.Event("NormalInsectOut", (insectOut - bestAchievedValue));
            }
        }

        if (Garter.I.GetData<int>("speedLevel") == 3)
        {
            decimal bestAchievedValue = Garter.I.Event("FastInsectOut");
            if (insectOut > bestAchievedValue)
            {
                Garter.I.Event("FastInsectOut", (insectOut - bestAchievedValue));
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
            }
        }

        if (Garter.I.GetData<int>("speedLevel") == 2)
        {
            decimal bestAchievedValue = Garter.I.Event("NormalCombo");
            if (comboLevel > bestAchievedValue)
            {
                Garter.I.Event("NormalCombo", (comboLevel - bestAchievedValue));
            }
        }

        if (Garter.I.GetData<int>("speedLevel") == 3)
        {
            decimal bestAchievedValue = Garter.I.Event("FastCombo");
            if (comboLevel > bestAchievedValue)
            {
                Garter.I.Event("FastCombo", (comboLevel - bestAchievedValue));
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
            }
        }

        if (Garter.I.GetData<int>("speedLevel") == 2)
        {
            decimal bestAchievedValue = Garter.I.Event("NormalSurvival");
            if (time > bestAchievedValue)
            {
                Garter.I.Event("NormalSurvival", (time - bestAchievedValue));
            }
        }

        if (Garter.I.GetData<int>("speedLevel") == 3)
        {
            decimal bestAchievedValue = Garter.I.Event("FastSurvival");
            if (time > bestAchievedValue)
            {
                Garter.I.Event("FastSurvival", (time - bestAchievedValue));
            }
        }
    }


}

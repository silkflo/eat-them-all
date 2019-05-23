using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Achievement 
{

    private string name;
    public string Name { get => name; set => name = value; }
 
    private string description;
    public string Description { get => description; set => description = value; }
   

    private bool unlocked;
    public bool Unlocked { get => unlocked; set => unlocked = value; }
   

    private int spriteIndex;
    public int SpriteIndex { get => spriteIndex; set => spriteIndex = value; }
   



    private GameObject Reward;


    private GameObject achievementRef;


    public Achievement(string name, string description,int spriteIndex, GameObject achievementRef)
    {
        this.name = name;
        this.description = description;
        this.unlocked = false;
        this.spriteIndex = spriteIndex;
        this.achievementRef = achievementRef;
    }

   

    public bool EarnAchivement()
    {
        if (!unlocked)
        {
            AchievementManager.Instance.reward.SetActive(true);

            unlocked = true;
            return true;
        }
        return false;
    }
}

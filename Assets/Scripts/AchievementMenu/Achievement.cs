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
        this.achievementRef = achievementRef.transform.Find("Reward").gameObject;
        LoadAchievement();
    }

   

    public bool EarnAchivement()
    {
        if (!unlocked)
        {
            achievementRef.SetActive(true);
            SaveAchievement(true);
           
            return true;
        }
        return false;
    }

    public void SaveAchievement(bool value)
    {
        unlocked = value;

        PlayerPrefs.SetInt(name, value ? 1 : 0);
        PlayerPrefs.Save();
    }


    public void LoadAchievement()
    {
        unlocked = PlayerPrefs.GetInt(name) == 1 ? true : false;

        if (unlocked)
        {
            achievementRef.SetActive(true);
        }

    }






}

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

    private string child;
    public string Child { get => child; set => child = value; }


  //  private GameObject achievementRef;
    private GameObject achievementRef;
    private List<Achievement> depedencies = new List<Achievement>();

    public Achievement(string name, string description,int spriteIndex, GameObject achievementRef)
    {
        this.name = name;
        this.description = description;
        this.unlocked = false;
        this.spriteIndex = spriteIndex;
        this.achievementRef = achievementRef.transform.Find("Reward").gameObject;
        //this.achievementRef2 = achievementRef2;
        LoadAchievement();
    }

   

    public void AddDepedency(Achievement dependency)
    {
        depedencies.Add(dependency);
    }


    public bool EarnAchivement()
    {
        if (!unlocked && !depedencies.Exists(x => x.unlocked == false))
        {
           
             achievementRef.SetActive(true);

          

            SaveAchievement(true);

           if (child != null)
            {
                AchievementManager.Instance.EarnAchievement(child);
            }
           
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

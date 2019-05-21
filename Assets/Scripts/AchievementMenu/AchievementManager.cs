using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AchievementManager : MonoBehaviour
{

    public GameObject achievementPrefab;

    void Start()
    {
        CreateAchievement("Frog");
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void CreateAchievement(string category)
    {
        GameObject achievement = (GameObject)Instantiate(achievementPrefab);
        SetAchievementInfo(category, achievement);
    }


    public void SetAchievementInfo(string category, GameObject achievement)
    {
        achievement.transform.SetParent(GameObject.Find(category).transform);
        achievement.transform.localScale = new Vector3(1.4f, 1, 1);
    }


}

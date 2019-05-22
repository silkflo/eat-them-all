using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AchievementManager : MonoBehaviour
{

    public GameObject achievementPrefab;
    public Sprite[] medals;

    private AchievementButton activeButton;
    public ScrollRect scrollRect;

    public GameObject achievementMenu;

    public GameObject visualAchievement;

    void Start()
    {
        
        activeButton = GameObject.Find(TagManager.FROG_BUTTON).GetComponent<AchievementButton>();


        CreateAchievement(TagManager.FROG_ACHIEVEMENT, "Frog Title", "this is a test description", 2);
        CreateAchievement(TagManager.FROG_ACHIEVEMENT, "Frog Title", "this is a test description", 2);
        CreateAchievement(TagManager.FROG_ACHIEVEMENT, "Frog Title", "this is a test description", 2);
        CreateAchievement(TagManager.FROG_ACHIEVEMENT, "Frog Title", "this is a test description", 2);
        CreateAchievement(TagManager.FROG_ACHIEVEMENT, "Frog Title", "this is a test description", 2);



        CreateAchievement("Other", "other Title", "this is a test description", 0);
        CreateAchievement("Other", "other Title", "this is a test description", 0);
        CreateAchievement("Other", "other Title", "this is a test description", 0);

        foreach (GameObject achievementList in GameObject.FindGameObjectsWithTag(TagManager.ACHIEVEMENT_LIST_TAG))
        {
            achievementList.SetActive(false);
        }


        activeButton.Click();
        achievementMenu.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
/*
        if (Input.GetKeyDown(KeyCode.I))
        {
            achievementMenu.SetActive(!achievementMenu.activeSelf); 
        }
*/
    }


    public void CreateAchievement(string category, string title, string description, int medalIndex)
    {
        GameObject achievement = (GameObject)Instantiate(achievementPrefab);
        SetAchievementInfo(category, achievement, title, description, medalIndex);
    }


    public void SetAchievementInfo(string category, GameObject achievement, string title, string description, int medalIndex)
    {
        achievement.transform.SetParent(GameObject.Find(category).transform);
        achievement.transform.localScale = new Vector3(1.4f, 1, 1);
        achievement.transform.GetChild(0).GetComponent<Text>().text = title;
        achievement.transform.GetChild(1).GetComponent<Text>().text = description;
        achievement.transform.GetChild(2).GetComponent<Image>().sprite = medals[medalIndex];
    }

    public void ChangeCategory(GameObject button)
    {
        AchievementButton achievementButton = button.GetComponent<AchievementButton>();

        scrollRect.content = achievementButton.achievementList.GetComponent<RectTransform>();

        achievementButton.Click();
        activeButton.Click();
        activeButton = achievementButton;



    }
}

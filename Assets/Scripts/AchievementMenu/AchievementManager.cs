using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AchievementManager : MonoBehaviour
{

    private static AchievementManager instance;
    public static AchievementManager Instance
    {
        get
        {
            if(instance == null)
            {
                instance = GameObject.FindObjectOfType<AchievementManager>();
            }



            return AchievementManager.instance;
        }
      

    }

    public GameObject achievementPrefab;
    public Sprite[] medals;

    private AchievementButton activeButton;
    public ScrollRect scrollRect;

    public GameObject achievementMenu;

    public GameObject visualAchievement;

    public Dictionary<string, Achievement> achievements = new Dictionary<string, Achievement>();

   [HideInInspector]
    public  GameObject reward;
   

    private void Awake()
    {
       
    }

    void Start()
    {

        reward = GameObject.FindGameObjectWithTag("GoldReward");
        activeButton = GameObject.Find(TagManager.FROG_BUTTON).GetComponent<AchievementButton>();


        CreateAchievement(TagManager.FROG_ACHIEVEMENT, "Press W", "press W to unlock this achievement", 0);


        foreach (GameObject achievementList in GameObject.FindGameObjectsWithTag(TagManager.ACHIEVEMENT_LIST_TAG))
        {
            achievementList.SetActive(false);
        }
        

        activeButton.Click();
       // achievementMenu.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {

    /*    if (Input.GetKeyDown(KeyCode.I))
        {
            achievementMenu.SetActive(!achievementMenu.activeSelf); 
        }
        */
        if (Input.GetKeyDown(KeyCode.W))
        {
            EarnAchievement("Press W");
        }

    }


    public void EarnAchievement(string title)
    {
        if (achievements[title].EarnAchivement())
        {
            //DO something
            GameObject achievement = (GameObject)Instantiate(visualAchievement);

            SetAchievementInfo("EarnCanvas", achievement, title);

            StartCoroutine(HideAchievement(achievement));
        }


    }

  

    public IEnumerator HideAchievement(GameObject achievement)
    {
        yield return new WaitForSeconds(3f);
        Destroy(achievement);
    }


    public void CreateAchievement(string parent, string title, string description, int medalIndex)
    {
        GameObject achievement = (GameObject)Instantiate(achievementPrefab);


        Achievement newAchievement = new Achievement(name, description, medalIndex, achievement);

        achievements.Add(title, newAchievement);

        SetAchievementInfo(parent, achievement, title);
    }


    public void SetAchievementInfo(string parent, GameObject achievement, string title)
    {
        achievement.transform.SetParent(GameObject.Find(parent).transform);
         achievement.transform.localScale = new Vector3(1.4f, 1, 1);
        achievement.transform.GetChild(0).GetComponent<Text>().text = title;
        achievement.transform.GetChild(1).GetComponent<Text>().text = achievements[title].Description;
        achievement.transform.GetChild(2).GetComponent<Image>().sprite =medals [achievements[title].SpriteIndex];
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

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

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

    public  Dictionary<string, Achievement> achievements = new Dictionary<string, Achievement>();

  

    private int fadeTime = 2;

    private void Awake()
    {
       
    }

    void Start()
    {
        //Delete all save data in game
     // PlayerPrefs.DeleteAll();



        activeButton = GameObject.Find(TagManager.FROG_BUTTON).GetComponent<AchievementButton>();

        AchievementList();



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
        
               if (Input.GetKeyDown(KeyCode.A) && SceneManager.GetActiveScene() == SceneManager.GetSceneByName(TagManager.FROG_SCENE))
               {
                    achievementMenu.SetActive(!achievementMenu.activeSelf); 
                    
                   if(achievementMenu.activeSelf == true)
                    {
                        Time.timeScale = 0f;
                    }
                    else
                    {
                        Time.timeScale = 1f;
                    }
               }
              else if (SceneManager.GetActiveScene() == SceneManager.GetSceneByName(TagManager.ACHIEVEMENT_SCENE))
               {
                    achievementMenu.SetActive(true);
               }


                AchievementGoal();
    }

    public void EarnAchievement(string title)
    {
        if (achievements[title].EarnAchivement())
        {
         
            GameObject achievement = Instantiate(visualAchievement);

            SetAchievementInfo("EarnCanvas", achievement, title);

            StartCoroutine(FadeAchievemen(achievement));
        }


    }

    private IEnumerator FadeAchievemen(GameObject achievement)
    {
        CanvasGroup canvasGroup = achievement.GetComponent<CanvasGroup>();
        float rate = 1.0f / fadeTime;

        int startAlpha = 0;
        int endAlpha = 1;




        for (int i = 0; i < 2; i++)
        {
            float progress = 0.0f;

            while (progress < 1.0)
            {

                canvasGroup.alpha = Mathf.Lerp(startAlpha, endAlpha, progress);

                progress += rate * Time.deltaTime;

                yield return null;
            }

            yield return new WaitForSeconds(2f);
            startAlpha = 1;
            endAlpha = 0;

        }

        Destroy(achievement);


    }



    public void CreateAchievement(string parent, string title, string description, int medalIndex, string[] depedencies = null)
    {
        GameObject achievement = (GameObject)Instantiate(achievementPrefab);


        Achievement newAchievement = new Achievement(title, description, medalIndex, achievement);

        achievements.Add(title, newAchievement);

        SetAchievementInfo(parent, achievement, title);

      

        if (depedencies != null)
        {
            foreach(string achievementTitle in depedencies)
            {
                Achievement depedency = achievements[achievementTitle];
                depedency.Child = title;
                newAchievement.AddDepedency(depedency);
            } // creation of achievement dependency
        }
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




    void AchievementList()
    {
        // CREATE ACHIEVEMENT LIST
        //ACHIEVEMENT TEST
        CreateAchievement(TagManager.FROG_ACHIEVEMENT, "Press W", "beat 400 in easy difficulty", 2);
        CreateAchievement(TagManager.FROG_ACHIEVEMENT, "Press X", "beat 800 in easy difficulty", 1);


        //SCORE ACHIEVEMENT-----------------------------------------------------------------------------------------
        CreateAchievement(TagManager.FROG_ACHIEVEMENT, "Easy Score 400", "Beat 400 in easy difficulty", 2);
        CreateAchievement(TagManager.FROG_ACHIEVEMENT, "Easy Score 800", "Beat 800 in easy difficulty", 1);
        CreateAchievement(TagManager.FROG_ACHIEVEMENT, "Easy Score 2000", "Beat 2000 in easy difficulty", 0);

        CreateAchievement(TagManager.FROG_ACHIEVEMENT, "Medium Score 400", "Beat 400 in easy difficulty", 2);
        CreateAchievement(TagManager.FROG_ACHIEVEMENT, "Medium Score 800", "Beat 800 in easy difficulty", 1);
        CreateAchievement(TagManager.FROG_ACHIEVEMENT, "Medium Score 2000", "Beat 2000 in easy difficulty", 0);

        CreateAchievement(TagManager.FROG_ACHIEVEMENT, "Difficult Score 400", "Beat 400 in easy difficulty", 2);
        CreateAchievement(TagManager.FROG_ACHIEVEMENT, "Difficult Score 800", "Beat 800 in easy difficulty", 1);
        CreateAchievement(TagManager.FROG_ACHIEVEMENT, "Difficult Score 2000", "Beat 2000 in easy difficulty", 0);


        CreateAchievement(TagManager.FROG_ACHIEVEMENT, "All Score Achievement", "Beat all scores in all dificulties", 0, 
                          new string[] { "Easy Score 400", "Easy Score 800", "Easy Score 2000",
                                         "Medium Score 400", "Medium Score 800", "Medium Score 2000",
                                         "Difficult Score 400", "Difficult Score 800", "Difficult Score 2000"});

     

        //EXPULSION FOODS ACHIEVEMENT---------------------------------------------------------------------------------------
        CreateAchievement(TagManager.FROG_ACHIEVEMENT, "Easy eat 50 insects", "Eat 50 insects in easy difficulty", 2);
        CreateAchievement(TagManager.FROG_ACHIEVEMENT, "Easy eat 100 insects", "Eat 100 insects in easy difficulty", 1);
        CreateAchievement(TagManager.FROG_ACHIEVEMENT, "Easy eat 200 insects", "Eat 200 insects in easy difficulty", 0);

        CreateAchievement(TagManager.FROG_ACHIEVEMENT, "Medium eat 50 insects", "Eat 50 insects in easy difficulty", 2);
        CreateAchievement(TagManager.FROG_ACHIEVEMENT, "Medium eat 100 insects", "Eat 100 insects in easy difficulty", 1);
        CreateAchievement(TagManager.FROG_ACHIEVEMENT, "Medium eat 200 insects", "Eat 200 insects in easy difficulty", 0);

        CreateAchievement(TagManager.FROG_ACHIEVEMENT, "Difficult eat 50 insects", "Eat 50 insects in easy difficulty", 2);
        CreateAchievement(TagManager.FROG_ACHIEVEMENT, "Difficult eat 100 insects", "Eat 100 insects in easy difficulty", 1);
        CreateAchievement(TagManager.FROG_ACHIEVEMENT, "Difficult eat 200 insects", "Eat 200 insects in easy difficulty", 0);


        CreateAchievement(TagManager.FROG_ACHIEVEMENT, "All insects eaten", "Eat all insects in all dificulties", 0,
                         new string[] {  "Easy eat 50 insects","Easy eat 100 insects","Easy eat 200 insects",
                                         "Medium eat 50 insects","Medium eat 100 insects","Medium eat 200 insects",
                                         "Difficult eat 50 insects","Easy eat 100 insects","Difficult eat 200 insects"});



        //OTHER LEVEL
        CreateAchievement("Other", "Press ABC", "press ABC to unlock this achievement", 1);
    }


    //SET GOAL of all achievement here
    void AchievementGoal()
    {

        //TEST-----------------------------------------------------------------------------------------

        if (Input.GetKeyDown(KeyCode.W))
        {
            EarnAchievement("Press W");
        }

        if (Input.GetKeyDown(KeyCode.X))
        {
            EarnAchievement("Press X");
        }


        //SCORE--------------------------------------------------------------------------------------
        //Easy
        if (Score.totalScore > 399 && GamePreferences.GetEasyDifficulty() == 1)
        {
            EarnAchievement("Easy Score 400");
        }
        if (Score.totalScore > 799 && GamePreferences.GetEasyDifficulty() == 1)
        {
            EarnAchievement("Easy Score 800");
        }
        if (Score.totalScore > 2000 && GamePreferences.GetEasyDifficulty() == 1)
        {
            EarnAchievement("Easy Score 2000");
        }

        //Medium
        if (Score.totalScore > 399 && GamePreferences.GetMediumDifficulty() == 1)
        {
            EarnAchievement("Medium Score 400");
        }
        if (Score.totalScore > 799 && GamePreferences.GetMediumDifficulty() == 1)
        {
            EarnAchievement("Medium Score 800");
        }
        if (Score.totalScore > 2000 && GamePreferences.GetMediumDifficulty() == 1)
        {
            EarnAchievement("Medium Score 2000");
        }

        //Difficult
        if (Score.totalScore > 399 && GamePreferences.GetHardDifficulty() == 1)
        {
            EarnAchievement("Difficult Score 400");
        }
        if (Score.totalScore > 799 && GamePreferences.GetHardDifficulty() == 1)
        {
            EarnAchievement("Difficult Score 800");
        }
        if (Score.totalScore > 2000 && GamePreferences.GetHardDifficulty() == 1)
        {
            EarnAchievement("Difficult Score 2000");
        }



        //INSECT EATEN-----------------------------------------------------------------
        //Easy
        if (SpawnFood.scoreBySpawn > 50 && GamePreferences.GetEasyDifficulty() == 1)
        {
            EarnAchievement("Easy eat 50 insects");
        }
        if (SpawnFood.scoreBySpawn >100 && GamePreferences.GetEasyDifficulty() == 1)
        {
            EarnAchievement("Easy eat 100 insects");
        }
        if (SpawnFood.scoreBySpawn > 200 && GamePreferences.GetEasyDifficulty() == 1)
        {
            EarnAchievement("Easy eat 200 insects");
        }

        //Medium
        if (SpawnFood.scoreBySpawn > 50 && GamePreferences.GetMediumDifficulty() == 1)
        {
            EarnAchievement("Medium eat 50 insects");
        }
        if (SpawnFood.scoreBySpawn > 100 && GamePreferences.GetMediumDifficulty() == 1)
        {
            EarnAchievement("Medium eat 100 insects");
        }
        if (SpawnFood.scoreBySpawn > 200 && GamePreferences.GetMediumDifficulty() == 1)
        {
            EarnAchievement("Medium eat 200 insects");
        }

        //Difficult
        if (SpawnFood.scoreBySpawn > 50 && GamePreferences.GetHardDifficulty() == 1)
        {
            EarnAchievement("Difficult eat 50 insects");
        }
        if (SpawnFood.scoreBySpawn > 100 && GamePreferences.GetHardDifficulty() == 1)
        {
            EarnAchievement("Difficult eat 100 insects");
        }
        if (SpawnFood.scoreBySpawn > 200 && GamePreferences.GetHardDifficulty() == 1)
        {
            EarnAchievement("Difficult eat 200 insects");
        }

    }



}

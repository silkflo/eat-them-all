
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
            if (instance == null)
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



    private int fadeTime = 2;

    private void Awake()
    {

    }

    void Start()
    {
        //Delete all save data in game
        //PlayerPrefs.DeleteAll();



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
            foreach (string achievementTitle in depedencies)
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
        achievement.transform.GetChild(2).GetComponent<Image>().sprite = medals[achievements[title].SpriteIndex];
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
      
     

        //CreateAchievement(TagManager.FROG_ACHIEVEMENT, "Press W", "beat 400 in slow difficulty", 2);
        //CreateAchievement(TagManager.FROG_ACHIEVEMENT, "Press X", "beat 800 in slow difficulty", 1);
        


        //-------------------------------------FROG-----------------------------------------------------------------
        //SCORE ACHIEVEMENT-----------------------------------------------------------------------------------------
        CreateAchievement(TagManager.FROG_ACHIEVEMENT, "SLOW SCORE 400", "BEAT 400 IN SLOW DIFFICULTY", 2);
        CreateAchievement(TagManager.FROG_ACHIEVEMENT, "SLOW SCORE 700", "BEAT 700 IN SLOW DIFFICULTY", 1);
        CreateAchievement(TagManager.FROG_ACHIEVEMENT, "SLOW SCORE 1000", "BEAT 1000 IN SLOW DIFFICULTY", 0);

        CreateAchievement(TagManager.FROG_ACHIEVEMENT, "NORMAL SCORE 400", "BEAT 400 IN NORMAL DIFFICULTY", 2);
        CreateAchievement(TagManager.FROG_ACHIEVEMENT, "NORMAL SCORE 700", "BEAT 700 IN NORMAL DIFFICULTY", 1);
        CreateAchievement(TagManager.FROG_ACHIEVEMENT, "NORMAL SCORE 1000", "BEAT 1000 IN NORMAL DIFFICULTY", 0);

        CreateAchievement(TagManager.FROG_ACHIEVEMENT, "FAST SCORE 400", "BEAT 400 IN FAST DIFFICULTY", 2);
        CreateAchievement(TagManager.FROG_ACHIEVEMENT, "FAST SCORE 700", "BEAT 700 IN FAST DIFFICULTY", 1);
        CreateAchievement(TagManager.FROG_ACHIEVEMENT, "FAST SCORE 1000", "BEAT 1000 IN FAST DIFFICULTY", 0);


        CreateAchievement(TagManager.FROG_ACHIEVEMENT, "ALL SCORE ACHIEVEMENT", "BEAT ALL SCORES IN ALL DIFICULTIES", 0,
                          new string[] { "SLOW SCORE 400", "SLOW SCORE 700", "SLOW SCORE 1000",
                                         "NORMAL SCORE 400", "NORMAL SCORE 700", "NORMAL SCORE 1000",
                                         "FAST SCORE 400", "FAST SCORE 700", "FAST SCORE 1000"});



        //EXPULSION FOODS ACHIEVEMENT---------------------------------------------------------------------------------------
        CreateAchievement(TagManager.FROG_ACHIEVEMENT, "SLOW EAT 50 INSECTS", "EAT 50 INSECTS IN SLOW DIFFICULTY", 2);
        CreateAchievement(TagManager.FROG_ACHIEVEMENT, "SLOW EAT 100 INSECTS", "EAT 100 INSECTS IN SLOW DIFFICULTY", 1);
        CreateAchievement(TagManager.FROG_ACHIEVEMENT, "SLOW EAT 150 INSECTS", "EAT 150 INSECTS IN SLOW DIFFICULTY", 0);

        CreateAchievement(TagManager.FROG_ACHIEVEMENT, "NORMAL EAT 50 INSECTS", "EAT 50 INSECTS IN NORMAL DIFFICULty", 2);
        CreateAchievement(TagManager.FROG_ACHIEVEMENT, "NORMAL EAT 100 INSECTS", "EAT 100 INSECTS IN NORMAL DIFFICulty", 1);
        CreateAchievement(TagManager.FROG_ACHIEVEMENT, "NORMAL EAT 150 INSECTS", "EAT 150 INSECTS IN NORMAL DIFFICulty", 0);

        CreateAchievement(TagManager.FROG_ACHIEVEMENT, "FAST EAT 50 INSECTS", "EAT 50 INSECTS IN FAST DIFFICULTY", 2);
        CreateAchievement(TagManager.FROG_ACHIEVEMENT, "FAST EAT 100 INSECTS", "EAT 100 INSECTS IN FAST DIFFICULTY", 1);
        CreateAchievement(TagManager.FROG_ACHIEVEMENT, "FAST EAT 150 INSECTS", "EAT 150 INSECTS IN FAST DIFFICULTY", 0);


        CreateAchievement(TagManager.FROG_ACHIEVEMENT, "BIG EATER", "EAT ALL INSECTS IN ALL DIFICULTIES", 0,
                         new string[] {  "SLOW EAT 50 INSECTS","SLOW EAT 100 INSECTS","SLOW EAT 150 INSECTS",
                                         "NORMAL EAT 50 INSECTS","NORMAL EAT 100 INSECTS","NORMAL EAT 150 INSECTS",
                                         "FAST EAT 50 INSECTS","FAST EAT 100 INSECTS","FAST EAT 150 INSECTS"});



        //EXPULSE OBJECTS----------------------------------------------------------------------------------------------------------
        CreateAchievement(TagManager.FROG_ACHIEVEMENT, "SLOW EJECT 30 INSECTS", "EJECT 30 INSECTS IN SLOW DIFFICULTY", 2);
        CreateAchievement(TagManager.FROG_ACHIEVEMENT, "SLOW EJECT 60 INSECTS", "EJECT 60 INSECTS IN SLOW DIFFICULTY", 1);
        CreateAchievement(TagManager.FROG_ACHIEVEMENT, "SLOW EJECT 90 INSECTS", "EJECT 90 INSECTS IN SLOW DIFFICULTY", 0);

        CreateAchievement(TagManager.FROG_ACHIEVEMENT, "NORMAL EJECT 30 INSECTS", "EJECT 30 INSECTS IN NORMAL DIFFICULTY", 2);
        CreateAchievement(TagManager.FROG_ACHIEVEMENT, "NORMAL EJECT 60 INSECTS", "EJECT 60 INSECTS IN NORMAL DIFFICULTY", 1);
        CreateAchievement(TagManager.FROG_ACHIEVEMENT, "NORMAL EJECT 90 INSECTS", "EJECT 90 INSECTS IN NORMAL DIFFICULTY", 0);

        CreateAchievement(TagManager.FROG_ACHIEVEMENT, "FAST EJECT 30 INSECTS", "EJECT 30 INSECTS IN FAST DIFFICULTY", 2);
        CreateAchievement(TagManager.FROG_ACHIEVEMENT, "FAST EJECT 60 INSECTS", "EJECT 60 INSECTS IN FAST DIFFICULTY", 1);
        CreateAchievement(TagManager.FROG_ACHIEVEMENT, "FAST EJECT 90 INSECTS", "EJECT 90 INSECTS IN FAST DIFFICULTY", 0);



        CreateAchievement(TagManager.FROG_ACHIEVEMENT, "MASTER OF INSECTS THROW UP", "EJECT ALL INSECTS IN ALL DIFICULTIES", 0,
                      new string[] { "SLOW EJECT 30 INSECTS", "SLOW EJECT 60 INSECTS", "SLOW EJECT 90 INSECTS",
                                     "NORMAL EJECT 30 INSECTS", "NORMAL EJECT 60 INSECTS", "NORMAL EJECT 90 INSECTS",
                                     "FAST EJECT 30 INSECTS", "FAST EJECT 60 INSECTS", "FAST EJECT 90 INSECTS",});

            

        //COMBO-----------------------------------------------------------------------------------------------------------------------
        CreateAchievement(TagManager.FROG_ACHIEVEMENT, "SLOW GREAT COMBO", "GREAT COMBO IN SLOW DIFFICULTY", 2);
        CreateAchievement(TagManager.FROG_ACHIEVEMENT, "SLOW AWESOME COMBO", "AWESOME COMBO IN SLOW DIFFICULTY", 1);
        CreateAchievement(TagManager.FROG_ACHIEVEMENT, "SLOW AMAZING COMBO", "AMAZING COMBO IN SLOW DIFFICULTY", 0);

        CreateAchievement(TagManager.FROG_ACHIEVEMENT, "NORMAL GREAT COMBO", "GREAT COMBO IN NORMAL DIFFICULTY", 2);
        CreateAchievement(TagManager.FROG_ACHIEVEMENT, "NORMAL AWESOME COMBO", "AWESOME COMBO IN NORMAL DIFFICULTY", 1);
        CreateAchievement(TagManager.FROG_ACHIEVEMENT, "NORMAL AMAZING COMBO", "AMAZING COMBO IN NORMAL DIFFICULTY", 0);

        CreateAchievement(TagManager.FROG_ACHIEVEMENT, "FAST GREAT COMBO", "GREAT COMBO IN FAST DIFFICULTY", 2);
        CreateAchievement(TagManager.FROG_ACHIEVEMENT, "FAST AWESOME COMBO", "AWESOME COMBO IN FAST DIFFICULTY", 1);
        CreateAchievement(TagManager.FROG_ACHIEVEMENT, "FAST AMAZING COMBO", "AMAZING COMBO IN FAST DIFFICULTY", 0);

        CreateAchievement(TagManager.FROG_ACHIEVEMENT, "MASTER OF COMBO", "ALL COMBOS IN ALL DIFICULTIES", 0,
                      new string[] { "SLOW GREAT COMBO", "SLOW AWESOME COMBO", "SLOW AMAZING COMBO",
                                     "NORMAL GREAT COMBO", "NORMAL AWESOME COMBO", "NORMAL AMAZING COMBO",
                                     "FAST GREAT COMBO", "FAST AWESOME COMBO", "FAST AMAZING COMBO"});



        //BOMB EXPLODE
        CreateAchievement(TagManager.FROG_ACHIEVEMENT, "SLOW 10 BOMBS BLOW UP", "10 BOMBS BLOW UP IN SLOW DIFFICULTY", 2);
        CreateAchievement(TagManager.FROG_ACHIEVEMENT, "SLOW 25 BOMBS BLOW UP", "25 BOMBS BLOW UP IN SLOW DIFFICULTY", 1);
        CreateAchievement(TagManager.FROG_ACHIEVEMENT, "SLOW 40 BOMBS BLOW UP", "40 BOMBS BLOW UP IN SLOW DIFFICULTY", 0);

        CreateAchievement(TagManager.FROG_ACHIEVEMENT, "NORMAL 10 BOMBS BLOW UP", "10 BOMBS BLOW UP IN NORMAL DIFFICULTY", 2);
        CreateAchievement(TagManager.FROG_ACHIEVEMENT, "NORMAL 25 BOMBS BLOW UP", "25 BOMBS BLOW UP IN NORMAL DIFFICULTY", 1);
        CreateAchievement(TagManager.FROG_ACHIEVEMENT, "NORMAL 40 BOMBS BLOW UP", "40 BOMBS BLOW UP IN NORMAL DIFFICULTY", 0);

        CreateAchievement(TagManager.FROG_ACHIEVEMENT, "FAST 10 BOMBS BLOW UP", "10 BOMBS BLOW UP IN HARD DIFFICULTY", 2);
        CreateAchievement(TagManager.FROG_ACHIEVEMENT, "FAST 25 BOMBS BLOW UP", "25 BOMBS BLOW UP IN HARD DIFFICULTY", 1);
        CreateAchievement(TagManager.FROG_ACHIEVEMENT, "FAST 40 BOMBS BLOW UP", "40 BOMBS BLOW UP IN HARD DIFFICULTY", 0);

        CreateAchievement(TagManager.FROG_ACHIEVEMENT, "MASTER OF BOMBS", "BLOW UP ALL BOMBS ACHIEVEMENT IN ALL DIFICULTIES", 0,
                      new string[] { "SLOW 10 BOMBS BLOW UP", "SLOW 25 BOMBS BLOW UP", "SLOW 40 BOMBS BLOW UP",
                                     "NORMAL 10 BOMBS BLOW UP", "NORMAL 25 BOMBS BLOW UP", "NORMAL 40 BOMBS BLOW UP",
                                     "FAST 10 BOMBS BLOW UP", "FAST 25 BOMBS BLOW UP", "FAST 40 BOMBS BLOW UP"});



        //TIME ACHIEVEMENT
        CreateAchievement(TagManager.FROG_ACHIEVEMENT, "SLOW 4 MINUTES SURVIVAL", "SURVIVE 4 MINUTES IN SLOW DIFFICULTY", 2);
        CreateAchievement(TagManager.FROG_ACHIEVEMENT, "SLOW 7 MINUTES SURVIVAL", "SURVIVE 7 MINUTES IN SLOW DIFFICULTY", 1);
        CreateAchievement(TagManager.FROG_ACHIEVEMENT, "SLOW 10 MINUTES SURVIVAL", "SURVIVE 10 MINUTES IN SLOW DIFFICULTY", 0);

        CreateAchievement(TagManager.FROG_ACHIEVEMENT, "NORMAL 4 MINUTES SURVIVAL", "SURVIVE 4 MINUTES IN NORMAL DIFFICULTY", 2);
        CreateAchievement(TagManager.FROG_ACHIEVEMENT, "NORMAL 7 MINUTES SURVIVAL", "SURVIVE 7 MINUTES IN NORMAL DIFFICULTY", 1);
        CreateAchievement(TagManager.FROG_ACHIEVEMENT, "NORMAL 10 MINUTES SURVIVAL", "SURVIVE 10 MINUTES IN NORMAL DIFFICULTY", 0);

        CreateAchievement(TagManager.FROG_ACHIEVEMENT, "FAST 4 MINUTES SURVIVAL", "SURVIVE 4 MINUTES IN FAST DIFFICULTY", 2);
        CreateAchievement(TagManager.FROG_ACHIEVEMENT, "FAST 7 MINUTES SURVIVAL", "SURVIVE 7 MINUTES IN FAST DIFFICULTY", 1);
        CreateAchievement(TagManager.FROG_ACHIEVEMENT, "FAST 10 MINUTES SURVIVAL", "SURVIVE 10 MINUTES IN FAST DIFFICULTY", 0);

        CreateAchievement(TagManager.FROG_ACHIEVEMENT, "SURVIVOR", "SURVIVE IN ALL DIFICULTIES", 0,
                      new string[] { "SLOW 4 MINUTES SURVIVAL", "SLOW 7 MINUTES SURVIVAL", "SLOW 10 MINUTES SURVIVAL",
                                     "NORMAL 4 MINUTES SURVIVAL", "NORMAL 7 MINUTES SURVIVAL", "NORMAL 10 MINUTES SURVIVAL",
                                     "FAST 4 MINUTES SURVIVAL", "FAST 7 MINUTES SURVIVAL", "FAST 10 MINUTES SURVIVAL"});



        //GAME MASTER
        CreateAchievement(TagManager.FROG_ACHIEVEMENT, "GAME MASTER", "SUCCEED ALL ACHIEVEMENTS", 0,
                      new string[] { "ALL SCORE ACHIEVEMENT", "BIG EATER", "MASTER OF INSECTS THROW UP",
                                     "MASTER OF COMBO","MASTER OF BOMBS","SURVIVOR"});

        //--------------------------------------OTHER LEVEL----------------------------------------------------------------------
        CreateAchievement("Other", "Press ABC", "press ABC to unlock this achievement", 1);
    }


    //SET GOAL of all achievement here
    void AchievementGoal()
    {

        //TEST-----------------------------------------------------------------------------------------
/*
        if (Input.GetKeyDown(KeyCode.W))
        {
            EarnAchievement("Press W");
        }

        if (Input.GetKeyDown(KeyCode.X))
        {
            EarnAchievement("Press X");
        }
*/

        //SCORE--------------------------------------------------------------------------------------
        //slow
        if (Score.totalScore > 399 && GamePreferences.GetEasyDifficulty() == 1)
        {
            EarnAchievement("SLOW SCORE 400");
        }
        if (Score.totalScore > 699 && GamePreferences.GetEasyDifficulty() == 1)
        {
            EarnAchievement("SLOW SCORE 700");
        }
        if (Score.totalScore > 999 && GamePreferences.GetEasyDifficulty() == 1)
        {
            EarnAchievement("SLOW SCORE 1000");
        }

        //Medium
        if (Score.totalScore > 399 && GamePreferences.GetMediumDifficulty() == 1)
        {
            EarnAchievement("NORMAL SCORE 400");
        }
        if (Score.totalScore > 699 && GamePreferences.GetMediumDifficulty() == 1)
        {
            EarnAchievement("NORMAL SCORE 700");
        }
        if (Score.totalScore > 999 && GamePreferences.GetMediumDifficulty() == 1)
        {
            EarnAchievement("NORMAL SCORE 1000");
        }

        //Difficult
        if (Score.totalScore > 399 && GamePreferences.GetHardDifficulty() == 1)
        {
            EarnAchievement("FAST SCORE 400");
        }
        if (Score.totalScore > 699 && GamePreferences.GetHardDifficulty() == 1)
        {
            EarnAchievement("FAST SCORE 700");
        }
        if (Score.totalScore > 999 && GamePreferences.GetHardDifficulty() == 1)
        {
            EarnAchievement("FAST SCORE 1000");
        }



        //INSECT EATEN-----------------------------------------------------------------
        //slow
        if (SpawnFood.scoreBySpawn > 49 && GamePreferences.GetEasyDifficulty() == 1)
        {
            EarnAchievement("SLOW EAT 50 INSECTS");
        }
        if (SpawnFood.scoreBySpawn > 99 && GamePreferences.GetEasyDifficulty() == 1)
        {
            EarnAchievement("SLOW EAT 100 INSECTS");
        }
        if (SpawnFood.scoreBySpawn > 149 && GamePreferences.GetEasyDifficulty() == 1)
        {
            EarnAchievement("SLOW EAT 150 INSECTS");
        }

        //Medium
        if (SpawnFood.scoreBySpawn > 49 && GamePreferences.GetMediumDifficulty() == 1)
        {
            EarnAchievement("NORMAL EAT 50 INSECTS");
        }
        if (SpawnFood.scoreBySpawn > 99 && GamePreferences.GetMediumDifficulty() == 1)
        {
            EarnAchievement("NORMAL EAT 100 INSECTS");
        }
        if (SpawnFood.scoreBySpawn > 149 && GamePreferences.GetMediumDifficulty() == 1)
        {
            EarnAchievement("NORMAL EAT 150 INSECTS");
        }

        //Difficult
        if (SpawnFood.scoreBySpawn > 49 && GamePreferences.GetHardDifficulty() == 1)
        {
            EarnAchievement("FAST EAT 50 INSECTS");
        }
        if (SpawnFood.scoreBySpawn > 99 && GamePreferences.GetHardDifficulty() == 1)
        {
            EarnAchievement("FAST EAT 100 INSECTS");
        }
        if (SpawnFood.scoreBySpawn > 149 && GamePreferences.GetHardDifficulty() == 1)
        {
            EarnAchievement("FAST EAT 150 INSECTS");
        }



        //eject INSECTS---------------------------------------------------------------
        //slow
        if(DeactivateFood.countDeactivateobject >29 && GamePreferences.GetEasyDifficulty() == 1)
        {
            EarnAchievement("SLOW EJECT 30 INSECTS");
        }
        if (DeactivateFood.countDeactivateobject > 59 && GamePreferences.GetEasyDifficulty() == 1)
        {
            EarnAchievement("SLOW EJECT 60 INSECTS");
        }
        if (DeactivateFood.countDeactivateobject > 89 && GamePreferences.GetEasyDifficulty() == 1)
        {
            EarnAchievement("SLOW EJECT 90 INSECTS");
        }

        //Medium
        if (DeactivateFood.countDeactivateobject > 29 && GamePreferences.GetMediumDifficulty() == 1)
        {
            EarnAchievement("NORMAL EJECT 30 INSECTS");
        }
        if (DeactivateFood.countDeactivateobject > 59 && GamePreferences.GetMediumDifficulty() == 1)
        {
            EarnAchievement("NORMAL EJECT 60 INSECTS");
        }
        if (DeactivateFood.countDeactivateobject > 89 && GamePreferences.GetMediumDifficulty() == 1)
        {
            EarnAchievement("NORMAL EJECT 90 INSECTS");
        }

        //Difficult
        if (DeactivateFood.countDeactivateobject > 29 && GamePreferences.GetHardDifficulty() == 1)
        {
            EarnAchievement("FAST EJECT 30 INSECTS");
        }
        if (DeactivateFood.countDeactivateobject > 59 && GamePreferences.GetHardDifficulty() == 1)
        {
            EarnAchievement("FAST EJECT 60 INSECTS");
        }
        if (DeactivateFood.countDeactivateobject > 89 && GamePreferences.GetHardDifficulty() == 1)
        {
            EarnAchievement("FAST EJECT 90 INSECTS");
        }



        //COMBO---------------------------------------------------------------
        //slow
        if (GameManager.instance.greatBoolAnim == true && GamePreferences.GetEasyDifficulty() == 1)
        {
            EarnAchievement("SLOW GREAT COMBO");
        }
        if (GameManager.instance.awesomeBoolAnim == true  && GamePreferences.GetEasyDifficulty() == 1)
        {
            EarnAchievement("SLOW AWESOME COMBO");
        }
        if (GameManager.instance.amazingBoolAnim == true && GamePreferences.GetEasyDifficulty() == 1)
        {
            EarnAchievement("SLOW AMAZING COMBO");
        }


        //Medium
        if (GameManager.instance.greatBoolAnim == true && GamePreferences.GetMediumDifficulty() == 1)
        {
            EarnAchievement("NORMAL GREAT COMBO");
        }
        if (GameManager.instance.awesomeBoolAnim == true && GamePreferences.GetMediumDifficulty() == 1)
        {
            EarnAchievement("NORMAL AWESOME COMBO");
        }
        if (GameManager.instance.amazingBoolAnim == true && GamePreferences.GetMediumDifficulty() == 1)
        {
            EarnAchievement("NORMAL AMAZING COMBO");
        }

        //Difficult
        if (GameManager.instance.greatBoolAnim == true && GamePreferences.GetHardDifficulty() == 1)
        {
            EarnAchievement("FAST GREAT COMBO");
        }
        if (GameManager.instance.awesomeBoolAnim == true && GamePreferences.GetHardDifficulty() == 1)
        {
            EarnAchievement("FAST AWESOME COMBO");
        }
        if (GameManager.instance.amazingBoolAnim == true && GamePreferences.GetHardDifficulty() == 1)
        {
            EarnAchievement("FAST AMAZING COMBO");
        }



        //BOMB EXPLOSE---------------------------------------------------------------
        //slow
        if (BombScript.scoreByBomb > 90 && GamePreferences.GetEasyDifficulty() == 1)
        {
            EarnAchievement("SLOW 10 BOMBS BLOW UP");
        }
        if (BombScript.scoreByBomb > 240 && GamePreferences.GetEasyDifficulty() == 1)
        {
            EarnAchievement("SLOW 25 BOMBS BLOW UP");
        }
        if (BombScript.scoreByBomb > 390  && GamePreferences.GetEasyDifficulty() == 1)
        {
            EarnAchievement("SLOW 40 BOMBS BLOW UP");
        }

        //Medium
        if (BombScript.scoreByBomb > 90 && GamePreferences.GetMediumDifficulty() == 1)
        {
            EarnAchievement("NORMAL 10 BOMBS BLOW UP");
        }
        if (BombScript.scoreByBomb > 240 && GamePreferences.GetMediumDifficulty() == 1)
        {
            EarnAchievement("NORMAL 25 BOMBS BLOW UP");
        }
        if (BombScript.scoreByBomb > 390  && GamePreferences.GetMediumDifficulty() == 1)
        {
            EarnAchievement("NORMAL 40 BOMBS BLOW UP");
        }

        //Difficult
        if (BombScript.scoreByBomb > 90 && GamePreferences.GetHardDifficulty() == 1)
        {
            EarnAchievement("FAST 10 BOMBS BLOW UP");
        }
        if (BombScript.scoreByBomb > 240 && GamePreferences.GetHardDifficulty() == 1)
        {
            EarnAchievement("FAST 25 BOMBS BLOW UP");
        }
        if (BombScript.scoreByBomb > 390  && GamePreferences.GetHardDifficulty() == 1)
        {
            EarnAchievement("FAST 40 BOMBS BLOW UP");
        }


        //SURVIVOR---------------------------------------------------------------
        //slow
        if (Score.currentTime > 240 && GamePreferences.GetEasyDifficulty() == 1)
        {
            EarnAchievement("SLOW 4 MINUTES SURVIVAL");
        }
        if (Score.currentTime > 420 && GamePreferences.GetEasyDifficulty() == 1)
        {
            EarnAchievement("SLOW 7 MINUTES SURVIVAL");
        }
        if (Score.currentTime > 600 == true && GamePreferences.GetEasyDifficulty() == 1)
        {
            EarnAchievement("SLOW 10 MINUTES SURVIVAL");
        }

        //Medium
        if (Score.currentTime > 240 && GamePreferences.GetMediumDifficulty() == 1)
        {
            EarnAchievement("NORMAL 4 MINUTES SURVIVAL");
        }
        if (Score.currentTime > 420 && GamePreferences.GetMediumDifficulty() == 1)
        {
            EarnAchievement("NORMAL 7 MINUTES SURVIVAL");
        }
        if (Score.currentTime > 600 && GamePreferences.GetMediumDifficulty() == 1)
        {
            EarnAchievement("NORMAL 10 MINUTES SURVIVAl");
        }

        //Difficult
        if (Score.currentTime > 240 && GamePreferences.GetHardDifficulty() == 1)
        {
            EarnAchievement("FAST 4 MINUTES SURVIVAL");
        }
        if (Score.currentTime > 420 && GamePreferences.GetHardDifficulty() == 1)
        {
            EarnAchievement("FAST 7 MINUTES SURVIVAL");
        }
        if (Score.currentTime > 600 && GamePreferences.GetHardDifficulty() == 1)
        {
            EarnAchievement("FAST 10 MINUTES SURVIVAL");
        }


    }



}

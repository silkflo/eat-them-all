
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

        if (Input.GetKeyDown(KeyCode.M) && SceneManager.GetActiveScene() == SceneManager.GetSceneByName(TagManager.FROG_SCENE))
        {
            AudioManager.instance.ButtonPressedSound();
            achievementMenu.SetActive(!achievementMenu.activeSelf);

            if (achievementMenu.activeSelf == true)
            {
                Time.timeScale = 0f;

              

            }
            else
            {
                GamePlayController.instance.pausePanel.SetActive(false);
                GamePlayController.panelOnCantMove = false;
                Time.timeScale = 1f;
            }
        }
     



        else if (SceneManager.GetActiveScene() == SceneManager.GetSceneByName(TagManager.ACHIEVEMENT_SCENE))
        {
            achievementMenu.SetActive(true);
            Score.totalScore = 0;  //fix a bug not resolved
           
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
      
        CreateAchievement(TagManager.FROG_ACHIEVEMENT, "Press W", "beat 400 in easy difficulty", 2);
        CreateAchievement(TagManager.FROG_ACHIEVEMENT, "Press X", "beat 800 in easy difficulty", 1);
        


        //-------------------------------------FROG-----------------------------------------------------------------
        //SCORE ACHIEVEMENT-----------------------------------------------------------------------------------------
        CreateAchievement(TagManager.FROG_ACHIEVEMENT, "Easy Score 400", "Beat 400 in easy difficulty", 2);
        CreateAchievement(TagManager.FROG_ACHIEVEMENT, "Easy Score 700", "Beat 700 in easy difficulty", 1);
        CreateAchievement(TagManager.FROG_ACHIEVEMENT, "Easy Score 1000", "Beat 1000 in easy difficulty", 0);

        CreateAchievement(TagManager.FROG_ACHIEVEMENT, "Medium Score 400", "Beat 400 in medium difficulty", 2);
        CreateAchievement(TagManager.FROG_ACHIEVEMENT, "Medium Score 700", "Beat 700 in medium difficulty", 1);
        CreateAchievement(TagManager.FROG_ACHIEVEMENT, "Medium Score 1000", "Beat 1000 in medium difficulty", 0);

        CreateAchievement(TagManager.FROG_ACHIEVEMENT, "Difficult Score 400", "Beat 400 in hard difficulty", 2);
        CreateAchievement(TagManager.FROG_ACHIEVEMENT, "Difficult Score 700", "Beat 700 in hard difficulty", 1);
        CreateAchievement(TagManager.FROG_ACHIEVEMENT, "Difficult Score 1000", "Beat 1000 in hard difficulty", 0);


        CreateAchievement(TagManager.FROG_ACHIEVEMENT, "All Score Achievement", "Beat all scores in all dificulties", 0,
                          new string[] { "Easy Score 400", "Easy Score 700", "Easy Score 1000",
                                         "Medium Score 400", "Medium Score 700", "Medium Score 1000",
                                         "Difficult Score 400", "Difficult Score 700", "Difficult Score 1000"});



        //EXPULSION FOODS ACHIEVEMENT---------------------------------------------------------------------------------------
        CreateAchievement(TagManager.FROG_ACHIEVEMENT, "Easy eat 50 insects", "Eat 50 insects in easy difficulty", 2);
        CreateAchievement(TagManager.FROG_ACHIEVEMENT, "Easy eat 100 insects", "Eat 100 insects in easy difficulty", 1);
        CreateAchievement(TagManager.FROG_ACHIEVEMENT, "Easy eat 150 insects", "Eat 150 insects in easy difficulty", 0);

        CreateAchievement(TagManager.FROG_ACHIEVEMENT, "Medium eat 50 insects", "Eat 50 insects in medium difficulty", 2);
        CreateAchievement(TagManager.FROG_ACHIEVEMENT, "Medium eat 100 insects", "Eat 100 insects in medium difficulty", 1);
        CreateAchievement(TagManager.FROG_ACHIEVEMENT, "Medium eat 150 insects", "Eat 150 insects in medium difficulty", 0);

        CreateAchievement(TagManager.FROG_ACHIEVEMENT, "Difficult eat 50 insects", "Eat 50 insects in hard difficulty", 2);
        CreateAchievement(TagManager.FROG_ACHIEVEMENT, "Difficult eat 100 insects", "Eat 100 insects in hard difficulty", 1);
        CreateAchievement(TagManager.FROG_ACHIEVEMENT, "Difficult eat 150 insects", "Eat 150 insects in hard difficulty", 0);


        CreateAchievement(TagManager.FROG_ACHIEVEMENT, "Big eater", "Eat all insects in all dificulties", 0,
                         new string[] {  "Easy eat 50 insects","Easy eat 100 insects","Easy eat 150 insects",
                                         "Medium eat 50 insects","Medium eat 100 insects","Medium eat 150 insects",
                                         "Difficult eat 50 insects","Easy eat 100 insects","Difficult eat 150 insects"});



        //EXPULSE OBJECTS----------------------------------------------------------------------------------------------------------
        CreateAchievement(TagManager.FROG_ACHIEVEMENT, "Easy eject 30 insects", "eject 30 insects in easy difficulty", 2);
        CreateAchievement(TagManager.FROG_ACHIEVEMENT, "Easy eject 60 insects", "eject 60 insects in easy difficulty", 1);
        CreateAchievement(TagManager.FROG_ACHIEVEMENT, "Easy eject 90 insects", "eject 90 insects in easy difficulty", 0);

        CreateAchievement(TagManager.FROG_ACHIEVEMENT, "Medium eject 30 insects", "eject 30 insects in medium difficulty", 2);
        CreateAchievement(TagManager.FROG_ACHIEVEMENT, "Medium eject 60 insects", "eject 60 insects in medium difficulty", 1);
        CreateAchievement(TagManager.FROG_ACHIEVEMENT, "Medium eject 90 insects", "eject 90 insects in medium difficulty", 0);

        CreateAchievement(TagManager.FROG_ACHIEVEMENT, "Difficult eject 30 insects", "eject 30 insects in hard difficulty", 2);
        CreateAchievement(TagManager.FROG_ACHIEVEMENT, "Difficult eject 60 insects", "eject 60 insects in hard difficulty", 1);
        CreateAchievement(TagManager.FROG_ACHIEVEMENT, "Difficult eject 90 insects", "eject 90 insects in hard difficulty", 0);



        CreateAchievement(TagManager.FROG_ACHIEVEMENT, "Master of insects throw up", "eject all insects in all dificulties", 0,
                      new string[] { "Easy eject 30 insects", "Easy eject 60 insects", "Easy eject 90 insects",
                                     "Medium eject 30 insects", "Medium eject 60 insects", "Medium eject 90 insects",
                                     "Difficult eject 30 insects", "Difficult eject 60 insects", "Difficult eject 90 insects",});

            

        //COMBO-----------------------------------------------------------------------------------------------------------------------
        CreateAchievement(TagManager.FROG_ACHIEVEMENT, "Easy Great Combo", "Great combo in easy difficulty", 2);
        CreateAchievement(TagManager.FROG_ACHIEVEMENT, "Easy Awesome Combo", "Awesome combo in easy difficulty", 1);
        CreateAchievement(TagManager.FROG_ACHIEVEMENT, "Easy Amazing Combo", "Amazing combo in easy difficulty", 0);

        CreateAchievement(TagManager.FROG_ACHIEVEMENT, "Medium Great Combo", "Great combo in medium difficulty", 2);
        CreateAchievement(TagManager.FROG_ACHIEVEMENT, "Medium Awesome Combo", "Awesome combo in medium difficulty", 1);
        CreateAchievement(TagManager.FROG_ACHIEVEMENT, "Medium Amazing Combo", "Amazing combo in medium difficulty", 0);

        CreateAchievement(TagManager.FROG_ACHIEVEMENT, "Difficult Great Combo", "Great combo in hard difficulty", 2);
        CreateAchievement(TagManager.FROG_ACHIEVEMENT, "Difficult Awesome Combo", "Awesome combo in hard difficulty", 1);
        CreateAchievement(TagManager.FROG_ACHIEVEMENT, "Difficult Amazing Combo", "Amazing combo in hard difficulty", 0);

        CreateAchievement(TagManager.FROG_ACHIEVEMENT, "Master of Combo", "All combos in all dificulties", 0,
                      new string[] { "Easy Great Combo", "Easy Awesome Combo", "Easy Amazing Combo",
                                     "Medium Great Combo", "Medium Awesome Combo", "Medium Amazing Combo",
                                     "Difficult Great Combo", "Difficult Awesome Combo", "Difficult Amazing Combo"});



        //BOMB EXPLODE
        CreateAchievement(TagManager.FROG_ACHIEVEMENT, "Easy 10 Bombs blow up", "10 bombs blow up in easy difficulty", 2);
        CreateAchievement(TagManager.FROG_ACHIEVEMENT, "Easy 25 Bombs blow up", "25 bombs blow up in easy difficulty", 1);
        CreateAchievement(TagManager.FROG_ACHIEVEMENT, "Easy 40 Bombs blow up", "40 bombs blow up in easy difficulty", 0);

        CreateAchievement(TagManager.FROG_ACHIEVEMENT, "Medium 10 Bombs blow up", "10 bombs blow up in Medium difficulty", 2);
        CreateAchievement(TagManager.FROG_ACHIEVEMENT, "Medium 25 Bombs blow up", "25 bombs blow up in Medium difficulty", 1);
        CreateAchievement(TagManager.FROG_ACHIEVEMENT, "Medium 40 Bombs blow up", "40 bombs blow up in Medium difficulty", 0);

        CreateAchievement(TagManager.FROG_ACHIEVEMENT, "Difficult 10 Bombs blow up", "10 bombs blow up in Hard difficulty", 2);
        CreateAchievement(TagManager.FROG_ACHIEVEMENT, "Difficult 25 Bombs blow up", "25 bombs blow up in Hard difficulty", 1);
        CreateAchievement(TagManager.FROG_ACHIEVEMENT, "Difficult 40 Bombs blow up", "40 bombs blow up in Hard difficulty", 0);

        CreateAchievement(TagManager.FROG_ACHIEVEMENT, "Master of Bombs", "blow up all bombs achievement in all dificulties", 0,
                      new string[] { "Easy 10 Bombs blow up", "Easy 25 Bombs blow up", "Easy 40 Bombs blow up",
                                     "Medium 10 Bombs blow up", "Medium 25 Bombs blow up", "Medium 40 Bombs blow up",
                                     "Difficult 10 Bombs blow up", "Difficult 25 Bombs blow up", "Difficult 40 Bombs blow up"});



        //TIME ACHIEVEMENT
        CreateAchievement(TagManager.FROG_ACHIEVEMENT, "Easy 4 minutes survival", "survive 4 minutes in easy difficulty", 2);
        CreateAchievement(TagManager.FROG_ACHIEVEMENT, "Easy 7 minutes survival", "survive 7 minutes in easy difficulty", 1);
        CreateAchievement(TagManager.FROG_ACHIEVEMENT, "Easy 10 minutes survival", "survive 10 minutes in easy difficulty", 0);

        CreateAchievement(TagManager.FROG_ACHIEVEMENT, "Medium 4 minutes survival", "survive 4 minutes in Medium difficulty", 2);
        CreateAchievement(TagManager.FROG_ACHIEVEMENT, "Medium 7 minutes survival", "survive 7 minutes in Medium difficulty", 1);
        CreateAchievement(TagManager.FROG_ACHIEVEMENT, "Medium 10 minutes survival", "survive 10 minutes in Medium difficulty", 0);

        CreateAchievement(TagManager.FROG_ACHIEVEMENT, "Difficult 4 minutes survival", "survive 4 minutes in hard difficulty", 2);
        CreateAchievement(TagManager.FROG_ACHIEVEMENT, "Difficult 7 minutes survival", "survive 7 minutes in hard difficulty", 1);
        CreateAchievement(TagManager.FROG_ACHIEVEMENT, "Difficult 10 minutes survival", "survive 10 minutes in hard difficulty", 0);

        CreateAchievement(TagManager.FROG_ACHIEVEMENT, "Survivor", "survive in all dificulties", 0,
                      new string[] { "Easy 4 minutes survival", "Easy 7 minutes survival", "Easy 10 minutes survival",
                                     "Medium 4 minutes survival", "Medium 7 minutes survival", "Medium 10 minutes survival",
                                     "Difficult 4 minutes survival", "Difficult 7 minutes survival", "Difficult 10 minutes survival"});



        //GAME MASTER
        CreateAchievement(TagManager.FROG_ACHIEVEMENT, "Game Master", "succeed all achievements", 0,
                      new string[] { "All Score Achievement", "Big eater", "Master of insects throw up",
                                     "Master of Combo","Master of Bombs","Survivor"});

        //--------------------------------------OTHER LEVEL----------------------------------------------------------------------
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
        if (Score.totalScore > 699 && GamePreferences.GetEasyDifficulty() == 1)
        {
            EarnAchievement("Easy Score 700");
        }
        if (Score.totalScore > 999 && GamePreferences.GetEasyDifficulty() == 1)
        {
            EarnAchievement("Easy Score 1000");
        }

        //Medium
        if (Score.totalScore > 399 && GamePreferences.GetMediumDifficulty() == 1)
        {
            EarnAchievement("Medium Score 400");
        }
        if (Score.totalScore > 699 && GamePreferences.GetMediumDifficulty() == 1)
        {
            EarnAchievement("Medium Score 700");
        }
        if (Score.totalScore > 999 && GamePreferences.GetMediumDifficulty() == 1)
        {
            EarnAchievement("Medium Score 1000");
        }

        //Difficult
        if (Score.totalScore > 399 && GamePreferences.GetHardDifficulty() == 1)
        {
            EarnAchievement("Difficult Score 400");
        }
        if (Score.totalScore > 699 && GamePreferences.GetHardDifficulty() == 1)
        {
            EarnAchievement("Difficult Score 700");
        }
        if (Score.totalScore > 999 && GamePreferences.GetHardDifficulty() == 1)
        {
            EarnAchievement("Difficult Score 1000");
        }



        //INSECT EATEN-----------------------------------------------------------------
        //Easy
        if (SpawnFood.scoreBySpawn > 49 && GamePreferences.GetEasyDifficulty() == 1)
        {
            EarnAchievement("Easy eat 50 insects");
        }
        if (SpawnFood.scoreBySpawn > 99 && GamePreferences.GetEasyDifficulty() == 1)
        {
            EarnAchievement("Easy eat 100 insects");
        }
        if (SpawnFood.scoreBySpawn > 149 && GamePreferences.GetEasyDifficulty() == 1)
        {
            EarnAchievement("Easy eat 150 insects");
        }

        //Medium
        if (SpawnFood.scoreBySpawn > 49 && GamePreferences.GetMediumDifficulty() == 1)
        {
            EarnAchievement("Medium eat 50 insects");
        }
        if (SpawnFood.scoreBySpawn > 99 && GamePreferences.GetMediumDifficulty() == 1)
        {
            EarnAchievement("Medium eat 100 insects");
        }
        if (SpawnFood.scoreBySpawn > 149 && GamePreferences.GetMediumDifficulty() == 1)
        {
            EarnAchievement("Medium eat 150 insects");
        }

        //Difficult
        if (SpawnFood.scoreBySpawn > 49 && GamePreferences.GetHardDifficulty() == 1)
        {
            EarnAchievement("Difficult eat 50 insects");
        }
        if (SpawnFood.scoreBySpawn > 99 && GamePreferences.GetHardDifficulty() == 1)
        {
            EarnAchievement("Difficult eat 100 insects");
        }
        if (SpawnFood.scoreBySpawn > 149 && GamePreferences.GetHardDifficulty() == 1)
        {
            EarnAchievement("Difficult eat 150 insects");
        }



        //eject INSECTS---------------------------------------------------------------
        //Easy
        if(DeactivateFood.countDeactivateobject >29 && GamePreferences.GetEasyDifficulty() == 1)
        {
            EarnAchievement("Easy eject 30 insects");
        }
        if (DeactivateFood.countDeactivateobject > 59 && GamePreferences.GetEasyDifficulty() == 1)
        {
            EarnAchievement("Easy eject 60 insects");
        }
        if (DeactivateFood.countDeactivateobject > 89 && GamePreferences.GetEasyDifficulty() == 1)
        {
            EarnAchievement("Easy eject 90 insects");
        }

        //Medium
        if (DeactivateFood.countDeactivateobject > 29 && GamePreferences.GetMediumDifficulty() == 1)
        {
            EarnAchievement("Medium eject 30 insects");
        }
        if (DeactivateFood.countDeactivateobject > 59 && GamePreferences.GetMediumDifficulty() == 1)
        {
            EarnAchievement("Medium eject 60 insects");
        }
        if (DeactivateFood.countDeactivateobject > 89 && GamePreferences.GetMediumDifficulty() == 1)
        {
            EarnAchievement("Medium eject 90 insects");
        }

        //Difficult
        if (DeactivateFood.countDeactivateobject > 29 && GamePreferences.GetHardDifficulty() == 1)
        {
            EarnAchievement("Difficult eject 30 insects");
        }
        if (DeactivateFood.countDeactivateobject > 59 && GamePreferences.GetHardDifficulty() == 1)
        {
            EarnAchievement("Difficult eject 60 insects");
        }
        if (DeactivateFood.countDeactivateobject > 89 && GamePreferences.GetHardDifficulty() == 1)
        {
            EarnAchievement("Difficult eject 90 insects");
        }



        //COMBO---------------------------------------------------------------
        //Easy
        if (GameManager.instance.greatBoolAnim == true && GamePreferences.GetEasyDifficulty() == 1)
        {
            EarnAchievement("Easy Great Combo");
        }
        if (GameManager.instance.awesomeBoolAnim == true  && GamePreferences.GetEasyDifficulty() == 1)
        {
            EarnAchievement("Easy Awesome Combo");
        }
        if (GameManager.instance.amazingBoolAnim == true && GamePreferences.GetEasyDifficulty() == 1)
        {
            EarnAchievement("Easy Amazing Combo");
        }


        //Medium
        if (GameManager.instance.greatBoolAnim == true && GamePreferences.GetMediumDifficulty() == 1)
        {
            EarnAchievement("Medium Great Combo");
        }
        if (GameManager.instance.awesomeBoolAnim == true && GamePreferences.GetMediumDifficulty() == 1)
        {
            EarnAchievement("Medium Awesome Combo");
        }
        if (GameManager.instance.amazingBoolAnim == true && GamePreferences.GetMediumDifficulty() == 1)
        {
            EarnAchievement("Medium Amazing Combo");
        }

        //Difficult
        if (GameManager.instance.greatBoolAnim == true && GamePreferences.GetHardDifficulty() == 1)
        {
            EarnAchievement("Difficult Great Combo");
        }
        if (GameManager.instance.awesomeBoolAnim == true && GamePreferences.GetHardDifficulty() == 1)
        {
            EarnAchievement("Difficult Awesome Combo");
        }
        if (GameManager.instance.amazingBoolAnim == true && GamePreferences.GetHardDifficulty() == 1)
        {
            EarnAchievement("Difficult Amazing Combo");
        }



        //BOMB EXPLOSE---------------------------------------------------------------
        //Easy
        if (BombScript.scoreByBomb > 90 && GamePreferences.GetEasyDifficulty() == 1)
        {
            EarnAchievement("Easy 10 Bombs blow up");
        }
        if (BombScript.scoreByBomb > 240 && GamePreferences.GetEasyDifficulty() == 1)
        {
            EarnAchievement("Easy 25 Bombs blow up");
        }
        if (BombScript.scoreByBomb > 390  && GamePreferences.GetEasyDifficulty() == 1)
        {
            EarnAchievement("Easy 40 Bombs blow up");
        }

        //Medium
        if (BombScript.scoreByBomb > 90 && GamePreferences.GetMediumDifficulty() == 1)
        {
            EarnAchievement("Medium 10 Bombs blow up");
        }
        if (BombScript.scoreByBomb > 240 && GamePreferences.GetMediumDifficulty() == 1)
        {
            EarnAchievement("Medium 25 Bombs blow up");
        }
        if (BombScript.scoreByBomb > 390  && GamePreferences.GetMediumDifficulty() == 1)
        {
            EarnAchievement("Medium 40 Bombs blow up");
        }

        //Difficult
        if (BombScript.scoreByBomb > 90 && GamePreferences.GetHardDifficulty() == 1)
        {
            EarnAchievement("Difficult 10 Bombs blow up");
        }
        if (BombScript.scoreByBomb > 240 && GamePreferences.GetHardDifficulty() == 1)
        {
            EarnAchievement("Difficult 25 Bombs blow up");
        }
        if (BombScript.scoreByBomb > 390  && GamePreferences.GetHardDifficulty() == 1)
        {
            EarnAchievement("Difficult 40 Bombs blow up");
        }


        //SURVIVOR---------------------------------------------------------------
        //Easy
        if (Score.currentTime > 240 && GamePreferences.GetEasyDifficulty() == 1)
        {
            EarnAchievement("Easy 4 minutes survival");
        }
        if (Score.currentTime > 420 && GamePreferences.GetEasyDifficulty() == 1)
        {
            EarnAchievement("Easy 7 minutes survival");
        }
        if (Score.currentTime > 600 == true && GamePreferences.GetEasyDifficulty() == 1)
        {
            EarnAchievement("Easy 10 minutes survival");
        }

        //Medium
        if (Score.currentTime > 240 && GamePreferences.GetMediumDifficulty() == 1)
        {
            EarnAchievement("Medium 4 minutes survival");
        }
        if (Score.currentTime > 420 && GamePreferences.GetMediumDifficulty() == 1)
        {
            EarnAchievement("Medium 7 minutes survival");
        }
        if (Score.currentTime > 600 && GamePreferences.GetMediumDifficulty() == 1)
        {
            EarnAchievement("Medium 10 minutes survival");
        }

        //Difficult
        if (Score.currentTime > 240 && GamePreferences.GetHardDifficulty() == 1)
        {
            EarnAchievement("Difficult 4 minutes survival");
        }
        if (Score.currentTime > 420 && GamePreferences.GetHardDifficulty() == 1)
        {
            EarnAchievement("Difficult 7 minutes survival");
        }
        if (Score.currentTime > 600 && GamePreferences.GetHardDifficulty() == 1)
        {
            EarnAchievement("Difficult 10 minutes survival");
        }


    }



}

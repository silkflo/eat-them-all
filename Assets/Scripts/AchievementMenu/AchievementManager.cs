
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
            AudioManager.instance.ClickMenuSound();
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
      
        CreateAchievement(TagManager.FROG_ACHIEVEMENT, "Press W", "beat 400 in slow difficulty", 2);
        CreateAchievement(TagManager.FROG_ACHIEVEMENT, "Press X", "beat 800 in slow difficulty", 1);
        


        //-------------------------------------FROG-----------------------------------------------------------------
        //SCORE ACHIEVEMENT-----------------------------------------------------------------------------------------
        CreateAchievement(TagManager.FROG_ACHIEVEMENT, "Slow Score 400", "Beat 400 in slow difficulty", 2);
        CreateAchievement(TagManager.FROG_ACHIEVEMENT, "Slow Score 700", "Beat 700 in slow difficulty", 1);
        CreateAchievement(TagManager.FROG_ACHIEVEMENT, "Slow Score 1000", "Beat 1000 in slow difficulty", 0);

        CreateAchievement(TagManager.FROG_ACHIEVEMENT, "Normal Score 400", "Beat 400 in normal difficulty", 2);
        CreateAchievement(TagManager.FROG_ACHIEVEMENT, "Normal Score 700", "Beat 700 in normal difficulty", 1);
        CreateAchievement(TagManager.FROG_ACHIEVEMENT, "Normal Score 1000", "Beat 1000 in normal difficulty", 0);

        CreateAchievement(TagManager.FROG_ACHIEVEMENT, "Fast Score 400", "Beat 400 in fast difficulty", 2);
        CreateAchievement(TagManager.FROG_ACHIEVEMENT, "Fast Score 700", "Beat 700 in fast difficulty", 1);
        CreateAchievement(TagManager.FROG_ACHIEVEMENT, "Fast Score 1000", "Beat 1000 in fast difficulty", 0);


        CreateAchievement(TagManager.FROG_ACHIEVEMENT, "All Score Achievement", "Beat all scores in all dificulties", 0,
                          new string[] { "Slow Score 400", "Slow Score 700", "Slow Score 1000",
                                         "Normal Score 400", "Normal Score 700", "Normal Score 1000",
                                         "Fast Score 400", "Fast Score 700", "Fast Score 1000"});



        //EXPULSION FOODS ACHIEVEMENT---------------------------------------------------------------------------------------
        CreateAchievement(TagManager.FROG_ACHIEVEMENT, "Slow eat 50 insects", "Eat 50 insects in slow difficulty", 2);
        CreateAchievement(TagManager.FROG_ACHIEVEMENT, "Slow eat 100 insects", "Eat 100 insects in slow difficulty", 1);
        CreateAchievement(TagManager.FROG_ACHIEVEMENT, "Slow eat 150 insects", "Eat 150 insects in slow difficulty", 0);

        CreateAchievement(TagManager.FROG_ACHIEVEMENT, "Normal eat 50 insects", "Eat 50 insects in normal difficulty", 2);
        CreateAchievement(TagManager.FROG_ACHIEVEMENT, "Normal eat 100 insects", "Eat 100 insects in normal difficulty", 1);
        CreateAchievement(TagManager.FROG_ACHIEVEMENT, "Normal eat 150 insects", "Eat 150 insects in normal difficulty", 0);

        CreateAchievement(TagManager.FROG_ACHIEVEMENT, "Fast eat 50 insects", "Eat 50 insects in fast difficulty", 2);
        CreateAchievement(TagManager.FROG_ACHIEVEMENT, "Fast eat 100 insects", "Eat 100 insects in fast difficulty", 1);
        CreateAchievement(TagManager.FROG_ACHIEVEMENT, "Fast eat 150 insects", "Eat 150 insects in fast difficulty", 0);


        CreateAchievement(TagManager.FROG_ACHIEVEMENT, "Big eater", "Eat all insects in all dificulties", 0,
                         new string[] {  "Slow eat 50 insects","Slow eat 100 insects","Slow eat 150 insects",
                                         "Normal eat 50 insects","Normal eat 100 insects","Normal eat 150 insects",
                                         "Fast eat 50 insects","Fast eat 100 insects","Fast eat 150 insects"});



        //EXPULSE OBJECTS----------------------------------------------------------------------------------------------------------
        CreateAchievement(TagManager.FROG_ACHIEVEMENT, "Slow eject 30 insects", "eject 30 insects in slow difficulty", 2);
        CreateAchievement(TagManager.FROG_ACHIEVEMENT, "Slow eject 60 insects", "eject 60 insects in slow difficulty", 1);
        CreateAchievement(TagManager.FROG_ACHIEVEMENT, "Slow eject 90 insects", "eject 90 insects in slow difficulty", 0);

        CreateAchievement(TagManager.FROG_ACHIEVEMENT, "Normal eject 30 insects", "eject 30 insects in normal difficulty", 2);
        CreateAchievement(TagManager.FROG_ACHIEVEMENT, "Normal eject 60 insects", "eject 60 insects in normal difficulty", 1);
        CreateAchievement(TagManager.FROG_ACHIEVEMENT, "Normal eject 90 insects", "eject 90 insects in normal difficulty", 0);

        CreateAchievement(TagManager.FROG_ACHIEVEMENT, "Fast eject 30 insects", "eject 30 insects in fast difficulty", 2);
        CreateAchievement(TagManager.FROG_ACHIEVEMENT, "Fast eject 60 insects", "eject 60 insects in fast difficulty", 1);
        CreateAchievement(TagManager.FROG_ACHIEVEMENT, "Fast eject 90 insects", "eject 90 insects in fast difficulty", 0);



        CreateAchievement(TagManager.FROG_ACHIEVEMENT, "Master of insects throw up", "eject all insects in all dificulties", 0,
                      new string[] { "Slow eject 30 insects", "Slow eject 60 insects", "Slow eject 90 insects",
                                     "Normal eject 30 insects", "Normal eject 60 insects", "Normal eject 90 insects",
                                     "Fast eject 30 insects", "Fast eject 60 insects", "Fast eject 90 insects",});

            

        //COMBO-----------------------------------------------------------------------------------------------------------------------
        CreateAchievement(TagManager.FROG_ACHIEVEMENT, "Slow Great Combo", "Great combo in slow difficulty", 2);
        CreateAchievement(TagManager.FROG_ACHIEVEMENT, "Slow Awesome Combo", "Awesome combo in slow difficulty", 1);
        CreateAchievement(TagManager.FROG_ACHIEVEMENT, "Slow Amazing Combo", "Amazing combo in slow difficulty", 0);

        CreateAchievement(TagManager.FROG_ACHIEVEMENT, "Normal Great Combo", "Great combo in normal difficulty", 2);
        CreateAchievement(TagManager.FROG_ACHIEVEMENT, "Normal Awesome Combo", "Awesome combo in normal difficulty", 1);
        CreateAchievement(TagManager.FROG_ACHIEVEMENT, "Normal Amazing Combo", "Amazing combo in normal difficulty", 0);

        CreateAchievement(TagManager.FROG_ACHIEVEMENT, "Fast Great Combo", "Great combo in fast difficulty", 2);
        CreateAchievement(TagManager.FROG_ACHIEVEMENT, "Fast Awesome Combo", "Awesome combo in fast difficulty", 1);
        CreateAchievement(TagManager.FROG_ACHIEVEMENT, "Fast Amazing Combo", "Amazing combo in fast difficulty", 0);

        CreateAchievement(TagManager.FROG_ACHIEVEMENT, "Master of Combo", "All combos in all dificulties", 0,
                      new string[] { "Slow Great Combo", "Slow Awesome Combo", "Slow Amazing Combo",
                                     "Normal Great Combo", "Normal Awesome Combo", "Normal Amazing Combo",
                                     "Fast Great Combo", "Fast Awesome Combo", "Fast Amazing Combo"});



        //BOMB EXPLODE
        CreateAchievement(TagManager.FROG_ACHIEVEMENT, "Slow 10 Bombs blow up", "10 bombs blow up in slow difficulty", 2);
        CreateAchievement(TagManager.FROG_ACHIEVEMENT, "Slow 25 Bombs blow up", "25 bombs blow up in slow difficulty", 1);
        CreateAchievement(TagManager.FROG_ACHIEVEMENT, "Slow 40 Bombs blow up", "40 bombs blow up in slow difficulty", 0);

        CreateAchievement(TagManager.FROG_ACHIEVEMENT, "Normal 10 Bombs blow up", "10 bombs blow up in Normal difficulty", 2);
        CreateAchievement(TagManager.FROG_ACHIEVEMENT, "Normal 25 Bombs blow up", "25 bombs blow up in Normal difficulty", 1);
        CreateAchievement(TagManager.FROG_ACHIEVEMENT, "Normal 40 Bombs blow up", "40 bombs blow up in Normal difficulty", 0);

        CreateAchievement(TagManager.FROG_ACHIEVEMENT, "Fast 10 Bombs blow up", "10 bombs blow up in Hard difficulty", 2);
        CreateAchievement(TagManager.FROG_ACHIEVEMENT, "Fast 25 Bombs blow up", "25 bombs blow up in Hard difficulty", 1);
        CreateAchievement(TagManager.FROG_ACHIEVEMENT, "Fast 40 Bombs blow up", "40 bombs blow up in Hard difficulty", 0);

        CreateAchievement(TagManager.FROG_ACHIEVEMENT, "Master of Bombs", "blow up all bombs achievement in all dificulties", 0,
                      new string[] { "Slow 10 Bombs blow up", "Slow 25 Bombs blow up", "Slow 40 Bombs blow up",
                                     "Normal 10 Bombs blow up", "Normal 25 Bombs blow up", "Normal 40 Bombs blow up",
                                     "Fast 10 Bombs blow up", "Fast 25 Bombs blow up", "Fast 40 Bombs blow up"});



        //TIME ACHIEVEMENT
        CreateAchievement(TagManager.FROG_ACHIEVEMENT, "Slow 4 minutes survival", "survive 4 minutes in slow difficulty", 2);
        CreateAchievement(TagManager.FROG_ACHIEVEMENT, "Slow 7 minutes survival", "survive 7 minutes in slow difficulty", 1);
        CreateAchievement(TagManager.FROG_ACHIEVEMENT, "Slow 10 minutes survival", "survive 10 minutes in slow difficulty", 0);

        CreateAchievement(TagManager.FROG_ACHIEVEMENT, "Normal 4 minutes survival", "survive 4 minutes in Normal difficulty", 2);
        CreateAchievement(TagManager.FROG_ACHIEVEMENT, "Normal 7 minutes survival", "survive 7 minutes in Normal difficulty", 1);
        CreateAchievement(TagManager.FROG_ACHIEVEMENT, "Normal 10 minutes survival", "survive 10 minutes in Normal difficulty", 0);

        CreateAchievement(TagManager.FROG_ACHIEVEMENT, "Fast 4 minutes survival", "survive 4 minutes in fast difficulty", 2);
        CreateAchievement(TagManager.FROG_ACHIEVEMENT, "Fast 7 minutes survival", "survive 7 minutes in fast difficulty", 1);
        CreateAchievement(TagManager.FROG_ACHIEVEMENT, "Fast 10 minutes survival", "survive 10 minutes in fast difficulty", 0);

        CreateAchievement(TagManager.FROG_ACHIEVEMENT, "Survivor", "survive in all dificulties", 0,
                      new string[] { "Slow 4 minutes survival", "Slow 7 minutes survival", "Slow 10 minutes survival",
                                     "Normal 4 minutes survival", "Normal 7 minutes survival", "Normal 10 minutes survival",
                                     "Fast 4 minutes survival", "Fast 7 minutes survival", "Fast 10 minutes survival"});



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
        //slow
        if (Score.totalScore > 399 && GamePreferences.GetEasyDifficulty() == 1)
        {
            EarnAchievement("Slow Score 400");
        }
        if (Score.totalScore > 699 && GamePreferences.GetEasyDifficulty() == 1)
        {
            EarnAchievement("Slow Score 700");
        }
        if (Score.totalScore > 999 && GamePreferences.GetEasyDifficulty() == 1)
        {
            EarnAchievement("Slow Score 1000");
        }

        //Medium
        if (Score.totalScore > 399 && GamePreferences.GetMediumDifficulty() == 1)
        {
            EarnAchievement("Normal Score 400");
        }
        if (Score.totalScore > 699 && GamePreferences.GetMediumDifficulty() == 1)
        {
            EarnAchievement("Normal Score 700");
        }
        if (Score.totalScore > 999 && GamePreferences.GetMediumDifficulty() == 1)
        {
            EarnAchievement("Normal Score 1000");
        }

        //Difficult
        if (Score.totalScore > 399 && GamePreferences.GetHardDifficulty() == 1)
        {
            EarnAchievement("Fast Score 400");
        }
        if (Score.totalScore > 699 && GamePreferences.GetHardDifficulty() == 1)
        {
            EarnAchievement("Fast Score 700");
        }
        if (Score.totalScore > 999 && GamePreferences.GetHardDifficulty() == 1)
        {
            EarnAchievement("Fast Score 1000");
        }



        //INSECT EATEN-----------------------------------------------------------------
        //slow
        if (SpawnFood.scoreBySpawn > 49 && GamePreferences.GetEasyDifficulty() == 1)
        {
            EarnAchievement("Slow eat 50 insects");
        }
        if (SpawnFood.scoreBySpawn > 99 && GamePreferences.GetEasyDifficulty() == 1)
        {
            EarnAchievement("Slow eat 100 insects");
        }
        if (SpawnFood.scoreBySpawn > 149 && GamePreferences.GetEasyDifficulty() == 1)
        {
            EarnAchievement("Slow eat 150 insects");
        }

        //Medium
        if (SpawnFood.scoreBySpawn > 49 && GamePreferences.GetMediumDifficulty() == 1)
        {
            EarnAchievement("Normal eat 50 insects");
        }
        if (SpawnFood.scoreBySpawn > 99 && GamePreferences.GetMediumDifficulty() == 1)
        {
            EarnAchievement("Normal eat 100 insects");
        }
        if (SpawnFood.scoreBySpawn > 149 && GamePreferences.GetMediumDifficulty() == 1)
        {
            EarnAchievement("Normal eat 150 insects");
        }

        //Difficult
        if (SpawnFood.scoreBySpawn > 49 && GamePreferences.GetHardDifficulty() == 1)
        {
            EarnAchievement("Fast eat 50 insects");
        }
        if (SpawnFood.scoreBySpawn > 99 && GamePreferences.GetHardDifficulty() == 1)
        {
            EarnAchievement("Fast eat 100 insects");
        }
        if (SpawnFood.scoreBySpawn > 149 && GamePreferences.GetHardDifficulty() == 1)
        {
            EarnAchievement("Fast eat 150 insects");
        }



        //eject INSECTS---------------------------------------------------------------
        //slow
        if(DeactivateFood.countDeactivateobject >29 && GamePreferences.GetEasyDifficulty() == 1)
        {
            EarnAchievement("Slow eject 30 insects");
        }
        if (DeactivateFood.countDeactivateobject > 59 && GamePreferences.GetEasyDifficulty() == 1)
        {
            EarnAchievement("Slow eject 60 insects");
        }
        if (DeactivateFood.countDeactivateobject > 89 && GamePreferences.GetEasyDifficulty() == 1)
        {
            EarnAchievement("Slow eject 90 insects");
        }

        //Medium
        if (DeactivateFood.countDeactivateobject > 29 && GamePreferences.GetMediumDifficulty() == 1)
        {
            EarnAchievement("Normal eject 30 insects");
        }
        if (DeactivateFood.countDeactivateobject > 59 && GamePreferences.GetMediumDifficulty() == 1)
        {
            EarnAchievement("Normal eject 60 insects");
        }
        if (DeactivateFood.countDeactivateobject > 89 && GamePreferences.GetMediumDifficulty() == 1)
        {
            EarnAchievement("Normal eject 90 insects");
        }

        //Difficult
        if (DeactivateFood.countDeactivateobject > 29 && GamePreferences.GetHardDifficulty() == 1)
        {
            EarnAchievement("Fast eject 30 insects");
        }
        if (DeactivateFood.countDeactivateobject > 59 && GamePreferences.GetHardDifficulty() == 1)
        {
            EarnAchievement("Fast eject 60 insects");
        }
        if (DeactivateFood.countDeactivateobject > 89 && GamePreferences.GetHardDifficulty() == 1)
        {
            EarnAchievement("Fast eject 90 insects");
        }



        //COMBO---------------------------------------------------------------
        //slow
        if (GameManager.instance.greatBoolAnim == true && GamePreferences.GetEasyDifficulty() == 1)
        {
            EarnAchievement("Slow Great Combo");
        }
        if (GameManager.instance.awesomeBoolAnim == true  && GamePreferences.GetEasyDifficulty() == 1)
        {
            EarnAchievement("Slow Awesome Combo");
        }
        if (GameManager.instance.amazingBoolAnim == true && GamePreferences.GetEasyDifficulty() == 1)
        {
            EarnAchievement("Slow Amazing Combo");
        }


        //Medium
        if (GameManager.instance.greatBoolAnim == true && GamePreferences.GetMediumDifficulty() == 1)
        {
            EarnAchievement("Normal Great Combo");
        }
        if (GameManager.instance.awesomeBoolAnim == true && GamePreferences.GetMediumDifficulty() == 1)
        {
            EarnAchievement("Normal Awesome Combo");
        }
        if (GameManager.instance.amazingBoolAnim == true && GamePreferences.GetMediumDifficulty() == 1)
        {
            EarnAchievement("Normal Amazing Combo");
        }

        //Difficult
        if (GameManager.instance.greatBoolAnim == true && GamePreferences.GetHardDifficulty() == 1)
        {
            EarnAchievement("Fast Great Combo");
        }
        if (GameManager.instance.awesomeBoolAnim == true && GamePreferences.GetHardDifficulty() == 1)
        {
            EarnAchievement("Fast Awesome Combo");
        }
        if (GameManager.instance.amazingBoolAnim == true && GamePreferences.GetHardDifficulty() == 1)
        {
            EarnAchievement("Fast Amazing Combo");
        }



        //BOMB EXPLOSE---------------------------------------------------------------
        //slow
        if (BombScript.scoreByBomb > 90 && GamePreferences.GetEasyDifficulty() == 1)
        {
            EarnAchievement("Slow 10 Bombs blow up");
        }
        if (BombScript.scoreByBomb > 240 && GamePreferences.GetEasyDifficulty() == 1)
        {
            EarnAchievement("Slow 25 Bombs blow up");
        }
        if (BombScript.scoreByBomb > 390  && GamePreferences.GetEasyDifficulty() == 1)
        {
            EarnAchievement("Slow 40 Bombs blow up");
        }

        //Medium
        if (BombScript.scoreByBomb > 90 && GamePreferences.GetMediumDifficulty() == 1)
        {
            EarnAchievement("Normal 10 Bombs blow up");
        }
        if (BombScript.scoreByBomb > 240 && GamePreferences.GetMediumDifficulty() == 1)
        {
            EarnAchievement("Normal 25 Bombs blow up");
        }
        if (BombScript.scoreByBomb > 390  && GamePreferences.GetMediumDifficulty() == 1)
        {
            EarnAchievement("Normal 40 Bombs blow up");
        }

        //Difficult
        if (BombScript.scoreByBomb > 90 && GamePreferences.GetHardDifficulty() == 1)
        {
            EarnAchievement("Fast 10 Bombs blow up");
        }
        if (BombScript.scoreByBomb > 240 && GamePreferences.GetHardDifficulty() == 1)
        {
            EarnAchievement("Fast 25 Bombs blow up");
        }
        if (BombScript.scoreByBomb > 390  && GamePreferences.GetHardDifficulty() == 1)
        {
            EarnAchievement("Fast 40 Bombs blow up");
        }


        //SURVIVOR---------------------------------------------------------------
        //slow
        if (Score.currentTime > 240 && GamePreferences.GetEasyDifficulty() == 1)
        {
            EarnAchievement("Slow 4 minutes survival");
        }
        if (Score.currentTime > 420 && GamePreferences.GetEasyDifficulty() == 1)
        {
            EarnAchievement("Slow 7 minutes survival");
        }
        if (Score.currentTime > 600 == true && GamePreferences.GetEasyDifficulty() == 1)
        {
            EarnAchievement("Slow 10 minutes survival");
        }

        //Medium
        if (Score.currentTime > 240 && GamePreferences.GetMediumDifficulty() == 1)
        {
            EarnAchievement("Normal 4 minutes survival");
        }
        if (Score.currentTime > 420 && GamePreferences.GetMediumDifficulty() == 1)
        {
            EarnAchievement("Normal 7 minutes survival");
        }
        if (Score.currentTime > 600 && GamePreferences.GetMediumDifficulty() == 1)
        {
            EarnAchievement("Normal 10 minutes survival");
        }

        //Difficult
        if (Score.currentTime > 240 && GamePreferences.GetHardDifficulty() == 1)
        {
            EarnAchievement("Fast 4 minutes survival");
        }
        if (Score.currentTime > 420 && GamePreferences.GetHardDifficulty() == 1)
        {
            EarnAchievement("Fast 7 minutes survival");
        }
        if (Score.currentTime > 600 && GamePreferences.GetHardDifficulty() == 1)
        {
            EarnAchievement("Fast 10 minutes survival");
        }


    }



}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class SpawnFood : MonoBehaviour
{
    public static SpawnFood instance;
    static public int scoreBySpawn;

    public float startPositionFoodX = -1f;
    public float startPositionFoodY = 20f;

    

    public GameObject[] foods;

    [HideInInspector]
    public int nextFoodToSpawn;
    private int foodToSpawn;

   

    void Awake()
    {
        MakeInstance();
        scoreBySpawn = 1;



    }

    void Start()
    {
        Instantiate(foods[Random.Range(0, foods.Length)],
            new Vector3(startPositionFoodX, startPositionFoodY, 0f), Quaternion.identity);
        nextFoodToSpawn = Random.Range(0, foods.Length);

    }
     
    void OnDisable()
    {
        instance = null;
    }

    void MakeInstance()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    public void StartSpawningFood()
    {
        scoreBySpawn = scoreBySpawn + 1;
        //  print("scoreBySpawn : " + scoreBySpawn);

        EventGA.instance.EatInsectEvent(scoreBySpawn);

       foodToSpawn = nextFoodToSpawn;

       
        // display the photo

        Instantiate(foods[foodToSpawn],
        new Vector3(startPositionFoodX, startPositionFoodY, 0f), Quaternion.identity);

       

        nextFoodToSpawn = Random.Range(0, foods.Length);
        print("Next FOOD : " + nextFoodToSpawn);
    }




}

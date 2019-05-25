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

    

    void Awake()
    {
        MakeInstance();
       

    }

    void Start()
    {
        StartSpawningFood();
      

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
        Instantiate(foods[Random.Range(0, foods.Length)],
        new Vector3(startPositionFoodX, startPositionFoodY, 0f), Quaternion.identity);
       

    }

   


}

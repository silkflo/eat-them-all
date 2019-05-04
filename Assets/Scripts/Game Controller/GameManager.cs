using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    [HideInInspector]
    public bool gameStartedFromMainMenu, gameRestartedAfterPlayerDied;

    [HideInInspector]
    public int score, spawnSore, bombScore, timeScore;

    void Awake()
    {
        MakeSingleton();
    }

 

    void Update()
    {
        
    }


    void MakeSingleton()
    {
        if (instance == null)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }












}

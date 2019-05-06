﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class GamePreferences
{
/*
    public static string EasyDifficulty = "EasyDifficulty";
    public static string MediumDifficulty = "MediumDifficulty";
    public static string HardDifficulty = "HardDifficulty";

    public static string EasyDifficultyHighScore = "EasyDifficultyHighScore";
    public static string MediumDifficultyHighScore = "MediumDifficultyHighScore";
    public static string HardDifficultyHighScore = "HardDifficultyHighScore";

    public static string EasyDifficultyCoinScore = "EasyDifficultyCoinScore";
    public static string MediumDifficultyCoinScore = "MediumDifficultyCoinScore";
    public static string HardDifficultyCoinScore = "HardDifficultyCoinScore";
*/
    public static string IS_MUSIC_ON = "IsMusicOn";

    //we are usiing int for bool value
    // 0 = false -- 1 = true

    //music
    public static int GetIsMusicOn()
    {
        return PlayerPrefs.GetInt(GamePreferences.IS_MUSIC_ON);
    }
    public static void SetIsMusicOn(int state)
    {
        PlayerPrefs.SetInt(GamePreferences.IS_MUSIC_ON, state);
    }

   /*
    //easy difficulty state
    public static int GetEasyDifficulty()
    {
        return PlayerPrefs.GetInt(GamePreferences.EasyDifficulty);
    }
    public static void SetEasyDifficulty(int state)
    {
        PlayerPrefs.SetInt(GamePreferences.EasyDifficulty, state);
    }

    //Medium difficulty state
    public static int GetMediumDifficulty()
    {
        return PlayerPrefs.GetInt(GamePreferences.MediumDifficulty);
    }
    public static void SetMediumDifficulty(int state)
    {
        PlayerPrefs.SetInt(GamePreferences.MediumDifficulty, state);
    }

    //Hard difficulty state
    public static int GetHardDifficulty()
    {
        return PlayerPrefs.GetInt(GamePreferences.HardDifficulty);
    }
    public static void SetHardDifficulty(int state)
    {
        PlayerPrefs.SetInt(GamePreferences.HardDifficulty, state);
    }


    //easy difficulty state highscore
    public static int GetEasyDifficultyHighScore()
    {
        return PlayerPrefs.GetInt(GamePreferences.EasyDifficultyHighScore);
    }
    public static void SetEasyDifficultyHighScore(int state)
    {
        PlayerPrefs.SetInt(GamePreferences.EasyDifficultyHighScore, state);
    }

    //Medium difficulty state HighScore
    public static int GetMediumDifficultyHighScore()
    {
        return PlayerPrefs.GetInt(GamePreferences.MediumDifficultyHighScore);
    }
    public static void SetMediumDifficultyHighScore(int state)
    {
        PlayerPrefs.SetInt(GamePreferences.MediumDifficultyHighScore, state);
    }

    //Hard difficulty state HighScore
    public static int GetHardDifficultyHighScore()
    {
        return PlayerPrefs.GetInt(GamePreferences.HardDifficultyHighScore);
    }
    public static void SetHardDifficultyHighScore(int state)
    {
        PlayerPrefs.SetInt(GamePreferences.HardDifficultyHighScore, state);
    }


    //easy difficulty state Coinscore
    public static int GetEasyDifficultyCoinScore()
    {
        return PlayerPrefs.GetInt(GamePreferences.EasyDifficultyCoinScore);
    }
    public static void SetEasyDifficultyCoinScore(int state)
    {
        PlayerPrefs.SetInt(GamePreferences.EasyDifficultyCoinScore, state);
    }

    //Medium difficulty state CoinScore
    public static int GetMediumDifficultyCoinScore()
    {
        return PlayerPrefs.GetInt(GamePreferences.MediumDifficultyCoinScore);
    }
    public static void SetMediumDifficultyCoinScore(int state)
    {
        PlayerPrefs.SetInt(GamePreferences.MediumDifficultyCoinScore, state);
    }

    //Hard difficulty state Coin Score
    public static int GetHardDifficultyCoinScore()
    {
        return PlayerPrefs.GetInt(GamePreferences.HardDifficultyCoinScore);
    }
    public static void SetHardDifficultyCoinScore(int state)
    {
        PlayerPrefs.SetInt(GamePreferences.HardDifficultyCoinScore, state);
    }

    */
}




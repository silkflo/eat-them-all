using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class GamePreferences
{

    public static string IS_MUSIC_ON = "IsMusicOn";

    //we are using int for bool value
    // 0 = false -- 1 = true

    //music
    public static int GetIsMusicOn()
    {
        return PlayerPrefs.GetInt(IS_MUSIC_ON);
    }
    public static void SetIsMusicOn(int state)
    {
        PlayerPrefs.SetInt(IS_MUSIC_ON, state);
    }

   
}





﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Achievement 
{

    private string name;
    private string description;
    private bool unlocked;
    private int spriteIndex;

    private GameObject achievementRef;


    public Achievement(string name, string description,int spriteIndex, GameObject achievementRef)
    {
        this.name = name;
        this.description = description;
        this.unlocked = false;
        this.spriteIndex = spriteIndex;
        this.achievementRef = achievementRef;
    }

   public bool EarnAchivement()
    {
        if (!unlocked)
        {
            unlocked = true;
            return true;
        }
        return false;
    }
}

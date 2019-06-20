using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GA_Event : MonoBehaviour
{
   
    void Start()
    {
        
    }

   
    void Update()
    {
        
    }


    public void ScoreEvent(int increaseAbout)
    {

        decimal value = Garter.I.Event("SlowScore", increaseAbout);
        StaticHelpersGarterSDK.SdkDebugger("Garter.I.Event (\"slow score  400\", " + increaseAbout + ")", value.ToString(), "all data (for illustration): easy score 400: " + value );


    }


}

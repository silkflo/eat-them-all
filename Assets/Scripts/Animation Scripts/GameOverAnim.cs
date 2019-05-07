using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverAnim : MonoBehaviour
{
    private Animator anim;

    void Awake()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    void GameOverPanelAnim()
    {
        if (Lose.gameOver == true)
        {
            anim.SetBool(TagManager.GAMEOVER_PARAMETER, true);
        }
    }


}

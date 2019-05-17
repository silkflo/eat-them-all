using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeactivateScoreAnimation : MonoBehaviour
{
    [SerializeField]
    private Animator greatAnim;

    //private GameObject deactivateScore;

/*
    private float minX = -8.6f;
    private float maxX = 1.3f;
    private float minY = 8f;
    private float maxY = 18f;
    
*/

    void Awake()
    {
      //  deactivateScore = GameObject.FindGameObjectWithTag(TagManager.SCORE_DEACTIVATE_TAG);
    }

  
    void Update()
    {
        
    }


    //DISPLAY +5 SCORE
    private void OnTriggerEnter2D(Collider2D target)
    {
        if(target.tag == TagManager.FOOD_TAG || target.tag == TagManager.BOMB_TAG)
        {
            //deactivateScore.transform.position = new Vector3(Random.Range(minX,maxX),Random.Range(minY,maxY));
           // print("spawn anim position : " + deactivateScore.transform.position);
           // greatAnim.Play(TagManager.DEACTIVATE_ANIMATION);
        }
    }






}

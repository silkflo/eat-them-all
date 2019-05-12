using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeactivateScoreAnimation : MonoBehaviour
{
    [SerializeField]
    private Animator greatAnim;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    private void OnTriggerEnter2D(Collider2D target)
    {
        if(target.tag == TagManager.FOOD_TAG || target.tag == TagManager.BOMB_TAG)
        {
            greatAnim.Play(TagManager.DEACTIVATE_ANIMATION);
        }
    }
}

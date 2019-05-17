using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombScript : MonoBehaviour
{
    
    private Animator anim;

    static public int scoreByBomb = 0;
    static public int startCountCombo;
    void Awake()
    {
        anim = GetComponentInParent<Animator>();
    }


    private void Update()
    {
        LoseByBomb();
    }
    
    
    public void OnTriggerEnter2D(Collider2D target)
    {
        if(target.tag == TagManager.FLAME_TAG)
        {
            startCountCombo = DeactivateScript.countDeactivateobject;

            print("start bomb deactivate = " + startCountCombo);
            anim.SetBool(TagManager.FLAME_PARAMETER, true);
            StartCoroutine(BombDeactivate());
        }
    }

    IEnumerator BombDeactivate()
    {
        yield return new WaitForSeconds(2f);

      
            scoreByBomb = scoreByBomb + 10;
        
        this.transform.parent.gameObject.SetActive(false);
    }

    // Can't figure out how to use it in LoseScript, so i put it here to made it work 
    private void LoseByBomb()
    {
        if (transform.position.y <=-20f && Lose.canLose == true)
        {
            print("GAME OVER by a bomb!!!");
            Lose.gameOver = true;
           
            
        }
    }

}

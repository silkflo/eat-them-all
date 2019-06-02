using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombScript : MonoBehaviour
{
    
    private Animator anim;

    static public int scoreByBomb;
    static public int startCountCombo;

    private bool hasExploded;

    void Awake()
    {
        anim = GetComponentInParent<Animator>();
    }

    private void Start()
    {
        hasExploded = true;
    }

    private void Update()
    {
       
      
    }


    public void OnTriggerEnter2D(Collider2D target)
    {
        if(target.tag == TagManager.FLAME_TAG)
        {
           
            if(hasExploded== true)
            {
                scoreByBomb = scoreByBomb + 10;
                hasExploded = false;
            }
          
            
            if (Lose.canLose == true)
            {
                startCountCombo = DeactivateFood.countDeactivateobject;
            }

            
         
            anim.SetBool(TagManager.FLAME_PARAMETER, true);


            AudioManager.instance.ExplosionSound();

            


            StartCoroutine(BombDeactivate());
            
        }
    }


    


    IEnumerator BombDeactivate()
    {
        yield return new WaitForSeconds(2f);
    

        this.transform.parent.gameObject.SetActive(false);
    }

  

}

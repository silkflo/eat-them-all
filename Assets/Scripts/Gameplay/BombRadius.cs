using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombRadius : MonoBehaviour
{

    [SerializeField] Rigidbody2D wormBody, scarabeBody, flyBody, bombBody;
    [SerializeField] Animator anim;
    public float powerX = 3f, powerY = 1f;


    void OnTriggerStay2D(Collider2D target)
    {
        if (anim.GetBool(TagManager.FLAME_TAG) == true)
        {
            //reset bool canlose true in case of multiple bomb explode simultanery
            //Lose.canLose = true;

            if (target.tag == TagManager.FOOD_TAG || 
                target.tag == TagManager.BOMB_TAG)
            {
                Lose.canLose = false;
                StartCoroutine (ForceApplied());
            }

           
            IEnumerator ForceApplied()
            {
                yield return new WaitForSeconds(1f);
                target.attachedRigidbody.AddRelativeForce(new Vector2(powerX, powerY), ForceMode2D.Impulse);
            }
         
        }
     
    }

    
   
    
  

}//class

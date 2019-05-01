using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FrogEyesStomachAnimationScript : MonoBehaviour
    
{

    [SerializeField] Animator anim;

    void Start(){
        StartCoroutine(FrogAnim());
    }

    IEnumerator FrogAnim() {
        yield return new WaitForSeconds(Random.Range(6f, 15f));
        anim.Play(TagManager.FROG_DELAYED_ANIM);

        StartCoroutine(FrogAnim());
    }




























}//class

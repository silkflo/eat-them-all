using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombScript : MonoBehaviour
{
    
    private Animator anim;

    static public int scoreByBomb;
    static public int startCountCombo;

    private bool hasExploded;


    public Camera mainCamera;
    private float shakeAmount;

    void Awake()
    {
        anim = GetComponentInParent<Animator>();

        if (mainCamera == null)
            mainCamera = Camera.main;
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
                AudioManager.instance.DetonationSound();
                scoreByBomb = scoreByBomb + 10;
                hasExploded = false;
                
                StartCoroutine(DelayShake());

                if (Garter.I.GetData<int>("speedLevel") == 1)
                { 
                    decimal bestAchievedValue = Garter.I.Event("SlowBomb");
                               
                    if (scoreByBomb / 10 > bestAchievedValue)
                    {
                        Garter.I.Event("SlowBomb", (scoreByBomb / 10 - bestAchievedValue));
                    }
                }

                if (Garter.I.GetData<int>("speedLevel") == 2)
                {
                    decimal bestAchievedValue = Garter.I.Event("NormalBomb");

                    if (scoreByBomb / 10 > bestAchievedValue)
                    {
                        Garter.I.Event("NormalBomb", (scoreByBomb / 10 - bestAchievedValue));
                    }
                }

                if (Garter.I.GetData<int>("speedLevel") == 3)
                {
                    decimal bestAchievedValue = Garter.I.Event("FastBomb");

                    if (scoreByBomb / 10 > bestAchievedValue)
                    {
                        Garter.I.Event("FastBomb", (scoreByBomb / 10 - bestAchievedValue));
                    }
                }
                 


            }
          
            
            if (Lose.canLose == true)
            {
                startCountCombo = DeactivateFood.countDeactivateobject;
            }

            
         
            anim.SetBool(TagManager.FLAME_PARAMETER, true);


           

            


            StartCoroutine(BombDeactivate());
            
        }
    }


    IEnumerator DelayShake()
    {
        yield return new WaitForSeconds(1f);
        AudioManager.instance.ExplosionSound();
        Shake(0.1f, 0.2f);

    }


    IEnumerator BombDeactivate()
    {
        yield return new WaitForSeconds(2f);
    

        this.transform.parent.gameObject.SetActive(false);
    }

  
    public void Shake(float amount, float lenght)
    {
        shakeAmount = amount;
        InvokeRepeating("DoShake", 0, 0.005f);
        Invoke("StopShake", lenght);
    }

    private void DoShake()
    {
        if (shakeAmount > 0)
        {
            Vector3 camPos = mainCamera.transform.position;

            float offsetX = Random.value * shakeAmount * 2 - shakeAmount;
            float offsetY = Random.value * shakeAmount * 2 - shakeAmount;

            camPos.x += offsetX;
            camPos.y += offsetY;

            mainCamera.transform.position = camPos;

        }
    }

    private void StopShake()
    {
        CancelInvoke("DoShake");
        mainCamera.transform.localPosition = Vector3.zero;
    }

}

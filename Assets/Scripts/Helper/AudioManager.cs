using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public  class AudioManager : MonoBehaviour
{

    public static AudioManager instance;

    public AudioSource  clickButtonAudioSource, clickStartAudioSource, clickBackAudioSource, buttonHoverAudioSource, pauseAudioSource, gameOverAudioSource,
                        greatAudioSource,awesomeAudioSource, amazingAudioSource,
                        scarabeAudioSource, dragonFlyAudioSource, wormAudioSource, 
                        flyAudioSource,  bombAudioSource, detonationAudioSource,
                        achievementAudioSource, freeFallAudioSource,
                        letsGoAudioSource;



    public AudioSource[] turnAudioSource, explosionAudioSource;

    public AudioClip    clickButtonClip,clickStartClip, clickBackClip, buttonHoverClip, pauseClip,gameOverClip,
                        greatClip,awesomeClip,amazingClip,
                        scarabeClip, dragonFlyClip, wormClip,
                        flyClip,bombClip, detonationClip,
                        achievementClip, freeFallClip,
                        letsGoClip;

    public AudioClip[] turnClip, explosionClip;


    public bool soundPlaying;

    void Awake()
    {
        MakeSingleTon();
    }



    void MakeSingleTon()
    {
        if(instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }


    public void ClickMenuSound()
    {

        if (Garter.I.GetData<int>("sound") == 0)
        {
            clickButtonAudioSource.Stop();
        }
        else
        {
            clickButtonAudioSource.PlayOneShot(clickButtonClip, 1.0f);
        }
    }

    public void ClickHoverSound()
    {
        if (Garter.I.GetData<int>("sound") == 0)
        {
            buttonHoverAudioSource.Stop();
        }
        else
        {
            freeFallAudioSource.PlayOneShot(buttonHoverClip, 0.7f);
        }
    }

    public void ClickStartSound()
    {
        if (Garter.I.GetData<int>("sound") == 0)
        {
            clickStartAudioSource.Stop();
        }
        else
        {
            clickStartAudioSource.PlayOneShot(clickStartClip, 1.0f);
        }
    }


    public void ClickBackSound()
    {
        if (Garter.I.GetData<int>("sound") == 0)
        {
            clickBackAudioSource.Stop();
        }
        else
        {
            clickBackAudioSource.PlayOneShot(clickBackClip, 1.0f);
        }
    }



    public void GameOverSound()
    {
        if (Garter.I.GetData<int>("sound") == 0)
        {
            gameOverAudioSource.Stop();
        }
        else
        {
            gameOverAudioSource.PlayOneShot(gameOverClip, 1.0f);
        }
    }

    public void PauseSound()
    {
        if (Garter.I.GetData<int>("sound") == 0)
        {
            pauseAudioSource.Stop();
        }
        else
        {
            pauseAudioSource.PlayOneShot(pauseClip, 1.0f);
        }
    }

    public void GreatSound()
    {
        if (Garter.I.GetData<int>("sound") == 0)
        {
            greatAudioSource.Stop();
        }
        else
        {
            greatAudioSource.PlayOneShot(greatClip, 1.0f);
        }
    }

    public void AwesomeSound()
    {
        if (Garter.I.GetData<int>("sound") == 0)
        {
            awesomeAudioSource.Stop();
        }
        else
        {
            awesomeAudioSource.PlayOneShot(awesomeClip, 1.0f);
        }
    }

    public void AmazingSound()
    {
        if (Garter.I.GetData<int>("sound") == 0)
        {
            amazingAudioSource.Stop();
        }
        else
        {
            amazingAudioSource.PlayOneShot(amazingClip, 1.0f);
        }
    }

    public void ScarabeSound()
    {
        if (Garter.I.GetData<int>("sound") == 0)
        {
            scarabeAudioSource.Stop();
        }
        else
        {
            scarabeAudioSource.PlayOneShot(scarabeClip, 1.0f);
        }
    }

    public void FlySound()
    {
        if (Garter.I.GetData<int>("sound") == 0)
        {
            flyAudioSource.Stop();
        }
        else
        {
            flyAudioSource.PlayOneShot(flyClip, 1.0f);
        }
    }

    public void DragonFlySound()
    {
        if (Garter.I.GetData<int>("sound") == 0)
        {
            dragonFlyAudioSource.Stop();
        }
        else
        {
            dragonFlyAudioSource.PlayOneShot(dragonFlyClip, 1.0f);
        }
    }

    public void WormSound()
    {
        if (Garter.I.GetData<int>("sound") == 0)
        {
            wormAudioSource.Stop();
        }
        else
        {
            wormAudioSource.PlayOneShot(wormClip, 1.0f);
        }
    }


    public void DetonationSound()
    {
        if (Garter.I.GetData<int>("sound") == 0)
        {
            detonationAudioSource.Stop();
        }
        else
        {
            detonationAudioSource.PlayOneShot(detonationClip, 1.0f);
        }
    }



    public void ExplosionSound()
    {
        int i = Random.Range(0, 4);

        if (Garter.I.GetData<int>("sound") == 0)
        {

            explosionAudioSource[i].Stop();


        }
        else
        {

            explosionAudioSource[i].PlayOneShot(explosionClip[i], 1.0f);
        }
    }

    public void BombSound()
    {
        if (Garter.I.GetData<int>("sound") == 0)
        {
            bombAudioSource.Stop();
        }
        else
        {
            bombAudioSource.PlayOneShot(bombClip, 1.0f);
        }
    }

    public void AchievementSound()
    {
        if (Garter.I.GetData<int>("sound") == 0)
        {
            achievementAudioSource.Stop();
        }
        else
        {
            achievementAudioSource.PlayOneShot(achievementClip, 1.0f);
        }
    }

    public void FreeFallSound()
    {
            if (Garter.I.GetData<int>("sound") == 0)
            {
            freeFallAudioSource.Stop();
            }
            else
            {
                freeFallAudioSource.PlayOneShot(freeFallClip, 1.0f);
            }
    }

    public void TurnSound()
    {
       int i = Random.Range(0, 5);

        if (Garter.I.GetData<int>("sound") == 0)
        {
         
                turnAudioSource[i].Stop();
            
            
        }
        else
        {

            turnAudioSource[i].PlayOneShot(turnClip[i], 1.0f);
        }
    }

    public void PlaySound(bool play)
    {
        if (play == true)
        {
            gameObject.SetActive(true);
        }
        else
        {
            gameObject.SetActive(false);
        }
    }

    public void LetsGoSound()
    {
        if (Garter.I.GetData<int>("sound") == 0)
        {
            letsGoAudioSource.Stop();
        }
        else
        {
            letsGoAudioSource.PlayOneShot(letsGoClip, 1.0f);
        }
    }



}

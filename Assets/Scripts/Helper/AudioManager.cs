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

        if (MainMenuController.instance.sound == false)
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
        if (MainMenuController.instance.sound == false)
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
        if (MainMenuController.instance.sound == false)
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
        if (MainMenuController.instance.sound == false)
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
        if (MainMenuController.instance.sound == false)
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
        if (MainMenuController.instance.sound == false)
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
        if (MainMenuController.instance.sound == false)
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
        if (MainMenuController.instance.sound == false)
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
        if (MainMenuController.instance.sound == false)
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
        if (MainMenuController.instance.sound == false)
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
        if (MainMenuController.instance.sound == false)
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
        if (MainMenuController.instance.sound == false)
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
        if (MainMenuController.instance.sound == false)
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
        if (MainMenuController.instance.sound == false)
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

        if (MainMenuController.instance.sound == false)
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
        if (MainMenuController.instance.sound == false)
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
        if (MainMenuController.instance.sound == false)
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
            if (MainMenuController.instance.sound == false)
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

        if (MainMenuController.instance.sound == false)
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
        if (MainMenuController.instance.sound == false)
        {
            letsGoAudioSource.Stop();
        }
        else
        {
            letsGoAudioSource.PlayOneShot(letsGoClip, 1.0f);
        }
    }



}

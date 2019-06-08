using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{

    public static AudioManager instance;

    public AudioSource  buttonPressedAudioSource, pauseAudioSource, gameOverAudioSource,
                        greatAudioSource,awesomeAudioSource, amazingAudioSource,
                        scarabeAudioSource, dragonFlyAudioSource, wormAudioSource, 
                        flyAudioSource, bombAudioSource, explosionAudioSource,
                        achievementAudioSource, freeFallAudioSource;



    public AudioClip    buttonPressedClip, pauseClip,gameOverClip,
                        greatClip,awesomeClip,amazingClip,
                        scarabeClip, dragonFlyClip, wormClip,
                        flyClip, bombClip, explosionClip,
                        achievementClip, freeFallClip;


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


    public void ButtonPressedSound()
    {

        if (GamePreferences.GetIsSoundOn() == 0)
        {
            buttonPressedAudioSource.Stop();
        }
        else
        {
            buttonPressedAudioSource.PlayOneShot(buttonPressedClip, 1.0f);
        }
    }

    public void GameOverSound()
    {
        if (GamePreferences.GetIsSoundOn() == 0)
        {
            buttonPressedAudioSource.Stop();
        }
        else
        {
            gameOverAudioSource.PlayOneShot(gameOverClip, 1.0f);
        }
    }

    public void PauseSound()
    {
        if (GamePreferences.GetIsSoundOn() == 0)
        {
            buttonPressedAudioSource.Stop();
        }
        else
        {
            pauseAudioSource.PlayOneShot(pauseClip, 1.0f);
        }
    }

    public void GreatSound()
    {
        if (GamePreferences.GetIsSoundOn() == 0)
        {
            buttonPressedAudioSource.Stop();
        }
        else
        {
            greatAudioSource.PlayOneShot(greatClip, 1.0f);
        }
    }

    public void AwesomeSound()
    {
        if (GamePreferences.GetIsSoundOn() == 0)
        {
            buttonPressedAudioSource.Stop();
        }
        else
        {
            awesomeAudioSource.PlayOneShot(awesomeClip, 1.0f);
        }
    }

    public void AmazingSound()
    {
        if (GamePreferences.GetIsSoundOn() == 0)
        {
            buttonPressedAudioSource.Stop();
        }
        else
        {
            amazingAudioSource.PlayOneShot(amazingClip, 1.0f);
        }
    }

    public void ScarabeSound()
    {
        if (GamePreferences.GetIsSoundOn() == 0)
        {
            buttonPressedAudioSource.Stop();
        }
        else
        {
            scarabeAudioSource.PlayOneShot(scarabeClip, 1.0f);
        }
    }

    public void FlySound()
    {
        if (GamePreferences.GetIsSoundOn() == 0)
        {
            buttonPressedAudioSource.Stop();
        }
        else
        {
            flyAudioSource.PlayOneShot(flyClip, 1.0f);
        }
    }

    public void DragonFlySound()
    {
        if (GamePreferences.GetIsSoundOn() == 0)
        {
            buttonPressedAudioSource.Stop();
        }
        else
        {
            dragonFlyAudioSource.PlayOneShot(dragonFlyClip, 1.0f);
        }
    }

    public void WormSound()
    {
        if (GamePreferences.GetIsSoundOn() == 0)
        {
            buttonPressedAudioSource.Stop();
        }
        else
        {
            wormAudioSource.PlayOneShot(wormClip, 1.0f);
        }
    }

    public void BombSound()
    {
        if (GamePreferences.GetIsSoundOn() == 0)
        {
            buttonPressedAudioSource.Stop();
        }
        else
        {
            bombAudioSource.PlayOneShot(bombClip, 1.0f);
        }
    }

    public void ExplosionSound()
    {
        if (GamePreferences.GetIsSoundOn() == 0)
        {
            buttonPressedAudioSource.Stop();
        }
        else
        {
            explosionAudioSource.PlayOneShot(explosionClip, 1.0f);
        }
    }

    public void AchievementSound()
    {
        if (GamePreferences.GetIsSoundOn() == 0)
        {
            buttonPressedAudioSource.Stop();
        }
        else
        {
            achievementAudioSource.PlayOneShot(achievementClip, 1.0f);
        }
    }

    public void FreeFallSound()
    {
            if (GamePreferences.GetIsSoundOn() == 0)
            {
                buttonPressedAudioSource.Stop();
            }
            else
            {
                freeFallAudioSource.PlayOneShot(freeFallClip, 1.0f);
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

}

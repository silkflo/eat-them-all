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
        buttonPressedAudioSource.PlayOneShot(buttonPressedClip, 1.0f);
    }

    public void GameOverSound()
    {
        gameOverAudioSource.PlayOneShot(gameOverClip, 1.0f);
    }

    public void PauseSound()
    {
        pauseAudioSource.PlayOneShot(pauseClip, 1.0f);
    }

    public void GreatSound()
    {
        greatAudioSource.PlayOneShot(greatClip, 1.0f);
    }

    public void AwesomeSound()
    {
        awesomeAudioSource.PlayOneShot(awesomeClip, 1.0f);
    }

    public void AmazingSound()
    {
        amazingAudioSource.PlayOneShot(amazingClip, 1.0f);
    }

    public void ScarabeSound()
    {
        scarabeAudioSource.PlayOneShot(scarabeClip, 1.0f);
    }

    public void FlySound()
    {
        flyAudioSource.PlayOneShot(flyClip, 1.0f);
    }

    public void DragonFlySound()
    {
        dragonFlyAudioSource.PlayOneShot(dragonFlyClip, 1.0f);
    }

    public void WormSound()
    {
        wormAudioSource.PlayOneShot(wormClip, 1.0f);
    }

    public void BombSound()
    {
        bombAudioSource.PlayOneShot(bombClip, 1.0f);
    }

    public void ExplosionSound()
    {
        explosionAudioSource.PlayOneShot(explosionClip, 1.0f);
    }

    public void AchievementSound()
    {
        achievementAudioSource.PlayOneShot(achievementClip, 1.0f);
    }

    public void FreeFallSound()
    {
        freeFallAudioSource.PlayOneShot(freeFallClip, 1.0f);
    }

}

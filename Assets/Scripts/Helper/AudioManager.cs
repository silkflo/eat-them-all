using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{

    public static AudioManager instance;

    public AudioSource buttonPressedAudioSource, pauseAudioSource, gameOverAudioSource,
                       greatAudioSource,awesomeAudioSource, amazingAudioSource;
    public AudioClip buttonPressedClip, pauseClip,gameOverClip,
                    greatClip,awesomeClip,amazingClip;



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



}

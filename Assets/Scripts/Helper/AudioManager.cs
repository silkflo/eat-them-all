using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{

    public static AudioManager instance;

    public AudioSource buttonPressedAudioSource, pauseAudioSource, gameOverAudioSource;
    public AudioClip buttonPressedClip, pauseClip,gameOverClip;



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





}

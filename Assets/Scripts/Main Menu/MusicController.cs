using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicController : MonoBehaviour
{

    public static MusicController instance;

    private AudioSource audioSource;


    void Awake()
    {
        MakeSingleTon();

        audioSource = GetComponent<AudioSource>();
    }




    void MakeSingleTon()
    {
        if (instance != null)
        {
            Destroy(gameObject);
        } else
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }

    /*
        public void PlayMusic (bool play)
        {
            if (play)
            {
                if (!audioSource.isPlaying)
                {
                    audioSource.Play();
                    print("PLAY");
                }
                else
                {
                    if(audioSource.isPlaying)
                    {
                        audioSource.Stop();
                        print("stopPLAY");
                    }
                }
            }
        }

    */
    public void PlayMusic(bool play)
    {

        if (play == true)
        {
            audioSource.Play();
          
        }
        else
        {
            audioSource.Stop();
            
        }
    }


    }

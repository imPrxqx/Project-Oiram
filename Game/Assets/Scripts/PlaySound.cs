using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaySound : MonoBehaviour
{
    public List<AudioClip> clip;

    [Range(0.1f, 3f)]
    public float volume;        //hlasitost

    AudioSource source;


    public static PlaySound instance;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
            return;
        }

        DontDestroyOnLoad(gameObject);
    }


    void Start()
    {
        source = GetComponent<AudioSource>(); //získávám audio source z AudioManageru pro přehrání zvuku
    }

    public void Play(int index)     //získává se index zvuku a ten se pak hraje
    {
        source.PlayOneShot(clip[index], volume);
    }
}

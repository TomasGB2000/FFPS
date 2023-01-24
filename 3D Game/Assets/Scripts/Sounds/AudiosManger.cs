using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using System;

public class AudiosManger : MonoBehaviour
{
    /***************************************************************************************
* Title: Introduction to AUDIO in Unity
* Author: Brackeys
* Date: 2017
* Code version: N/A
* Availability: https://www.youtube.com/watch?v=6OT43pvUyfY
***************************************************************************************/
    public Sound[] sounds;
    // Start is called before the first frame update
    void Awake()
    {
        foreach (Sound s in sounds)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;
            s.source.volume = s.volume;
            s.source.pitch = s.pitch;
        }
        
    }

    public void Play(string name)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        if (s == null)
        {
            return;
        }
        s.source.Play();
    }
}

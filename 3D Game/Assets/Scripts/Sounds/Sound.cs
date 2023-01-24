using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

[System.Serializable]
public class Sound 
{
    /***************************************************************************************
* Title: Introduction to AUDIO in Unity
* Author: Brackeys
* Date: 2017
* Code version: N/A
* Availability: https://www.youtube.com/watch?v=6OT43pvUyfY
***************************************************************************************/
    public string name;

    public AudioClip clip;

    [Range(0f,1f)]
    public float volume;
    [Range(.1f, 3f)]
    public float pitch;

    [HideInInspector]
    public AudioSource source;
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{  //Assigning Audio to Events
    private AudioSource _soundSource;
    public AudioClip _shootSound;
    public AudioClip _enemydeathSound;
    public AudioClip _winSound;
    public AudioClip _loseSound;
    public AudioClip _gruntSound;
    public AudioClip _keySound;
    public AudioClip _keySound1;
    

    void Start()
    {   //Assigning Sound Clips to assigned events
        _soundSource = GetComponent<AudioSource>();
        _shootSound = Resources.Load("lmg_fire01") as AudioClip;
        _enemydeathSound = Resources.Load("deathr") as AudioClip;
        _winSound = Resources.Load("win music 2") as AudioClip;
        _loseSound = Resources.Load("Icy Game Over") as AudioClip;
        _gruntSound = Resources.Load("gruntsound") as AudioClip;
        _keySound = Resources.Load("Key Jiggle") as AudioClip;
        _keySound1 = Resources.Load("key_pickup") as AudioClip;
    }


    void Update()
    {

    }
    //Assigning Clips to be used in other scripts
    public void playShootSound()
    {
        _soundSource.PlayOneShot(_shootSound);
    }

    public void playEnemyDeathSound()
    {
        _soundSource.PlayOneShot(_enemydeathSound);
    }


    public void playWinSound()
    {
        _soundSource.PlayOneShot(_winSound);
    }

    public void playLoseSound()
    {
        _soundSource.PlayOneShot(_loseSound);
    }

    public void playGruntSound()
    {
        _soundSource.PlayOneShot(_gruntSound);
    }

    public void playKeySound()
    {
        _soundSource.PlayOneShot(_keySound);
    }

    public void playKeyPickUpSound()
    {
        _soundSource.PlayOneShot(_keySound1);
    }

    /*void SoundClick()
    {
        if (Input.GetKey(KeyCode.Mouse0))
        {
           playShootSound();
        }
    }*/
}
